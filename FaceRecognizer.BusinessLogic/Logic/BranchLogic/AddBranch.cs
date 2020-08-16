using System;
using FaceRecognizer.Common;
using FaceRecognizer.Common.Enums;
using FaceRecognizer.Common.Enums.CommonEnums;
using FaceRecognizer.Common.Enums.DatabaseEnums.RoleEnums;
using FaceRecognizer.Common.Resources;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.BranchLogic;

namespace FaceRecognizer.BusinessLogic.Logic.BranchLogic
{
	public class AddBranch : Logic<AddBranchInput, AddBranchOutput>
	{
		public AddBranch(IUnitofWork uow,
				string firstExecutedLogicName,
				bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		public override void DoExecute()
		{
			if (!_uow.GetRepository<Region>().IsExist(x => x.Id == Parameters.RegionId))
			{
				Result.ErrorList.Add(new Error()
				{
					ErrorCode = ErrorCodes.REGION_IS_NOT_EXIST,
					ErrorMessage = Resource.REGION_DOES_NOT_EXIST,
					StatusCode = ErrorHttpStatus.NOT_FOUND
				});
				return;
			}

			if (_uow.GetRepository<Branch>().IsExist(x => x.Email.ToUpper().Trim() == Parameters.Email.ToUpper().Trim()))
			{
				Result.ErrorList.Add(new Error()
				{
					ErrorCode = ErrorCodes.EMAIL_IS_EXIST,
					ErrorMessage = Resource.EMAIL_IS_EXIST,
					StatusCode = ErrorHttpStatus.FORBIDDEN
				});
				return;
			}

			bool isExist = false;
			bool isSuperAdmin = false;

			User currentUser = _uow.GetRepository<User>().Get(x => x.Id == Parameters.CurrentUserId, i => i.Role, i => i.Branch);
			if (currentUser.RoleId == (int)Roles.SUPER_ADMIN)
			{
				isExist = _uow.GetRepository<Branch>().IsExist(x => x.OrganizationId == Parameters.OrganizationId && x.Code.ToUpper().Trim() == Parameters.Code.ToUpper().Trim());
				isSuperAdmin = true;
			}
			else if (currentUser.Role.Level == Levels.ORGANIZATION_LEVEL.ToString())
			{
				int orgId = _uow.GetRepository<User>().Get(x => x.Id == Parameters.CurrentUserId, i => i.Branch).Branch.OrganizationId;
				isExist = _uow.GetRepository<Branch>().IsExist(x => x.OrganizationId == orgId && x.Code.ToUpper().Trim() == Parameters.Code.ToUpper().Trim());
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

			if (isExist)
			{
				Result.ErrorList.Add(new Error()
				{
					ErrorCode = ErrorCodes.SAME_CODE,
					ErrorMessage = Resource.BRANCH_CODE_İS_EXİST,
					StatusCode = ErrorHttpStatus.FORBIDDEN
				});
				return;
			}

			DateTime date = DateTime.Now;

			if (isSuperAdmin)
			{
				if (!_uow.GetRepository<Organization>().IsExist(x => x.Id == Parameters.OrganizationId))
				{
					Result.ErrorList.Add(new Error()
					{
						ErrorCode = ErrorCodes.ORGANIZATION_DOES_NOT_EXIST,
						ErrorMessage = Resource.ORGANIZATION_DOES_NOT_EXIST,
						StatusCode = ErrorHttpStatus.NOT_FOUND
					});
					return;
				}

				_uow.GetRepository<Branch>().Add(new Branch
				{
					OrganizationId = Parameters.OrganizationId,
					RegionId = Parameters.RegionId,
					Code = Parameters.Code,
					PlaceName = Parameters.PlaceName,
					PlaceAddress = Parameters.PlaceAddress,
					ContactNumber = Parameters.ContactNumber,
					Email = Parameters.Email,
					AddedDate = date,
					UpdateDate = date
				});
				_uow.SaveChanges();
				return;
			}
			else if (currentUser.Role.Level == Levels.ORGANIZATION_LEVEL.ToString())
			{
				_uow.GetRepository<Branch>().Add(new Branch
				{
					OrganizationId = currentUser.Branch.OrganizationId,
					RegionId = Parameters.RegionId,
					Code = Parameters.Code,
					PlaceName = Parameters.PlaceName,
					PlaceAddress = Parameters.PlaceAddress,
					ContactNumber = Parameters.ContactNumber,
					Email = Parameters.Email,
					AddedDate = date,
					UpdateDate = date
				});
				_uow.SaveChanges();
				return;
			}
		}
	}
}
