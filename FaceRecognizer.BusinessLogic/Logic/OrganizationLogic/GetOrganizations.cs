using FaceRecognizer.Common.Enums.DatabaseEnums.RoleEnums;
using FaceRecognizer.Common.Helpers;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.DTOs.OrganizationDto;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.OrganizationLogic;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FaceRecognizer.BusinessLogic.Logic.OrganizationLogic
{
	public class GetOrganizations : Logic<GetOrganizationsInput, GetOrganizationsOutput>
	{
		public GetOrganizations(IUnitofWork uow,
				string firstExecutedLogicName,
				bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		public override void DoExecute()
		{
			User currentUser = _uow.GetRepository<User>().Get(x => x.Id == Parameters.CurrentUserId, i => i.Role, i => i.Branch);
			bool isSuperAdmin = currentUser.RoleId == (int)Roles.SUPER_ADMIN ? true : false;

			List<Organization> organizations = new List<Organization>();

			if (isSuperAdmin)
			{
				organizations = _uow.GetRepository<Organization>().GetAll().ToList();
			}
			else
			{
				organizations = _uow.GetRepository<Organization>().GetAll(x => x.Id == currentUser.Branch.OrganizationId && x.IsActive).ToList();
			}

			Result.Output.Organizations = organizations.Select(x =>
					 new OrganizationsDto
					 {
						 Id = x.Id,
						 Name = x.Name,
						 Contacts = x.Contact,
						 Description = x.Description,
						 AddedDate = x.AddedDate,
						 IsActive = x.IsActive,
						 Photo = File.Exists(Path.Combine(ConfigHelper.GetAppSetting("Photo"), x.Photo)) ?
				         File.ReadAllBytes(Path.Combine(ConfigHelper.GetAppSetting("Photo"), x.Photo)) : null
					 }).ToList();
		}
	}
}
