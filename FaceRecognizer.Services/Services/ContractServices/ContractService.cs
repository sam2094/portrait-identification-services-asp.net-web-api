using FaceRecognizer.BusinessLogic.Logic.ContractLogic;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models;
using FaceRecognizer.Models.LogicParameters.ContractLogic;
using System.Threading.Tasks;

namespace FaceRecognizer.Services.Services.ContractServices
{
	public class ContractService : IContractService
	{
		private readonly IUnitofWork _uow;
		public ContractService(IUnitofWork uow) => _uow = uow;

		public LogicResult<AddContractOutput> AddContract(AddContractInput input)
			=> new AddContract(_uow, nameof(AddContract)).Execute(parameters: input);

		public LogicResult<CheckContractOutput> CheckContract(CheckContractInput input)
			=> new CheckContract(_uow, nameof(CheckContract)).Execute(parameters: input);

		public LogicResult<UpdateContractStatusOutput> UpdateContractStatus(UpdateContractStatusInput input)
			=> new UpdateContractStatus(_uow, nameof(UpdateContractStatus)).Execute(parameters: input);

		public LogicResult<GetDocumentTypesOutput> GetDocumentTypes()
			=> new GetDocumentTypes(_uow, nameof(GetDocumentTypes)).Execute();

		public LogicResult<GetOperationTypesOutput> GetOperationTypes()
			=> new GetOperationTypes(_uow, nameof(GetOperationTypes)).Execute();

		public LogicResult<GetSubscriptionTypesOutput> GetSubscriptionTypes()
			=> new GetSubscriptionTypes(_uow, nameof(GetSubscriptionTypes)).Execute();

		public LogicResult<GetTarifsOutput> GetTarifs()
			=> new GetTarifs(_uow, nameof(GetTarifs)).Execute();

		public LogicResult<GetContractOutput> GetContract(GetContractInput input)
			=> new GetContract(_uow, nameof(GetContract)).Execute(parameters: input);

		public LogicResult<GetContractsOutput> GetContracts(GetContractsInput input)
			=> new GetContracts(_uow, nameof(GetContracts)).Execute(parameters: input);

		public LogicResult<DownloadContractOutput> DownloadContract(DownloadContractInput input)
			=> new DownloadContract(_uow, nameof(DownloadContract)).Execute(parameters: input);

		public async Task<LogicResult<UploadContractOutput>> UploadContractAsync(UploadContractRequestInput input)
			=> await new UploadContract(_uow, nameof(UploadContractAsync)).ExecuteAsync(parameters: input);

		public LogicResult<GetContractStatusesOutput> GetContractStatuses()
			=> new GetContractStatuses(_uow, nameof(GetContractStatuses)).Execute();

		public LogicResult<GetCitizenshipTypesOutput> GetCitizenshipTypes()
		  => new GetCitizenshipTypes(_uow, nameof(GetCitizenshipTypes)).Execute();

		public LogicResult<GetContractFileTypesOutput> GetContractFileTypes()
		 => new GetContractFileTypes(_uow, nameof(GetContractFileTypes)).Execute();

		public LogicResult<GetGenderTypesOutput> GetGenderTypes()
		 => new GetGenderTypes(_uow, nameof(GetGenderTypes)).Execute();
	}
}
