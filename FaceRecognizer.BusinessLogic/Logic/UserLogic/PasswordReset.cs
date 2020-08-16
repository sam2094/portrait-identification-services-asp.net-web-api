using FaceRecognizer.Common;
using FaceRecognizer.Common.Enums;
using FaceRecognizer.Common.Enums.CommonEnums;
using FaceRecognizer.Common.Enums.DatabaseEnums.RoleEnums;
using FaceRecognizer.Common.Helpers;
using FaceRecognizer.Common.Resources;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.UserLogic;
using System;

namespace FaceRecognizer.BusinessLogic.Logic.UserLogic
{
	public class PasswordReset : Logic<PasswordResetInput, PasswordResetOutput>
	{
		public PasswordReset(IUnitofWork uow,
				string firstExecutedLogicName,
				bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		public override void DoExecute()
		{
			User currentUser = _uow.GetRepository<User>().Get(x => x.Id == Parameters.CurrentUserId, i => i.Role, i => i.Branch);
			bool isSuperAdmin = currentUser.RoleId == (int)Roles.SUPER_ADMIN ? true : false;

			User user = null;

			if (isSuperAdmin)
			{
				user = _uow.GetRepository<User>().Get(x => x.Id == Parameters.UserId);
			}
			else if (currentUser.Role.Level == Levels.ORGANIZATION_LEVEL.ToString())
			{
				user = _uow.GetRepository<User>().Get(x => x.Id == Parameters.UserId && x.Branch.OrganizationId == currentUser.Branch.OrganizationId);
			}
			else if ((currentUser.Role.Level == Levels.BRANCH_LEVEL.ToString()))
			{
				user = _uow.GetRepository<User>().Get(x => x.Id == Parameters.UserId && x.BranchId == currentUser.BranchId);
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

			byte[] salt = Hashing.RandomSalt;
			string password = string.Concat(user.Username, new Random().Next(1000, 9999));

			user.Salt = salt;
			user.Password = Hashing.Hash(salt, password);
			_uow.SaveChanges();

			using (Sms sms = new Sms())
			{
				sms.Send(user.Contact, string.Format(ConfigHelper.GetAppSetting("CreateUserSms"), user.Username.Trim(), password));
			}
		}
	}
}