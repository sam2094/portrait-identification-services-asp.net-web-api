using FaceRecognizer.Models;
using FaceRecognizer.Models.LogicParameters.ContractLogic;
using System.Threading.Tasks;

namespace FaceRecognizer.Services.Services.ContractServices
{
    public interface IContractService
    {
        LogicResult<AddContractOutput> AddContract(AddContractInput input);
        LogicResult<CheckContractOutput> CheckContract(CheckContractInput input);
        LogicResult<UpdateContractStatusOutput> UpdateContractStatus(UpdateContractStatusInput input);
        LogicResult<GetDocumentTypesOutput> GetDocumentTypes();
        LogicResult<GetOperationTypesOutput> GetOperationTypes();
        LogicResult<GetSubscriptionTypesOutput> GetSubscriptionTypes();
        LogicResult<GetTarifsOutput> GetTarifs();
        LogicResult<GetContractOutput> GetContract(GetContractInput input);
        LogicResult<GetContractsOutput> GetContracts(GetContractsInput input);
        LogicResult<DownloadContractOutput> DownloadContract(DownloadContractInput input);
        Task<LogicResult<UploadContractOutput>> UploadContractAsync(UploadContractRequestInput input);
        LogicResult<GetContractStatusesOutput> GetContractStatuses();
        LogicResult<GetCitizenshipTypesOutput> GetCitizenshipTypes();
        LogicResult<GetContractFileTypesOutput> GetContractFileTypes();
        LogicResult<GetGenderTypesOutput> GetGenderTypes();
    }
}
