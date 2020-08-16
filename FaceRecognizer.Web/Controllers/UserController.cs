using FaceRecognizer.Common.Enums.DatabaseEnums.ClaimEnums;
using FaceRecognizer.Models.LogicParameters.UserLogic;
using FaceRecognizer.Services.Services.UserServices;
using FaceRecognizer.Web.Extensions;
using FaceRecognizer.Web.Filters;
using FaceRecognizer.Web.Routing;
using System.Web.Http;
using System.Threading.Tasks;

namespace FaceRecognizer.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiVersion1RoutePrefix("user")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserService userService) => _userService = userService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("register")]
        [Auth(Claims.CAN_REGISTER_USER)]
        public IHttpActionResult Register(CreateUserInput input) => Result(_userService.CreateUser(input.Authorized()));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login(LoginUserInput input) => Result(_userService.LoginUser(input));


        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("loginmobile")]
        public IHttpActionResult LoginMobile(LoginMobileUserInput input) => Result(_userService.LoginMobileUser(input));

        /// <summary>
        /// 
        /// </summary>
        /// <param name = "input" ></param>
        /// <returns></returns>
        [HttpPost]
        [Route("sendsms")]
        public IHttpActionResult LoginChecker(LoginCheckInput input) => Result(_userService.LoginChecker(input));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("getall")]
        [Auth(Claims.CAN_GET_USERS)]
        public IHttpActionResult GetUsers(GetUsersInput input) => Result(_userService.GetUsers(input.Authorized()));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("edituser")]
        [Auth(Claims.CAN_EDIT_USER)]
        public IHttpActionResult EditUsers(EditUserInput input) => Result(_userService.EditUser(input.Authorized()));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("get")]
        [Auth(Claims.CAN_GET_USER_BY_ID)]
        public IHttpActionResult GetUserById(GetUserByIdInput input) => Result(_userService.GetUserById(input.Authorized()));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("changepassword")]
        [Auth(Claims.CAN_CHANGE_PASSWORD)]
        public IHttpActionResult PasswordChange(PasswordChangeInput input) => Result(_userService.PasswordChange(input.Authorized()));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("resetpassword")]
        [Auth(Claims.CAN_RESET_USER_PASSWORD)]
        public IHttpActionResult PasswordReset(PasswordResetInput input) => Result(_userService.PasswordReset(input.Authorized()));

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		[Route("getuserstatuses")]
		[Auth(Claims.CAN_GET_USER_STATUSES)]
		public IHttpActionResult GetUserStatuses() => Result(_userService.GetUserStatuses());

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		[Route("uploaduserfile")]
		[Auth(Claims.CAN_UPLOAD_USER_FILE)] 
		public async Task<IHttpActionResult> UploadUserFile()
		{
			return Result(await _userService.UploadUserFileAsync(new UploadUserFileRequestInput
			{
				Request = Request
			}.Authorized()));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		/// 
		[HttpPost]
		[Route("downloaduserfile")]
		[Auth(Claims.CAN_DOWNLOAD_USER_FILE)]
		public IHttpActionResult DownloadUserFile(DownloadUserFileInput input)
		   => Result(_userService.DownloadUserFile(input.Authorized()));

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[Route("getuserfiletypes")]
		[Auth(Claims.CAN_GET_USER_FILE_TYPES)]
		public IHttpActionResult GetUserFileTypes()
			=> Result(_userService.GetUserFileTypes());
	}
}
