using FaceRecognizer.Common.Enums.CommonEnums;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.DTOs.RoleDtos;
using FaceRecognizer.Models.LogicParameters.RoleLogic;
using System;
using System.Linq;

namespace FaceRecognizer.BusinessLogic.Logic.RoleLogic
{
	public class GetRoleLevels : Logic<GetRoleLevelInput, GetRoleLevelOutput>
	{
		public GetRoleLevels(IUnitofWork uow,
				string firstExecutedLogicName,
				bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		public override void DoExecute()
		{
			Result.Output.RoleLevels = Enum.GetValues(typeof(Levels)).Cast<Levels>().Select(x => new RoleLevelDto
			{
				Name = x.ToString()
			}).ToList();
		}
	}
}
