using FaceRecognizer.Common;
using FaceRecognizer.Common.Enums;
using FaceRecognizer.Common.Enums.CommonEnums;
using FaceRecognizer.Common.Enums.DatabaseEnums.RoleEnums;
using FaceRecognizer.Common.Resources;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.ContractLogic;

namespace FaceRecognizer.BusinessLogic.Logic.ContractLogic
{
	public class DownloadContract : Logic<DownloadContractInput, DownloadContractOutput>
	{
		public DownloadContract(IUnitofWork uow,
				string firstExecutedLogicName,
				bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		public override void DoExecute()
		{
			User currentUser = _uow.GetRepository<User>().Get(x => x.Id == Parameters.CurrentUserId, i => i.Role, i => i.Branch);
			bool isSuperAdmin = currentUser.RoleId == (int)Roles.SUPER_ADMIN ? true : false;
			int orgId = _uow.GetRepository<User>().Get(x => x.Id == currentUser.Id, i => i.Branch).Branch.OrganizationId;

			ContractFile contractFile = null;

			if (!_uow.GetRepository<ContractFileType>()
				 .IsExist(x => x.Id == Parameters.ContractFileTypeId))
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.CONTRACT_FILE_TYPE_DOES_NOT_EXIST,
					ErrorMessage = Resource.CONTRACT_FILE_TYPE_DOES_NOT_EXIST,
					StatusCode = ErrorHttpStatus.NOT_FOUND
				});
				return;
			}

			if (isSuperAdmin)
			{
				contractFile = _uow.GetRepository<ContractFile>().Get(x => x.ContractId == Parameters.ContractId && x.ContractFileTypeId == Parameters.ContractFileTypeId);
			}
			else if (currentUser.Role.Level == Levels.ORGANIZATION_LEVEL.ToString())
			{
				contractFile = _uow.GetRepository<ContractFile>().Get(x => x.ContractId == Parameters.ContractId
				&& x.ContractFileTypeId == Parameters.ContractFileTypeId
				&& x.Contract.Branch.OrganizationId == orgId,
				   i => i.Contract.Branch);
			}
			else if (currentUser.Role.Level == Levels.BRANCH_LEVEL.ToString())
			{
				contractFile = _uow.GetRepository<ContractFile>().Get(x => x.ContractId == Parameters.ContractId
				&& x.ContractFileTypeId == Parameters.ContractFileTypeId
				&& x.Contract.BranchId == currentUser.BranchId,
					 i => i.Contract.Branch);
			}

			if (contractFile == null
				&& string.IsNullOrEmpty(contractFile?.ContractFileName)
				&& contractFile?.ContractRawData == null)
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.CONTRACT_FILE_DOES_NOT_EXIST,
					ErrorMessage = Resource.CONTRACT_FILE_DOES_NOT_EXIST,
					StatusCode = ErrorHttpStatus.NOT_FOUND
				});
				return;
			}

			Result.Output = new DownloadContractOutput
			{
				Contract = contractFile.ContractRawData
			};
		}
	}
}
