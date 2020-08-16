using FaceRecognizer.Models.DTOs.ContractStatusesDto;
using System.Collections.Generic;

namespace FaceRecognizer.Models.LogicParameters.ContractLogic
{
	public class GetContractStatusesInput : LogicInput { }

	public class GetContractStatusesOutput : LogicOutput
	{
		public List<ContractStatusDto> ContractStatuses { get; set; }
	}
}
