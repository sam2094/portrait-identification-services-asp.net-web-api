using FaceRecognizer.Models.DTOs.ContractDtos;
using FaceRecognizer.Models.Entities;
using System.Collections.Generic;

namespace FaceRecognizer.Models.LogicParameters.ContractLogic
{
	public class GetGenderTypesInput : LogicInput
	{
	}

	public class GetGenderTypesOutput : LogicOutput
	{
		public List<GenderDto> GenderTypes { get; set; }
	}
}
