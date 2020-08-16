using FaceRecognizer.Common;
using FaceRecognizer.Common.Enums;
using FaceRecognizer.Common.Enums.CommonEnums;
using FaceRecognizer.Common.Enums.DatabaseEnums.RoleEnums;
using FaceRecognizer.Common.Resources;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.UserLogic;

namespace FaceRecognizer.BusinessLogic.Logic.ContractLogic
{
	public class DownloadUserFile : Logic<DownloadUserFileInput, DownloadUserFileOutput>
	{
		public DownloadUserFile(IUnitofWork uow,
				string firstExecutedLogicName,
				bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		public override void DoExecute()
		{
			User currentUser = _uow.GetRepository<User>().Get(x => x.Id == Parameters.CurrentUserId, i => i.Role, i => i.Branch);
			bool isSuperAdmin = currentUser.RoleId == (int)Roles.SUPER_ADMIN ? true : false;
			int orgId = _uow.GetRepository<User>().Get(x => x.Id == currentUser.Id, i => i.Branch).Branch.OrganizationId;

			UserFile userFile = null;

			if (!_uow.GetRepository<UserFileType>()
				 .IsExist(x => x.Id == Parameters.UserFileTypeId))
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.USER_FILE_TYPE_DOES_NOT_EXIST,
					ErrorMessage = Resource.USER_FILE_TYPE_DOES_NOT_EXIST,
					StatusCode = ErrorHttpStatus.NOT_FOUND
				});
				return;
			}

			if (isSuperAdmin)
			{
				userFile = _uow.GetRepository<UserFile>().Get(x => x.UserId == Parameters.UserId && x.UserFileTypeId == Parameters.UserFileTypeId);
			}
			else if (currentUser.Role.Level == Levels.ORGANIZATION_LEVEL.ToString())
			{
				userFile = _uow.GetRepository<UserFile>().Get(x => x.UserId == Parameters.UserId
				&& x.UserFileTypeId == Parameters.UserFileTypeId
				&& x.User.Branch.OrganizationId == orgId,
				   i => i.User.Branch);
			}
			else if (currentUser.Role.Level == Levels.BRANCH_LEVEL.ToString())
			{
				userFile = _uow.GetRepository<UserFile>().Get(x => x.UserId == Parameters.UserId
				&& x.UserFileTypeId == Parameters.UserFileTypeId
				&& x.User.BranchId == currentUser.BranchId,
					 i => i.User.Branch);
			}

			if (userFile == null
				&& string.IsNullOrEmpty(userFile?.UserFileName)
				&& userFile?.UserRawData == null)
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.USER_FILE_DOES_NOT_EXIST,
					ErrorMessage = Resource.USER_FILE_DOES_NOT_EXIST,
					StatusCode = ErrorHttpStatus.NOT_FOUND
				});
				return;
			}

			Result.Output = new DownloadUserFileOutput
			{
				UserFile = userFile.UserRawData
			};
		}
	}
}
