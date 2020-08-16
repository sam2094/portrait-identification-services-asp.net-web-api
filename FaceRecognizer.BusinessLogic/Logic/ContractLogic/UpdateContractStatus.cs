using FaceRecognizer.Common;
using FaceRecognizer.Common.Enums;
using FaceRecognizer.Common.Resources;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.ContractLogic;

namespace FaceRecognizer.BusinessLogic.Logic.ContractLogic
{
	public class UpdateContractStatus : Logic<UpdateContractStatusInput, UpdateContractStatusOutput>
	{
		public UpdateContractStatus(IUnitofWork uow,
				string firstExecutedLogicName,
				bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		public override void DoExecute()
		{
			Contract contract = _uow.GetRepository<Contract>().Get(x => x.Id == Parameters.ContractId);

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

			if (!_uow.GetRepository<ContractStatus>()
				 .IsExist(x => x.Id == Parameters.ContractStatusId))
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.CONTRACT_STATUS_DOES_NOT_EXİST,
					ErrorMessage = Resource.CONTRACT_STATUS_DOES_NOT_EXİST,
					StatusCode = ErrorHttpStatus.NOT_FOUND
				});
				return;
			}

			contract.ContractStatusId = Parameters.ContractStatusId;
			_uow.SaveChanges();
		}
	}
}
