using FaceRecognizer.Models.DTOs.OrganizationDto;
using System.Collections.Generic;

namespace FaceRecognizer.Models.LogicParameters.OrganizationLogic
{
	public class GetOrganizationsInput : LogicInput { }
	public class GetOrganizationsOutput : LogicOutput
	{
		public List<OrganizationsDto> Organizations { get; set; }
	}
}
