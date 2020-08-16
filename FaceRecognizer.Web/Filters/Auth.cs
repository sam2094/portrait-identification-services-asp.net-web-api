using FaceRecognizer.BusinessLogic.Cache;
using FaceRecognizer.Common;
using FaceRecognizer.Common.Enums;
using FaceRecognizer.Models;
using FaceRecognizer.Common.Resources;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using FaceRecognizer.Common.Enums.DatabaseEnums.ClaimEnums;

namespace FaceRecognizer.Web.Filters
{
    /// <summary>
    /// 
    /// </summary>
    public class Auth : ActionFilterAttribute
    {
        private readonly Claims _claim;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="claim"></param>
        public Auth(Claims claim) => _claim = claim;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Contains("token")
                && TokenCache.Instance.CheckByToken(actionContext.Request.Headers.GetValues("token").First(), _claim)) return;

            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, new LogicResult<LogicOutput>
            {
                ErrorList = new List<Error>
                {
                    new Error
                    {
                        ErrorCode=  ErrorCodes.UNAUTHORIZED,
                        ErrorMessage = Resource.UNAUTHORIZED,
                        StatusCode = ErrorHttpStatus.UNAUTHORIZED
                    }
                }
            });
        }
    }
}