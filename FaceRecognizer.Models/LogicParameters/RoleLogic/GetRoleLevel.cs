using FaceRecognizer.Models.DTOs.RoleDtos;
using System.Collections.Generic;

namespace FaceRecognizer.Models.LogicParameters.RoleLogic
{
	public class GetRoleLevelInput : LogicInput
	{
	}
	public class GetRoleLevelOutput : LogicOutput
	{
		public List<RoleLevelDto> RoleLevels { get; set; }
	}
}
