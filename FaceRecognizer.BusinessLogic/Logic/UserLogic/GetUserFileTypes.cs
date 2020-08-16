using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.DTOs.FileTypeDto;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.UserLogic;
using System.Linq;

namespace FaceRecognizer.BusinessLogic.Logic.UserLogic
{
	public class GetUserFileTypes : Logic<GetUserFileTypesInput, GetUserFileTypesOutput>
	{
		public GetUserFileTypes(IUnitofWork uow,
				string firstExecutedLogicName,
				bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		public override void DoExecute()
		{
			Result.Output.UserFileTypes = _uow.GetRepository<UserFileType>().GetAll().Select(x => new UserFileTypeDto
			{
				Id = x.Id,
				Name = x.Name,
				Description = x.Description
			}).ToList();
		}
	}
}
