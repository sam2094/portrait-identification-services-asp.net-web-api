using FaceRecognizer.Models.DTOs.SubscriptionTypesDto;
using System.Collections.Generic;

namespace FaceRecognizer.Models.LogicParameters.ContractLogic
{
	public class GetSubscriptionTypesInput : LogicInput { }

	public class GetSubscriptionTypesOutput : LogicOutput
	{
		public List<SubscriptionTypeDto> SubscriptionTypes { get; set; }
	}
}
