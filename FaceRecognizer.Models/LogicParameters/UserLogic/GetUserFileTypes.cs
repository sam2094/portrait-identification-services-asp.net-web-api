using FaceRecognizer.Models.DTOs.FileTypeDto;
using System.Collections.Generic;

namespace FaceRecognizer.Models.LogicParameters.UserLogic
{
	public class GetUserFileTypesInput : LogicInput
	{
	}

	public class GetUserFileTypesOutput : LogicOutput
	{
		public List<UserFileTypeDto> UserFileTypes { get; set; }
	}
}
