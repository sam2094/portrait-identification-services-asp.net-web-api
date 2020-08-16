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
	public class EditBranch : Logic<EditBranchInput, EditBranchOutput>
	{
		public EditBranch(IUnitofWork uow,
				string firstExecutedLogicName,
				bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		public override void DoExecute()
		{
			Branch branch = null;

			int orgId = _uow.GetRepository<User>().Get(x => x.Id == Parameters.CurrentUserId, i => i.Branch).Branch.OrganizationId;

			User currentUser = _uow.GetRepository<User>().Get(x => x.Id == Parameters.CurrentUserId, i => i.Role, i => i.Branch);
			if (currentUser.RoleId == (int)Roles.SUPER_ADMIN)
			{
				branch = _uow.GetRepository<Branch>().Get(x => x.Id == Parameters.BranchId);
			}
			else if (currentUser.Role.Level == Levels.ORGANIZATION_LEVEL.ToString())
			{
				branch = _uow.GetRepository<Branch>().Get(x => x.Id == Parameters.BranchId && x.OrganizationId == orgId);
			}
			else if (currentUser.Role.Level == Levels.BRANCH_LEVEL.ToString() && currentUser.BranchId == Parameters.BranchId)
			{
				branch = _uow.GetRepository<Branch>().Get(x => x.Id == currentUser.BranchId);
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

			if (_uow.GetRepository<Branch>().IsExist(x => x.Email.ToUpper().Trim() == Parameters.Email.ToUpper().Trim() && x.Id != Parameters.BranchId))
			{
				Result.ErrorList.Add(new Error()
				{
					ErrorCode = ErrorCodes.EMAIL_IS_EXIST,
					ErrorMessage = Resource.EMAIL_IS_EXIST,
					StatusCode = ErrorHttpStatus.FORBIDDEN
				});
				return;
			}

			DateTime date = DateTime.Now;
			branch.PlaceName = Parameters.PlaceName;
			branch.PlaceAddress = Parameters.PlaceAddress;
			branch.ContactNumber = Parameters.ContactNumber;
			branch.Email = Parameters.Email;
			branch.UpdateDate = date;
			_uow.SaveChanges();
		}
	}
}
