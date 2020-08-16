using FaceRecognizer.Common;
using FaceRecognizer.Common.Enums;
using FaceRecognizer.Common.Enums.CommonEnums;
using FaceRecognizer.Common.Enums.DatabaseEnums.RoleEnums;
using FaceRecognizer.Common.Resources;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.UserLogic;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FaceRecognizer.BusinessLogic.Logic.UserLogic
{
	public class UploadUserFile : Logic<UploadUserFileRequestInput, UploadUserFileOutput>
	{
		public UploadUserFile(IUnitofWork uow,
				string firstExecutedLogicName,
				bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		public override async Task DoExecuteAsync()
		{
			if (!Parameters.Request.Content.IsMimeMultipartContent())
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.MIMETYPE_IS_NOT_MULTIPART,
					ErrorMessage = Resource.MIMETYPE_IS_NOT_MULTIPART,
					StatusCode = ErrorHttpStatus.VALIDATION
				});
				return;
			}


			MultipartMemoryStreamProvider streamProvider = await Parameters.Request.Content.ReadAsMultipartAsync();
			if (streamProvider.Contents.Count < 3)
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.INPUT_IS_NOT_VALID,
					ErrorMessage = Resource.INVALID_INPUT,
					StatusCode = ErrorHttpStatus.VALIDATION
				});
				return;
			}
			//TODO : Prevent filesize becoming more than 10 mb.
			UploadUserFileInput input = new UploadUserFileInput
			{
				CurrentUserId = Parameters.CurrentUserId,
				RawData = await streamProvider.Contents[0]?.ReadAsByteArrayAsync(),
				FileName = streamProvider.Contents[0]?.Headers?.ContentDisposition?.FileName?.Trim('"')
			};

			int.TryParse(await streamProvider.Contents[1]?.ReadAsStringAsync(), out int userId);
			byte.TryParse(await streamProvider.Contents[2]?.ReadAsStringAsync(), out byte userFileTypeId);
			input.UserId = userId;
			input.UserFileTypeId = userFileTypeId;

			ValidationResult validationResult = new UploadUserFileInputValidator().Validate(input);

			if (!validationResult.IsValid)
			{
				validationResult.Errors.ForEach(item => Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.INPUT_IS_NOT_VALID,
					ErrorMessage = item.ErrorMessage,
					StatusCode = ErrorHttpStatus.VALIDATION
				}));
				return;
			}

			if (!_uow.GetRepository<UserFileType>()
				 .IsExist(x => x.Id == input.UserFileTypeId))
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.USER_FILE_TYPE_DOES_NOT_EXIST,
					ErrorMessage = Resource.USER_FILE_TYPE_DOES_NOT_EXIST,
					StatusCode = ErrorHttpStatus.NOT_FOUND
				});
				return;
			}

			User currentUser = _uow.GetRepository<User>().Get(x => x.Id == Parameters.CurrentUserId, i => i.Role, i => i.Branch);
			bool isSuperAdmin = currentUser.RoleId == (int)Roles.SUPER_ADMIN ? true : false;
			int orgId = _uow.GetRepository<User>().Get(x => x.Id == currentUser.Id, i => i.Branch).Branch.OrganizationId;

			User user = null;

			if (isSuperAdmin)
			{
				user = _uow.GetRepository<User>().Get(x => x.Id == input.UserId);
			}
			else if (currentUser.Role.Level == Levels.ORGANIZATION_LEVEL.ToString())
			{
				user = _uow.GetRepository<User>().Get(x => x.Id == input.UserId && x.Branch.OrganizationId == orgId,
					i => i.Branch);
			}
			else if ((currentUser.Role.Level == Levels.BRANCH_LEVEL.ToString()))
			{
				user = _uow.GetRepository<User>().Get(x => x.Id == input.UserId && x.BranchId == currentUser.BranchId);
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

			if (_uow.GetRepository<UserFile>().IsExist(x => x.UserId == input.UserId && x.UserFileTypeId == input.UserFileTypeId))
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.USER_FILE_IS_EXIST,
					ErrorMessage = Resource.USER_FILE_IS_EXIST,
					StatusCode = ErrorHttpStatus.FORBIDDEN
				});
				return;
			}

			_uow.GetRepository<UserFile>().Add(new UserFile
			{
				UserId = user.Id,
				UserFileTypeId = input.UserFileTypeId,
				UserFileName = input.FileName,
				UserRawData = input.RawData,
			});
			_uow.SaveChanges();
		}
	}
}
