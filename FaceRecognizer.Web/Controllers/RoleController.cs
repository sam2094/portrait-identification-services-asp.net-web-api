using FaceRecognizer.Common.Enums.DatabaseEnums.ClaimEnums;
using FaceRecognizer.Models.LogicParameters.RoleLogic;
using FaceRecognizer.Services.Services.RoleServices;
using FaceRecognizer.Web.Extensions;
using FaceRecognizer.Web.Filters;
using FaceRecognizer.Web.Routing;
using System.Web.Http;

namespace FaceRecognizer.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiVersion1RoutePrefix("role")]
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleService"></param>
        public RoleController(IRoleService roleService) => _roleService = roleService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("get")]
        [Auth(Claims.CAN_GET_ROLES)]
        public IHttpActionResult GetRoles(GetRolesInput input) => Result(_roleService.GetRoles(input.Authorized()));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add")]
        [Auth(Claims.CAN_ADD_ROLE)]
        public IHttpActionResult AddRole(AddRoleInput input) => Result(_roleService.AddRole(input.Authorized()));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("edit")]
        [Auth(Claims.CAN_EDIT_ROLE)]
        public IHttpActionResult EditRole(EditRoleInput input) => Result(_roleService.EditRole(input.Authorized()));

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("getrolegroups")]
		[Auth(Claims.CAN_GET_ROLE_GROUPS)]
		public IHttpActionResult GetRoleGroups(GetRoleGroupsInput input) => Result(_roleService.GetRoleGroups(input.Authorized()));

		/// <summary>
		/// Using CAN_ADD_ROLE claim because Role Levels are needed only in AddRole API
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("getrolelevels")]
		[Auth(Claims.CAN_ADD_ROLE)]
		public IHttpActionResult GetRoleLevels(GetRoleLevelInput input) => Result(_roleService.GetRoleLevels(input.Authorized()));

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("addrolegroup")]
		[Auth(Claims.CAN_ADD_ROLE_GROUP)]
		public IHttpActionResult AddRoleGroup(AddRoleGroupInput input) => Result(_roleService.AddRoleGroup(input.Authorized()));

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("editrolegroup")]
		[Auth(Claims.CAN_EDIT_ROLE_GROUP)]
		public IHttpActionResult EditRoleGroup(EditRoleGroupInput input) => Result(_roleService.EditRoleGroup(input.Authorized()));
	}
}
