using FaceRecognizer.Common;
using FaceRecognizer.Common.Enums;
using FaceRecognizer.Common.Enums.DatabaseEnums.RoleEnums;
using FaceRecognizer.Common.Resources;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.DTOs.RoleDtos;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.RoleLogic;
using System.Collections.Generic;
using System.Linq;

namespace FaceRecognizer.BusinessLogic.Logic.RoleLogic
{
	public class GetRoles : Logic<GetRolesInput, GetRolesOutput>
	{
		public GetRoles(IUnitofWork uow,
			string firstExecutedLogicName,
			bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		public override void DoExecute()
		{
			User user = _uow.GetRepository<User>().Get(x => x.Id == Parameters.CurrentUserId, i => i.Role, i => i.Branch);

			if (user == null)
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.UNAUTHORIZED,
					ErrorMessage = Resource.UNAUTHORIZED,
					StatusCode = ErrorHttpStatus.UNAUTHORIZED
				});
				return;
			}

			List<Role> roles = null;
			if (user.Role.Id == (int)Roles.SUPER_ADMIN)
			{
				roles = _uow.GetRepository<Role>().GetAll(x => (x.RoleGroup.OrganizationId == Parameters.OrganizationId || Parameters.OrganizationId == 0)
					 && (x.RoleGroupId == Parameters.RoleGroupId || Parameters.RoleGroupId == 0), i => i.RoleGroup)
					.ToList();
			}
			else
			{
				roles = _uow.GetRepository<Role>().GetAll(x => x.RoleGroup.OrganizationId == user.Branch.OrganizationId && x.RoleGroupId == Parameters.RoleGroupId, i => i.RoleGroup).ToList();
			}

			Result.Output.Roles = roles.Select(x => new GetRolesDto
			{
				Id = x.Id,
				Name = x.Name,
				Description = x.Description,
				Level = x.Level,
				RoleGroup = x.RoleGroup.Name
			}).ToList();
		}
	}
}
