using FaceRecognizer.Models.DTOs.ContractDtos.GetContract;

namespace FaceRecognizer.Models.LogicParameters.ContractLogic
{
	public class GetContractInput : LogicInput
	{
		public int ContractId { get; set; }
	}

	public class GetContractOutput : LogicOutput
	{
		public GetContractDto Contract { get; set; }
	}
}
