using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.DTOs.ContractStatusesDto;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.ContractLogic;
using System.Linq;

namespace FaceRecognizer.BusinessLogic.Logic.ContractLogic
{
	public class GetContractStatuses : Logic<GetContractStatusesInput, GetContractStatusesOutput>
	{
		public GetContractStatuses(IUnitofWork uow,
				string firstExecutedLogicName,
				bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		public override void DoExecute()
		{
			Result.Output.ContractStatuses = _uow.GetRepository<ContractStatus>().GetAll().Select(x => new ContractStatusDto
			{
				Id = x.Id,
				Name = x.Name,
				Description = x.Description
			}).ToList();
		}
	}
}
