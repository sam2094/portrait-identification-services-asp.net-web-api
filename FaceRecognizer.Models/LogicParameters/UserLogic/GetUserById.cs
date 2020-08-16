using FaceRecognizer.Models.DTOs.UserDtos;
using System;

namespace FaceRecognizer.Models.LogicParameters.UserLogic
{
	public class GetUserByIdInput : LogicInput
	{
		public int UserId { get; set; }
	}

	public class GetUserByIdOutput : LogicOutput
	{
		public GetUserByIdDto User { get; set; }
	}
}
