using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.DTOs.FileTypeDto;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.ContractLogic;
using System.Linq;

namespace FaceRecognizer.BusinessLogic.Logic.ContractLogic
{
	public class GetContractFileTypes : Logic<GetContractFileTypesInput, GetContractFileTypesOutput>
	{
		public GetContractFileTypes(IUnitofWork uow,
				string firstExecutedLogicName,
				bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		public override void DoExecute()
		{
			Result.Output.ContractFileTypes = _uow.GetRepository<ContractFileType>().GetAll().Select(x => new ContractFileTypeDto
			{
				Id = x.Id,
				Name = x.Name,
				Description = x.Description
			}).ToList();
		}
	}
}
