using System;
using System.Linq;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.LogicParameters.ContractLogic;
using FaceRecognizer.Models.DTOs.ContractDtos;

namespace FaceRecognizer.BusinessLogic.Logic.ContractLogic
{
	public class GetGenderTypes : Logic<GetGenderTypesInput, GetGenderTypesOutput>
	{
		public GetGenderTypes(IUnitofWork uow,
				string firstExecutedLogicName,
				bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		public override void DoExecute()
		{
			Result.Output.GenderTypes = Enum.GetValues(typeof(GenderTypes)).Cast<GenderTypes>().Select(x => new GenderDto
			{
				Name = x.ToString()
				
			}).ToList();
		}
	}
}
