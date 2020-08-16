using FaceRecognizer.Models.DTOs.RegionsDto;
using System.Collections.Generic;

namespace FaceRecognizer.Models.LogicParameters.RegionLogic
{
	public class GetRegionsInput : LogicInput { }

	public class GetRegionsOutput : LogicOutput
	{
		public List<RegionDto> Regions { get; set; }
	}
}
