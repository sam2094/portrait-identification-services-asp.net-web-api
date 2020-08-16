using FaceRecognizer.Common.Enums.DatabaseEnums.ClaimEnums;
using FaceRecognizer.Models.LogicParameters.OrganizationLogic;
using FaceRecognizer.Services.Services.OrganizationServices;
using FaceRecognizer.Web.Extensions;
using FaceRecognizer.Web.Filters;
using FaceRecognizer.Web.Routing;
using System.Web.Http;

namespace FaceRecognizer.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiVersion1RoutePrefix("organization")]
    public class OrganizationController : BaseController
    {
        private readonly IOrganizationService _organizationService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="organizationService"></param>

        public OrganizationController(IOrganizationService organizationService) => _organizationService = organizationService;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("get")]
        [Auth(Claims.CAN_GET_ORGANIZATIONS)]
        public IHttpActionResult GetOrganisations(GetOrganizationsInput input) => Result(_organizationService.GetOrganizations(input.Authorized()));

		/// <summary>
		///
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		[Route("add")]
		[Auth(Claims.CAN_ADD_ORGANIZATION)]
		public IHttpActionResult AddOrganization(AddOrganizationInput input) => Result(_organizationService.AddOrganization(input.Authorized()));

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		[Route("edit")]
		[Auth(Claims.CAN_EDIT_ORGANIZATION)]
		public IHttpActionResult EditOrganization(EditOrganizationInput input) => Result(_organizationService.EditOrganization(input.Authorized()));
	}
}