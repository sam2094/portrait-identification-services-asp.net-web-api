using FaceRecognizer.Common;
using FaceRecognizer.Common.Enums;
using FaceRecognizer.Common.Enums.CommonEnums;
using FaceRecognizer.Common.Enums.DatabaseEnums.RoleEnums;
using FaceRecognizer.Common.Helpers;
using FaceRecognizer.Common.Resources;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.DTOs.BranchDtos;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.BranchLogic;
using System.IO;

namespace FaceRecognizer.BusinessLogic.Logic.BranchLogic
{
	public class GetBranchById : Logic<GetBranchByIdInput, GetBranchByIdOutput>
	{
		public GetBranchById(IUnitofWork uow,
				string firstExecutedLogicName,
				bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		public override void DoExecute()
		{
			Branch branch = null;
			int orgId = _uow.GetRepository<User>().Get(x => x.Id == Parameters.CurrentUserId, i => i.Branch).Branch.OrganizationId;
			User currentUser = _uow.GetRepository<User>().Get(x => x.Id == Parameters.CurrentUserId, i => i.Role, i => i.Branch);

			if (currentUser.RoleId == (int)Roles.SUPER_ADMIN)
			{
				branch = _uow.GetRepository<Branch>().Get(x => x.Id == Parameters.BranchId, i => i.Organization, i => i.Region);
			}
			else if (currentUser.Role.Level == Levels.ORGANIZATION_LEVEL.ToString())
			{
				branch = _uow.GetRepository<Branch>().Get(x => x.Id == Parameters.BranchId && x.OrganizationId == orgId, i => i.Organization, i => i.Region);
			}
			else if (currentUser.Role.Level == Levels.BRANCH_LEVEL.ToString() && currentUser.BranchId == Parameters.BranchId)
			{
				branch = _uow.GetRepository<Branch>().Get(x => x.Id == currentUser.BranchId, i => i.Organization, i => i.Region);
			}

			if (branch == null)
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.BRANCH_IS_NOT_EXIST,
					ErrorMessage = Resource.BRANCH_IS_NOT_EXIST,
					StatusCode = ErrorHttpStatus.NOT_FOUND
				});
				return;
			}

			Result.Output.BranchDto = new BranchDto
			{
				Id = branch.Id,
				Email = branch.Email,
				ContactNumber = branch.ContactNumber,
				PlaceAddress = branch.PlaceAddress,
				PlaceName = branch.PlaceName,
				Code = branch.Code,
				Photo = File.Exists(Path.Combine(ConfigHelper.GetAppSetting("Photo"), branch.Organization.Photo)) ?
				File.ReadAllBytes(Path.Combine(ConfigHelper.GetAppSetting("Photo"), branch.Organization.Photo)) : null,
				OrganizationId = branch.OrganizationId,
				OrganizationName = branch.Organization.Name,
				RegionId = branch.RegionId,
				RegionName = branch.Region.Name,
				AddedDate = branch.AddedDate,
				UpdateDate = branch.UpdateDate
			};
		}
	}
}
