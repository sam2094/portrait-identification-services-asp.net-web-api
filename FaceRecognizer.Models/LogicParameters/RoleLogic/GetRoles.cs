using FaceRecognizer.Models.DTOs.RoleDtos;
using System.Collections.Generic;

namespace FaceRecognizer.Models.LogicParameters.RoleLogic
{
	public class GetRolesInput : LogicInput
	{
		public int OrganizationId { get; set; }
		public int RoleGroupId { get; set; }
	}

	public class GetRolesOutput : LogicOutput
	{
		public List<GetRolesDto> Roles { get; set; }
	}
}
