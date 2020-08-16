using FaceRecognizer.Common;
using FaceRecognizer.Common.Enums;
using FaceRecognizer.Common.Enums.DatabaseEnums;
using FaceRecognizer.Common.Resources;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.ContractLogic;
using System;
using System.Linq;

namespace FaceRecognizer.BusinessLogic.Logic.ContractLogic
{
	public class CheckContract : Logic<CheckContractInput, CheckContractOutput>
	{
		public CheckContract(IUnitofWork uow,
			string firstExecutedLogicName,
			bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		public override void DoExecute()
		{
			if (!_uow.GetRepository<DocumentType>().IsExist(x => x.Id == Parameters.DocumentTypeId))
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.DOCUMENT_TYPE_IS_NOT_EXIST,
					ErrorMessage = Resource.DOCUMENT_TYPE_IS_NOT_EXIST,
					StatusCode = ErrorHttpStatus.NOT_FOUND
				});
				return;
			}

			DocumentInformation documentInformation = _uow.GetRepository<DocumentInformation>().Get(x => x.DocumentPin == Parameters.DocumentPin
			&& x.DocumentTypeId == Parameters.DocumentTypeId);

			if (documentInformation == null)
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.PIN_NOT_EXIST_OR_EXPIRED,
					ErrorMessage = Resource.PIN_NOT_EXIST_OR_EXPIRED,
					StatusCode = ErrorHttpStatus.FORBIDDEN
				});
				return;
			}
			DateTime date = DateTime.Now.AddMinutes(-10);
			Contract contract = _uow.GetRepository<Contract>().GetAll(x => x.DocumentInformationId == documentInformation.Id
					 && x.PhoneNumber == Parameters.PhoneNumber.Trim()
					 && x.ContractStatusId == (byte)ContractStatuses.NEW
					 && x.AddedDate >= date).LastOrDefault();

			if (contract == null)
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.CONTRACT_IS_NOT_EXIST,
					ErrorMessage = Resource.CONTRACT_IS_NOT_EXIST,
					StatusCode = ErrorHttpStatus.NOT_FOUND
				});
				return;
			}

			Result.Output = new CheckContractOutput
			{
				ContractId = contract.Id
			};
		}
	}
}
