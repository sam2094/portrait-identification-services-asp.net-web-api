using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.DTOs.OperationTypesDto;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.ContractLogic;
using System.Linq;

namespace FaceRecognizer.BusinessLogic.Logic.ContractLogic
{
	public class GetOperationTypes : Logic<GetOperationTypesInput, GetOperationTypesOutput>
	{
		public GetOperationTypes(IUnitofWork uow,
				string firstExecutedLogicName,
				bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		public override void DoExecute()
		{
			Result.Output.OperationTypes = _uow.GetRepository<OperationType>().GetAll().Select(x => new OperationTypeDto
			{
				Id = x.Id,
				Name = x.Name,
				Description = x.Description
			}).ToList();
		}
	}
}
