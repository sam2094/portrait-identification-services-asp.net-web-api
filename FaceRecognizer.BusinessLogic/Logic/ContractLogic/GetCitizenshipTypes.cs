using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.DTOs.CitizenshipTypes;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.ContractLogic;
using System.Linq;

namespace FaceRecognizer.BusinessLogic.Logic.ContractLogic
{
	public class GetCitizenshipTypes : Logic<GetCitizenshipTypesInput, GetCitizenshipTypesOutput>
	{
		public GetCitizenshipTypes(IUnitofWork uow,
				string firstExecutedLogicName,
				bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		public override void DoExecute()
		{
			Result.Output.CitizenshipTypes = _uow.GetRepository<Citizenship>().GetAll().Select(x => new CitizenshipTypeDto
			{
				Id = x.Id,
				Name = x.Name,
				Description = x.Description,
				IsActive = x.IsActive
			}).ToList();
		}
	}
}
