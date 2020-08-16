using FaceRecognizer.Common;
using FaceRecognizer.Common.Enums;
using FaceRecognizer.Common.Enums.CommonEnums;
using FaceRecognizer.Common.Enums.DatabaseEnums.RoleEnums;
using FaceRecognizer.Common.Resources;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.UserLogic;

namespace FaceRecognizer.BusinessLogic.Logic.UserLogic
{
    public class EditUser : Logic<EditUserInput, EditUserOutput>
	{
		public EditUser(IUnitofWork uow,
				string firstExecutedLogicName,
				bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		public override void DoExecute()
		{
			User currentUser = _uow.GetRepository<User>().Get(x => x.Id == Parameters.CurrentUserId, i => i.Role, i => i.Branch);
			bool isSuperAdmin = currentUser.RoleId == (int)Roles.SUPER_ADMIN ? true : false;

			User user = null;

			if (isSuperAdmin)
			{
				user = _uow.GetRepository<User>().Get(x => x.Id == Parameters.UserId, i => i.Branch);
			}
			else if (currentUser.Role.Level == Levels.ORGANIZATION_LEVEL.ToString())
			{
				user = _uow.GetRepository<User>().Get(x => x.Id == Parameters.UserId && x.Branch.OrganizationId == currentUser.Branch.OrganizationId, i => i.Branch.Organization);
			}
			else if ((currentUser.Role.Level == Levels.BRANCH_LEVEL.ToString()))
			{
				user = _uow.GetRepository<User>().Get(x => x.Id == Parameters.UserId && x.BranchId == currentUser.BranchId, i => i.Branch);
			}

			if (user == null)
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.USER_IS_NOT_EXIST,
					ErrorMessage = Resource.USER_IS_NOT_EXIST,
					StatusCode = ErrorHttpStatus.NOT_FOUND
				});
				return;
			}

			Role role = _uow.GetRepository<Role>().Get(x => x.Id == Parameters.RoleId && x.RoleGroup.OrganizationId == user.Branch.OrganizationId
			&& x.Id != (int)Roles.SUPER_ADMIN, i => i.RoleGroup);

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

			if (currentUser.Role.Level == Levels.BRANCH_LEVEL.ToString() && role.Level.ToUpper().Trim() != Levels.BRANCH_LEVEL.ToString())
			{
				Result.ErrorList.Add(new Error()
				{
					ErrorCode = ErrorCodes.ACCESS_DENIED,
					ErrorMessage = Resource.ACCESS_DENIED,
					StatusCode = ErrorHttpStatus.FORBIDDEN
				});
				return;
			}

			if (user.DocumentNumber.ToUpper().Trim() == Parameters.DocumentNumber.ToUpper().Trim() && user.DocumentPin == Parameters.DocumentPin)
			{
				user.Contact = Parameters.Contact;
				user.UserStatusId = Parameters.UserStatusId;
				user.RoleId = role.Id;
				_uow.SaveChanges();
				return;
			}

			if (user.DocumentNumber != Parameters.DocumentNumber && user.DocumentPin == Parameters.DocumentPin)
			{
				GetData data = Data.GetData(
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

				user.DocumentNumber = Parameters.DocumentNumber;
				user.Name = data.Name;
				user.Surname = data.Surname;
				user.Patronymic = data.Patronymic;
				user.Contact = Parameters.Contact;
				user.UserStatusId = Parameters.UserStatusId;
				user.RoleId = role.Id;
				_uow.SaveChanges();
				return;
			}
			else
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.PIN_NOT_EXIST_OR_EXPIRED,
					ErrorMessage = Resource.PIN_NOT_EXIST_OR_EXPIRED,
					StatusCode = ErrorHttpStatus.FORBIDDEN
				});
				return;
			}
		}
	}
}
