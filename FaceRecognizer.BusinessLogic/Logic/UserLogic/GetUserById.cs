using FaceRecognizer.Common;
using FaceRecognizer.Common.ConfigManager;
using FaceRecognizer.Common.Enums;
using FaceRecognizer.Common.Enums.CommonEnums;
using FaceRecognizer.Common.Enums.DatabaseEnums.RoleEnums;
using FaceRecognizer.Common.FileManager;
using FaceRecognizer.Common.Helpers;
using FaceRecognizer.Common.Resources;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.DTOs.UserDtos;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.UserLogic;
using System.IO;

namespace FaceRecognizer.BusinessLogic.Logic.UserLogic
{
	public class GetUserById : Logic<GetUserByIdInput, GetUserByIdOutput>
	{
		private readonly IFileOperations _fileOperations;
		private readonly IConfigOperations _configOperation;

		public GetUserById(IUnitofWork uow,
			IFileOperations fileOperations,
			IConfigOperations configOperation,
			string firstExecutedLogicName,
			bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction)
		{
			_fileOperations = fileOperations;
			_configOperation = configOperation;
		}

		public override void DoExecute()
		{
			User currentUser = _uow.GetRepository<User>().Get(x => x.Id == Parameters.CurrentUserId, i => i.Role, i => i.Branch);
			bool isSuperAdmin = currentUser.RoleId == (int)Roles.SUPER_ADMIN ? true : false;

			User user = null;

			if (isSuperAdmin)
			{
				user = _uow.GetRepository<User>().Get(x => x.Id == Parameters.UserId, i => i.Branch.Organization, i => i.Role.RoleGroup, i => i.UserStatus);
			}
			else if (currentUser.Role.Level == Levels.ORGANIZATION_LEVEL.ToString())
			{
				user = _uow.GetRepository<User>().Get(x => x.Id == Parameters.UserId && x.Branch.OrganizationId == currentUser.Branch.OrganizationId, i => i.Branch.Organization, i => i.Role.RoleGroup, i => i.UserStatus);
			}
			else if ((currentUser.Role.Level == Levels.BRANCH_LEVEL.ToString()))
			{
				user = _uow.GetRepository<User>().Get(x => x.Id == Parameters.UserId && x.BranchId == currentUser.BranchId, i => i.Branch.Organization, i => i.Role.RoleGroup, i => i.UserStatus);
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

			byte[] photoBytes = File.Exists(Path.Combine(ConfigHelper.GetAppSetting("Photo"), user.Photo)) ? _fileOperations.ReadAllBytes(Path.Combine(_configOperation.Get("Photo"), user.Photo)) : null;

			Result.Output.User = new GetUserByIdDto
			{
				Id = user.Id,
				UserStatusId = user.UserStatusId,
				UserStatusName = user.UserStatus.Name,
				BranchId = user.BranchId,
				BranchName = user.Branch.PlaceName,
				RoleId = user.RoleId,
				RoleName = user.Role.Name,
				RoleGroupId = user.Role.RoleGroupId,
				RoleGroupName = user.Role.RoleGroup.Name,
				OrganizationId = user.Branch.OrganizationId,
				OrganizationName = user.Branch.Organization.Name,
				ParentId = user.ParentId,
				Name = user.Name,
				Surname = user.Surname,
				Patronymic = user.Patronymic,
				Username = user.Username,
				Contact = user.Contact,
				DocumentNumber = user.DocumentNumber,
				DocumentPin = user.DocumentPin,
				IsFaceRecognized = user.IsFaceRecognized,
				AddedDate = user.AddedDate,
				Photo = photoBytes
			};
		}
	}
}
