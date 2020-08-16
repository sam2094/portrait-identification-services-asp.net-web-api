using FaceRecognizer.Models.DTOs.UserStatusesDtos;
using System.Collections.Generic;

namespace FaceRecognizer.Models.LogicParameters.UserStatusLogic
{
	public class GetUserStatusesInput : LogicInput { }

	public class GetUserStatusesOutput : LogicOutput
	{
		public List<UserStatusDto> UserStatuses { get; set; }
	}
}
