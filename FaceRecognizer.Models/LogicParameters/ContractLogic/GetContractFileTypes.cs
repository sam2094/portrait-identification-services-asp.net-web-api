using FaceRecognizer.Models.DTOs.FileTypeDto;
using System.Collections.Generic;

namespace FaceRecognizer.Models.LogicParameters.ContractLogic
{
	public class GetContractFileTypesInput : LogicInput
	{
	}

	public class GetContractFileTypesOutput : LogicOutput
	{
		public List<ContractFileTypeDto> ContractFileTypes { get; set; }
	}
}
