using FaceRecognizer.Common.Enums.DatabaseEnums.ClaimEnums;
using FaceRecognizer.Services.Services.RegionService;
using FaceRecognizer.Web.Filters;
using FaceRecognizer.Web.Routing;
using System.Web.Http;

namespace FaceRecognizer.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiVersion1RoutePrefix("region")]
    public class RegionController : BaseController
    {
        private readonly IRegionService _regionService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="regionService"></param>
        public RegionController(IRegionService regionService) => _regionService = regionService;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("get")]
        [Auth(Claims.CAN_GET_REGIONS)]
        public IHttpActionResult GetOrganisations() => Result(_regionService.GetRegions());
    }
}