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
using System.Linq;

namespace FaceRecognizer.BusinessLogic.Logic.UserLogic
{
	public class LoginCheck : Logic<LoginCheckInput, LoginCheckOutput>
	{
		public LoginCheck(IUnitofWork uow,
				string firstExecutedLogicName,
				bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		public override void DoExecute()
		{
			User user = _uow.GetRepository<User>().Get(
				x => x.Username.ToUpper() == Parameters.Username.Trim().ToUpper()
				&& x.UserStatusId == (byte)UserStatuses.ACTIVE);

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

			int pin = PinCache.Instance.GetPin();
			PinCache.Instance.Add(user.Id, new PinSessionInfo { Pin = pin, ExpireDate = DateTime.Now.AddMinutes(5) });

			using (Sms sms = new Sms())
			{
				sms.Send(user.Contact, string.Format(ConfigHelper.GetAppSetting("PinSms"), pin));
			}
		}
	}
}
