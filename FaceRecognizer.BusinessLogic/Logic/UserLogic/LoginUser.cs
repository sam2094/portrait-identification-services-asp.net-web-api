using FaceRecognizer.BusinessLogic.Cache;
using FaceRecognizer.BusinessLogic.Logic.Cache;
using FaceRecognizer.Common;
using FaceRecognizer.Common.Enums;
using FaceRecognizer.Common.Enums.DatabaseEnums;
using FaceRecognizer.Common.Helpers;
using FaceRecognizer.Common.Resources;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.UserLogic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FaceRecognizer.BusinessLogic.Logic.UserLogic
{
	public class LoginUser : Logic<LoginUserInput, LoginUserOutput>
	{
		public LoginUser(IUnitofWork uow,
				string firstExecutedLogicName,
				bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		public override void DoExecute()
		{
			User user = _uow.GetRepository<User>().Get(
				x => x.Username.ToLower() == Parameters.Username.Trim().ToLower()
				&& x.UserStatusId == (byte)UserStatuses.ACTIVE, i => i.Tokens, i => i.Role.Claims, i => i.Role.RoleGroup);

			if (user == null || !user.Password.SequenceEqual(Hashing.Hash(user.Salt, Parameters.Password)))
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.USERNAME_AND_PASSWORD_DOESNT_MATCH,
					ErrorMessage = Resource.USERNAME_AND_PASSWORD_DOESNT_MATCH,
					StatusCode = ErrorHttpStatus.FORBIDDEN
				});
				return;
			}

			user.Tokens.Where(t => t.TokenStatusId == (byte)TokenStatuses.ACTIVE).ForEach(t => t.TokenStatusId = (byte)TokenStatuses.BLOCKED);
			// _uow.SaveChanges();

			string token = TokenCache.Instance.GetToken();
			DateTime date = DateTime.Now;
			user.Tokens.Add(new Token
			{
				Value = token,
				TokenStatusId = (byte)TokenStatuses.ACTIVE,
				AddedDate = date,
				ExpireDate = date.AddDays(5)
			});

			_uow.SaveChanges();

			TokenCache.Instance.Add(token, new TokenSessionInfo { UserId = user.Id, ExpireDate = date.AddDays(5), Claims = user.Role.Claims.ToList() });

			Result.Output = new LoginUserOutput
			{
				Token = token,
				UserId = user.Id,
				UserRoleGroup = user.Role.RoleGroup.Name
			};
		}
	}
}
