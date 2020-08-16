using FaceRecognizer.Models.DTOs.ContractDtos;
using System.Collections.Generic;

namespace FaceRecognizer.Models.LogicParameters.ContractLogic
{
	public class GetTarifsInput : LogicInput { }

	public class GetTarifsOutput : LogicOutput
	{
		public List<GetTarifsDto> Tarifs { get; set; }
	}
}
