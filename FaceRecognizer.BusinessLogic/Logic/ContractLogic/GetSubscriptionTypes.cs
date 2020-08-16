using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.DTOs.SubscriptionTypesDto;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.ContractLogic;
using System.Linq;

namespace FaceRecognizer.BusinessLogic.Logic.ContractLogic
{
	public class GetSubscriptionTypes : Logic<GetSubscriptionTypesInput, GetSubscriptionTypesOutput>
	{
		public GetSubscriptionTypes(IUnitofWork uow,
				string firstExecutedLogicName,
				bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		public override void DoExecute()
		{
			Result.Output.SubscriptionTypes = _uow.GetRepository<SubscriptionType>().GetAll().Select(x => new SubscriptionTypeDto
			{
				Id = x.Id,
				Name = x.Name,
				Description = x.Description,
				IsActive = x.IsActive
			}).ToList();
		}
	}
}
