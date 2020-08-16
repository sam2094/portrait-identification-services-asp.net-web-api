using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.LogicParameters.RoleLogic;
using FaceRecognizer.Common.Enums.DatabaseEnums.RoleEnums;
using FaceRecognizer.Models.DTOs.RoleDtos;
using FaceRecognizer.Models.Entities;
using System.Linq;

namespace FaceRecognizer.BusinessLogic.Logic.RoleLogic
{
	public class GetRoleGroups : Logic<GetRoleGroupsInput, GetRoleGroupsOutput>
	{
		public GetRoleGroups(IUnitofWork uow,
			string firstExecutedLogicName,
			bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		public override void DoExecute()
		{
			User currentUser = _uow.GetRepository<User>().Get(x => x.Id == Parameters.CurrentUserId, i => i.Role, i => i.Branch);

			bool isSuperAdmin = currentUser.RoleId == (int)Roles.SUPER_ADMIN ? true : false;

			if (isSuperAdmin)
			{
				Result.Output.RoleGroups = _uow.GetRepository<RoleGroup>().GetAll(i => i.Organization).Select(x => new GetRoleGroupsDto
				{
					Id = x.Id,
					Name = x.Name,
					OrganizationId = x.OrganizationId,
					OrganizationName = x.Organization.Name
				}).ToList();
			}
			else
			{
				Result.Output.RoleGroups = _uow.GetRepository<RoleGroup>().GetAll(x => x.OrganizationId == currentUser.Branch.OrganizationId, i => i.Organization).Select(x => new GetRoleGroupsDto
				{
					Id = x.Id,
					Name = x.Name,
					OrganizationId = x.OrganizationId,
					OrganizationName = x.Organization.Name
				}).ToList();
			}
		}
	}
}
