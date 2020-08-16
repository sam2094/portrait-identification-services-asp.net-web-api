using FaceRecognizer.Models.DTOs.BranchDtos;
using System.Collections.Generic;

namespace FaceRecognizer.Models.LogicParameters.BranchLogic
{
	public class GetBranchesInput : LogicInput
	{
		public int OrganizationId { get; set; }
		public byte RegionId { get; set; }
		public string Code { get; set; }
		public string PlaceName { get; set; }
		public int PageNumber { get; set; }
		public int DataCount { get; set; }
	}

	public class GetBranchesOutput : LogicOutput
	{
		public List<BranchDto> Branches { get; set; }
		public int TotalDataCount { get; set; }
		public int PageCount { get; set; }

	}
}
