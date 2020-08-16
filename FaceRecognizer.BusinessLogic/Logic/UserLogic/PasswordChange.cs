using FaceRecognizer.Common;
using FaceRecognizer.Common.Enums;
using FaceRecognizer.Common.Helpers;
using FaceRecognizer.Common.Resources;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.UserLogic;
using System.Linq;

namespace FaceRecognizer.BusinessLogic.Logic.UserLogic
{
	public class PasswordChange : Logic<PasswordChangeInput, PasswordChangeOutput>
	{
		public PasswordChange(IUnitofWork uow,
				string firstExecutedLogicName,
				bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		public override void DoExecute()
		{
			if (Parameters.NewPassword.Trim() == Parameters.OldPassword.Trim())
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.SAME_PASSWORD,
					ErrorMessage = Resource.SAME_PASSWORD,
					StatusCode = ErrorHttpStatus.VALIDATION
				});
				return;
			}
			User user = _uow.GetRepository<User>().Get(x => x.Id == Parameters.CurrentUserId);

			if (user == null || !user.Password.SequenceEqual(Hashing.Hash(user.Salt, Parameters.OldPassword.Trim())))
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.INCORRECT_PASSWORD,
					ErrorMessage = Resource.INCORRECT_PASSWORD,
					StatusCode = ErrorHttpStatus.VALIDATION
				});
				return;
			}

			user.Password = Hashing.Hash(user.Salt, Parameters.NewPassword);
			_uow.SaveChanges();
		}
	}
}
