using FaceRecognizer.Models.DTOs.CitizenshipTypes;
using System.Collections.Generic;

namespace FaceRecognizer.Models.LogicParameters.ContractLogic
{
	public class GetCitizenshipTypesInput : LogicInput
	{
	}

	public class GetCitizenshipTypesOutput : LogicOutput
	{
		public List<CitizenshipTypeDto> CitizenshipTypes { get; set; }
	}
}
