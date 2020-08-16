using FaceRecognizer.Common.Enums.CommonEnums;
using FaceRecognizer.Common.Enums.DatabaseEnums.RoleEnums;
using FaceRecognizer.Common.Helpers;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.DTOs.BranchDtos;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.BranchLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FaceRecognizer.BusinessLogic.Logic.BranchLogic
{
	public class GetBranches : Logic<GetBranchesInput, GetBranchesOutput>
	{
		public GetBranches(IUnitofWork uow,
				string firstExecutedLogicName,
				bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }
		public override void DoExecute()
		{
			User currentUser = _uow.GetRepository<User>().Get(x => x.Id == Parameters.CurrentUserId, i => i.Role, i => i.Branch);
			List<Branch> branches = new List<Branch>();
			var totalCount = 0;

			Parameters.PlaceName = Parameters.PlaceName?.Trim().Replace("İ", "i").ToUpper();

			if (currentUser.RoleId == (int)Roles.SUPER_ADMIN)
			{
				branches = _uow.GetRepository<Branch>().GetAll(x => (Parameters.OrganizationId == 0 || x.OrganizationId == Parameters.OrganizationId)
				&& (Parameters.RegionId == 0 || x.RegionId == Parameters.RegionId)
				&& (Parameters.Code == null || Parameters.Code.Trim() == "" || x.Code.Trim().ToUpper() == Parameters.Code.Trim().ToUpper())
				&& (Parameters.PlaceName == null || Parameters.PlaceName == "" || x.PlaceName.Trim().Replace("İ", "i").ToUpper().Contains(Parameters.PlaceName)),
					i => i.Organization, i => i.Region).OrderByDescending(x => x.Id).Skip((Parameters.PageNumber - 1) * Parameters.DataCount).Take(Parameters.DataCount).ToList();

				totalCount = _uow.GetRepository<Branch>().Count(x => (Parameters.OrganizationId == 0 || x.OrganizationId == Parameters.OrganizationId)
				&& (Parameters.RegionId == 0 || x.RegionId == Parameters.RegionId)
				&& (Parameters.Code == null || Parameters.Code.Trim() == "" || x.Code.Trim().ToUpper() == Parameters.Code.Trim().ToUpper())
				&& (Parameters.PlaceName == null || Parameters.PlaceName == "" || x.PlaceName.Trim().Replace("İ", "i").ToUpper().Contains(Parameters.PlaceName)));
			}
			else if (currentUser.Role.Level == Levels.ORGANIZATION_LEVEL.ToString())
			{
				int orgId = _uow.GetRepository<User>().Get(x => x.Id == Parameters.CurrentUserId, i => i.Branch).Branch.OrganizationId;

				branches = _uow.GetRepository<Branch>().GetAll(x => (x.OrganizationId == orgId)
					&& (Parameters.RegionId == 0 || x.RegionId == Parameters.RegionId)
					&& (Parameters.Code == null || Parameters.Code.Trim() == "" || x.Code.Trim().ToUpper() == Parameters.Code.Trim().ToUpper())
					&& (Parameters.PlaceName == null || Parameters.PlaceName == "" || x.PlaceName.Trim().ToUpper().Contains(Parameters.PlaceName)), i => i.Organization, i => i.Region).OrderByDescending(x => x.Id).Skip((Parameters.PageNumber - 1) * Parameters.DataCount).Take(Parameters.DataCount).ToList();

				totalCount = _uow.GetRepository<Branch>().Count(x => (x.OrganizationId == orgId)
					&& (Parameters.RegionId == 0 || x.RegionId == Parameters.RegionId)
					&& (Parameters.Code == null || Parameters.Code.Trim() == "" || x.Code.Trim().ToUpper() == Parameters.Code.Trim().ToUpper())
					&& (Parameters.PlaceName == null || Parameters.PlaceName == "" || x.PlaceName.Trim().ToUpper().Contains(Parameters.PlaceName)));
			}
			else if (currentUser.Role.Level == Levels.BRANCH_LEVEL.ToString())
			{
				branches = _uow.GetRepository<Branch>().GetAll(x => (x.Id == currentUser.BranchId)
					&& (Parameters.RegionId == 0 || x.RegionId == Parameters.RegionId)
					&& (Parameters.Code == null || Parameters.Code.Trim() == "" || x.Code.Trim().ToUpper() == Parameters.Code.Trim().ToUpper())
					&& (Parameters.PlaceName == null || Parameters.PlaceName == "" || x.PlaceName.Trim().ToUpper().Contains(Parameters.PlaceName)), i => i.Organization, i => i.Region).OrderByDescending(x => x.Id).Skip((Parameters.PageNumber - 1) * Parameters.DataCount).Take(Parameters.DataCount).ToList();

				totalCount = _uow.GetRepository<Branch>().Count(x => (x.Id == currentUser.BranchId)
				   && (Parameters.RegionId == 0 || x.RegionId == Parameters.RegionId)
				   && (Parameters.Code == null || Parameters.Code.Trim() == "" || x.Code.Trim().ToUpper() == Parameters.Code.Trim().ToUpper())
				   && (Parameters.PlaceName == null || Parameters.PlaceName == "" || x.PlaceName.Trim().ToUpper().Contains(Parameters.PlaceName)));
			}

			Result.Output.TotalDataCount = totalCount;
			Result.Output.PageCount = Parameters.DataCount > 0 ? (int)Math.Ceiling(((decimal)totalCount / Parameters.DataCount)) : 0;

			Result.Output.Branches = branches
					.Select(x => new BranchDto
					{
						Id = x.Id,
						Email = x.Email,
						ContactNumber = x.ContactNumber,
						PlaceAddress = x.PlaceAddress,
						Code = x.Code,
						Photo = File.Exists(Path.Combine(ConfigHelper.GetAppSetting("Photo"), x.Organization.Photo)) ?
						File.ReadAllBytes(Path.Combine(ConfigHelper.GetAppSetting("Photo"), x.Organization.Photo)) : null,
						PlaceName = x.PlaceName,
						OrganizationId = x.OrganizationId,
						OrganizationName = x.Organization.Name,
						RegionId = x.RegionId,
						RegionName = x.Region.Name,
						AddedDate = x.AddedDate,
						UpdateDate = x.UpdateDate,
					}).ToList();
		}
	}
}
