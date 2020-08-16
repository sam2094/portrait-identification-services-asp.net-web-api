using FaceRecognizer.Models.DTOs.BranchDtos;

namespace FaceRecognizer.Models.LogicParameters.BranchLogic
{
	public class GetBranchByIdInput : LogicInput
	{
		public int BranchId { get; set; }
	}

	public class GetBranchByIdOutput : LogicOutput
	{
		public BranchDto BranchDto { get; set; }
	}
}