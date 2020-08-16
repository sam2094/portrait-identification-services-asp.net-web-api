using FaceRecognizer.Common.Enums.DatabaseEnums.ClaimEnums;
using FaceRecognizer.Models.LogicParameters.ClaimLogic;
using FaceRecognizer.Services.Services.ClaimService;
using FaceRecognizer.Web.Extensions;
using FaceRecognizer.Web.Filters;
using FaceRecognizer.Web.Routing;
using System.Web.Http;

namespace FaceRecognizer.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiVersion1RoutePrefix("claim")]
    public class ClaimController : BaseController
    {
        private readonly IClaimService _claimService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="claimService"></param>
        public ClaimController(IClaimService claimService) => _claimService = claimService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("get")]
        [Auth(Claims.CAN_GET_CLAIMS)]
        public IHttpActionResult GetClaims(GetClaimsInput input) => Result(_claimService.GetClaims(input.Authorized()));
    }
}