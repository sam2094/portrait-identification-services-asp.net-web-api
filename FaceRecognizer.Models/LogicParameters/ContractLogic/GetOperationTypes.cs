using FaceRecognizer.Models.DTOs.OperationTypesDto;
using System.Collections.Generic;

namespace FaceRecognizer.Models.LogicParameters.ContractLogic
{
	public class GetOperationTypesInput : LogicInput { }

	public class GetOperationTypesOutput : LogicOutput
	{
		public List<OperationTypeDto> OperationTypes { get; set; }
	}
}
