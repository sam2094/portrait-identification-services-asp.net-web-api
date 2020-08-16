using FaceRecognizer.Models.DTOs.ClaimDtos;
using System.Collections.Generic;

namespace FaceRecognizer.Models.LogicParameters.ClaimLogic
{
	public class GetClaimsInput : LogicInput
	{
		public int RoleId { get; set; }
	}
	public class GetClaimsOutput : LogicOutput
	{
		public List<ClaimDto> Claims { get; set; }
	}
}
