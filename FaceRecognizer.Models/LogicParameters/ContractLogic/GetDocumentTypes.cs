using FaceRecognizer.Models.DTOs.DocumentTypesDto;
using System.Collections.Generic;

namespace FaceRecognizer.Models.LogicParameters.ContractLogic
{
	public class GetDocumentTypesInput : LogicInput { }

	public class GetDocumentTypesOutput : LogicOutput
	{
		public List<DocumentTypeDto> DocumentTypes { get; set; }
	}
}
