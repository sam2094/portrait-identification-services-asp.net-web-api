using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.DTOs.UserStatusesDtos;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.UserStatusLogic;
using System.Linq;

namespace FaceRecognizer.BusinessLogic.Logic.UserStatusLogic
{
	public class GetUserStatuses : Logic<GetUserStatusesInput, GetUserStatusesOutput>
	{
		public GetUserStatuses(IUnitofWork uow,
				string firstExecutedLogicName,
				bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		public override void DoExecute()
		{
			Result.Output.UserStatuses = _uow.GetRepository<UserStatus>().GetAll().Select(x => new UserStatusDto
			{
				Id = x.Id,
				Name = x.Name,
				Description = x.Description
			}).ToList();
		}
	}
}
