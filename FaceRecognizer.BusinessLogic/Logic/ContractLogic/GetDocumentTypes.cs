using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.DTOs.DocumentTypesDto;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.ContractLogic;
using System.Linq;

namespace FaceRecognizer.BusinessLogic.Logic.ContractLogic
{
	public class GetDocumentTypes : Logic<GetDocumentTypesInput, GetDocumentTypesOutput>
	{
		public GetDocumentTypes(IUnitofWork uow,
				string firstExecutedLogicName,
				bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		public override void DoExecute()
		{
			Result.Output.DocumentTypes = _uow.GetRepository<DocumentType>().GetAll().Select(x => new DocumentTypeDto
			{
				Id = x.Id,
				Name = x.Name,
				Description = x.Description
			}).ToList();
		}
	}
}