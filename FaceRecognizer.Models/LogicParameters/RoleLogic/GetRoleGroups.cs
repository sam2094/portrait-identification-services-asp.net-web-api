using FaceRecognizer.Models.DTOs.RoleDtos;
using System.Collections.Generic;

namespace FaceRecognizer.Models.LogicParameters.RoleLogic
{
	public class GetRoleGroupsInput : LogicInput
	{

	}
	public class GetRoleGroupsOutput : LogicOutput
	{
		public List<GetRoleGroupsDto> RoleGroups { get; set; }
	}
}
