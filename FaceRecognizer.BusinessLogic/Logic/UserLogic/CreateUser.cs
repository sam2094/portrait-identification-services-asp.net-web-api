using System;
using FaceRecognizer.Common;
using FaceRecognizer.Common.Enums;
using FaceRecognizer.Common.Helpers;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.UserLogic;
using FaceRecognizer.Common.Resources;
using System.IO;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Common.Enums.DatabaseEnums.RoleEnums;
using FaceRecognizer.Common.Enums.CommonEnums;

namespace FaceRecognizer.BusinessLogic.Logic.UserLogic
{
	public class CreateUser : Logic<CreateUserInput, CreateUserOutput>
	{
		public CreateUser(IUnitofWork uow,
				string firstExecutedLogicName,
				bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		private static readonly object _lock = new object();
		public override void DoExecute()
		{
			GetDataDto data = Data.GetData(
				Parameters.DocumentNumber.Trim().ToUpper(),
				Parameters.DocumentPin.Trim().ToUpper(),
				Parameters.DocType);

			if (data?.ResultStatus?.Code == (int)ErrorHttpStatus.INTERNAL)
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.INPUT_IS_NOT_VALID,
					ErrorMessage = Resource.INPUT_IS_NOT_VALID,
					StatusCode = ErrorHttpStatus.INTERNAL
				});
				return;
			}

			if (data == null || data.ResultStatus?.Code != (int)ErrorHttpStatus.WARNING || !data.IsActive)
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.INPUT_IS_NOT_VALID,
					ErrorMessage = Resource.INPUT_IS_NOT_VALID,
					StatusCode = ErrorHttpStatus.NOT_FOUND
				});
				return;
			}

			if (!_uow.GetRepository<Branch>().IsExist(x => x.Id == Parameters.BranchId))
			{
				Result.ErrorList.Add(new Error()
				{
					ErrorCode = ErrorCodes.BRANCH_IS_NOT_EXIST,
					ErrorMessage = Resource.BRANCH_IS_NOT_EXIST,
					StatusCode = ErrorHttpStatus.NOT_FOUND
				});
				return;
			}

			if (!_uow.GetRepository<UserStatus>().IsExist(x => x.Id == Parameters.UserStatusId))
			{
				Result.ErrorList.Add(new Error()
				{
					ErrorCode = ErrorCodes.USER_STATUS_IS_NOT_EXIST,
					ErrorMessage = Resource.USER_STATUS_IS_NOT_EXIST,
					StatusCode = ErrorHttpStatus.NOT_FOUND
				});
				return;
			}

			int orgId = _uow.GetRepository<Branch>().Get(x => x.Id == Parameters.BranchId, i => i.Organization).Organization.Id;

			if (_uow.GetRepository<User>().IsExist(x => x.DocumentPin == Parameters.DocumentPin && x.Branch.OrganizationId == orgId, i => i.Branch))
			{
				Result.ErrorList.Add(new Error()
				{
					ErrorCode = ErrorCodes.DOCUMENT_PIN_IS_EXIST,
					ErrorMessage = Resource.DOCUMENT_PIN_IS_EXIST,
					StatusCode = ErrorHttpStatus.FORBIDDEN
				});
				return;
			}

			User currentUser = _uow.GetRepository<User>().Get(x => x.Id == Parameters.CurrentUserId, i => i.Role, i => i.Branch);

			if (_uow.GetRepository<User>().IsExist(x => x.Branch.OrganizationId == orgId && x.Username.ToUpper().Trim() == Parameters.Username.ToUpper().Trim(), i => i.Branch))
			{
				Result.ErrorList.Add(new Error()
				{
					ErrorCode = ErrorCodes.USERNAME_IS_EXIST,
					ErrorMessage = Resource.USERNAME_IS_EXIST,
					StatusCode = ErrorHttpStatus.FORBIDDEN
				});
				return;
			}

			Role role = _uow.GetRepository<Role>().Get(x => x.Id == Parameters.RoleId && x.RoleGroup.OrganizationId == orgId && x.Id != (int)Roles.SUPER_ADMIN, i => i.RoleGroup);

			if (role == null)
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.ROLE_DOES_NOT_EXIST,
					ErrorMessage = Resource.ROLE_DOES_NOT_EXIST,
					StatusCode = ErrorHttpStatus.NOT_FOUND
				});
				return;
			}

			bool isSuperAdmin = currentUser.RoleId == (int)Roles.SUPER_ADMIN ? true : false;

			string photoName = string.Empty;

			lock (_lock)
			{
				photoName = string.Concat(Guid.NewGuid().ToString("N"), ".jpg");
			}

			File.WriteAllBytes(Path.Combine(ConfigHelper.GetAppSetting("Photo"), photoName), Convert.FromBase64String(data.Image));
			byte[] salt = Hashing.RandomSalt;
			string password = string.Concat(Parameters.Username, new Random().Next(1000, 9999));

			User user = new User()
			{
				BranchId = Parameters.BranchId,
				UserStatusId = Parameters.UserStatusId,
				RoleId = Parameters.RoleId,
				DocumentNumber = Parameters.DocumentNumber.Trim().ToUpper(),
				DocumentPin = Parameters.DocumentPin.Trim().ToUpper(),
				Name = data.Name.Trim().ToUpper(),
				Surname = data.Surname.Trim().ToUpper(),
				Patronymic = data.Patronymic.Trim().ToUpper(),
				Contact = Parameters.Contact,
				ParentId = Parameters.CurrentUserId,
				Username = Parameters.Username.Trim().ToLower(),
				IsFaceRecognized = Parameters.IsFaceRecognized,
				Salt = salt,
				Password = Hashing.Hash(salt, password),
				AddedDate = DateTime.Now,
				Photo = photoName
			};

			if (isSuperAdmin)
			{
				int branchOrgId = _uow.GetRepository<Branch>().Get(x => x.Id == Parameters.BranchId).OrganizationId;
				int roleOrgId = _uow.GetRepository<Role>().Get(x => x.Id == Parameters.RoleId, i => i.RoleGroup).RoleGroup.OrganizationId;

				if (branchOrgId != roleOrgId)
				{
					Result.ErrorList.Add(new Error()
					{
						ErrorCode = ErrorCodes.ROLE_DOES_NOT_EXIST,
						ErrorMessage = Resource.ROLE_DOES_NOT_EXIST,
						StatusCode = ErrorHttpStatus.NOT_FOUND
					});
					return;
				}

				user.BranchId = Parameters.BranchId;
				user.RoleId = Parameters.RoleId;
			}
			else if (currentUser.Role.Level == Levels.ORGANIZATION_LEVEL.ToString())
			{
				if (_uow.GetRepository<Branch>().IsExist(x => x.OrganizationId == orgId && currentUser.Branch.OrganizationId == orgId))
				{
					user.BranchId = Parameters.BranchId;
					user.RoleId = Parameters.RoleId;
				}
				else
				{
					Result.ErrorList.Add(new Error()
					{
						ErrorCode = ErrorCodes.ACCESS_DENIED,
						ErrorMessage = Resource.ACCESS_DENIED,
						StatusCode = ErrorHttpStatus.FORBIDDEN
					});
					return;
				}
			}
			else if ((currentUser.Role.Level == Levels.BRANCH_LEVEL.ToString() && currentUser.BranchId == Parameters.BranchId
					&& role.Level.ToUpper().Trim() == Levels.BRANCH_LEVEL.ToString()))
			{
				user.BranchId = currentUser.BranchId;
				user.RoleId = Parameters.RoleId;
			}
			else
			{
				Result.ErrorList.Add(new Error()
				{
					ErrorCode = ErrorCodes.ACCESS_DENIED,
					ErrorMessage = Resource.ACCESS_DENIED,
					StatusCode = ErrorHttpStatus.FORBIDDEN
				});
				return;
			}
			_uow.GetRepository<User>().Add(user);
			_uow.SaveChanges();

			using (Sms sms = new Sms())
			{
				sms.Send(Parameters.Contact, string.Format(ConfigHelper.GetAppSetting("CreateUserSms"), Parameters.Username.Trim(), password));
			}
		}
	}
}
