using FaceRecognizer.Common;
using FaceRecognizer.Common.Enums;
using FaceRecognizer.Common.Resources;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.DTOs.ClaimDtos;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.ClaimLogic;
using System.Collections.Generic;
using System.Linq;

namespace FaceRecognizer.BusinessLogic.Logic.ClaimLogic
{
	public class GetClaims : Logic<GetClaimsInput, GetClaimsOutput>
	{
		public GetClaims(IUnitofWork uow,
			string firstExecutedLogicName,
			bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		public override void DoExecute()
		{

			Role role = _uow.GetRepository<Role>().Get(x => x.Id == Parameters.RoleId || Parameters.RoleId == 0, i => i.Claims);

			if (Parameters.RoleId != 0 && role == null)
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.ROLE_DOES_NOT_EXIST,
					ErrorMessage = Resource.ROLE_DOES_NOT_EXIST,
					StatusCode = ErrorHttpStatus.NOT_FOUND
				});
				return;
			}

			List<ClaimDto> claims = _uow.GetRepository<Claim>().GetAll().Select(x => new ClaimDto
			{
				Id = x.Id,
				Name = x.Name,
				Description = x.Description,
			}).ToList();

			if (Parameters.RoleId != 0)
			{
				claims.ForEach(x => x.IsSelected = role.Claims.Any(i => i.Id == x.Id) ? true : false);
			}

			Result.Output.Claims = claims;
		}
	}
}
