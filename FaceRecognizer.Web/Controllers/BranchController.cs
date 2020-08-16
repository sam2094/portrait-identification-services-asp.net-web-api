using FaceRecognizer.Common.Enums.DatabaseEnums.ClaimEnums;
using FaceRecognizer.Models.LogicParameters.BranchLogic;
using FaceRecognizer.Services.Services.BranchServices;
using FaceRecognizer.Web.Extensions;
using FaceRecognizer.Web.Filters;
using FaceRecognizer.Web.Routing;
using System.Web.Http;

namespace FaceRecognizer.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiVersion1RoutePrefix("branch")]
    public class BranchController : BaseController
    {
        private readonly IBranchService _branchService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="branchService"></param>
        public BranchController(IBranchService branchService) => _branchService = branchService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("getall")]
        [Auth(Claims.CAN_GET_ALL_BRANCH)]
        public IHttpActionResult GetBranches(GetBranchesInput input) => Result(_branchService.GetBranches(input.Authorized()));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add")]
        [Auth(Claims.CAN_ADD_BRANCH)]
        public IHttpActionResult AddBranch(AddBranchInput input) => Result(_branchService.AddBranch(input.Authorized()));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("edit")]
        [Auth(Claims.CAN_EDIT_BRANCH)]
        public IHttpActionResult EditBranch(EditBranchInput input) => Result(_branchService.EditBranch(input.Authorized()));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("getbyid")]
        [Auth(Claims.CAN_GET_BRANCH_BY_ID)]
        public IHttpActionResult GetBranchById(GetBranchByIdInput input) => Result(_branchService.GetBranchById(input.Authorized()));
    }
}