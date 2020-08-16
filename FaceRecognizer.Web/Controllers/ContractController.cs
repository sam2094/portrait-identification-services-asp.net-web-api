using System.Threading.Tasks;
using System.Web.Http;
using FaceRecognizer.Common.Enums.DatabaseEnums.ClaimEnums;
using FaceRecognizer.Models.LogicParameters.ContractLogic;
using FaceRecognizer.Services.Services.ContractServices;
using FaceRecognizer.Web.Extensions;
using FaceRecognizer.Web.Filters;
using FaceRecognizer.Web.Routing;

namespace FaceRecognizer.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiVersion1RoutePrefix("contract")]
	public class ContractController : BaseController
	{
		private readonly IContractService _contractService;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="contractService"></param>
		public ContractController(IContractService contractService) => _contractService = contractService;


		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("get")]
		[Auth(Claims.CAN_GET_CONTRACT)]
		public IHttpActionResult Get(GetContractInput input) => Result(_contractService.GetContract(input.Authorized()));

        /// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost]
        [Route("getall")]
        [Auth(Claims.CAN_GET_CONTRACTS)]
        public IHttpActionResult GetAll(GetContractsInput input) => Result(_contractService.GetContracts(input.Authorized()));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
		[Route("add")]
		[Auth(Claims.CAN_ADD_CONTRACT)]
		public IHttpActionResult Add(AddContractInput input) => Result(_contractService.AddContract(input.Authorized()));

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("check")]
		[Auth(Claims.CAN_CHECK_CONTRACT)]
		public IHttpActionResult Check(CheckContractInput input) => Result(_contractService.CheckContract(input.Authorized()));

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("updatestatus")]
		[Auth(Claims.CAN_UPDATE_CONTRACT_STATUS)]
		public IHttpActionResult UpdateStatus(UpdateContractStatusInput input)
			=> Result(_contractService.UpdateContractStatus(input.Authorized()));

		/// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		[HttpGet]
		[Route("getdocumenttypes")]
		[Auth(Claims.CAN_GET_DOCUMENT_TYPES)]
		public IHttpActionResult GetDocumentTypes()
			=> Result(_contractService.GetDocumentTypes());

		/// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		[HttpGet]
		[Route("getoperationtypes")]
		[Auth(Claims.CAN_GET_OPERATION_TYPES)]
		public IHttpActionResult GetOperationTypes()
			=> Result(_contractService.GetOperationTypes());

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		[HttpGet]
        [Route("getsubscriptiontypes")]
        [Auth(Claims.CAN_GET_SUBSCRIPTION_TYPES)]
        public IHttpActionResult GetSubscriptionTypes()
            => Result(_contractService.GetSubscriptionTypes());

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		[HttpGet]
        [Route("gettarifs")]
        [Auth(Claims.CAN_GET_TARIFS)]
        public IHttpActionResult GetTarifs()
            => Result(_contractService.GetTarifs());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
		[Route("downloadcontract")]
		[Auth(Claims.CAN_DOWNLOAD_CONTRACT)]
		public IHttpActionResult DownloadContract(DownloadContractInput input)
			=> Result(_contractService.DownloadContract(input.Authorized()));

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		[Route("uploadcontract")]
		[Auth(Claims.CAN_UPLOAD_CONTRACT)]
		public async Task<IHttpActionResult> UploadContract()
		{
			return Result(await _contractService.UploadContractAsync(new UploadContractRequestInput
			{
			  Request = Request
			}.Authorized()));
		}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		[HttpGet]
        [Route("getcontractstatuses")]
        [Auth(Claims.CAN_GET_CONTRACT_STATUSES)]
        public IHttpActionResult GetContractStatuses()
            => Result(_contractService.GetContractStatuses());

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[Route("getcitizenshiptypes")]
		[Auth(Claims.CAN_GET_CITIZENSHIP_TYPES)]
		public IHttpActionResult GetCitizenshipTypes()
			=> Result(_contractService.GetCitizenshipTypes());


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[Route("getcontractfiletypes")]
		[Auth(Claims.CAN_GET_CONTRACT_FILE_TYPES)]
		public IHttpActionResult GetContractFileTypes()
			=> Result(_contractService.GetContractFileTypes());

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[Route("getgendertypes")]
		public IHttpActionResult GetGenderTypes()
			=> Result(_contractService.GetGenderTypes());
	}
}
