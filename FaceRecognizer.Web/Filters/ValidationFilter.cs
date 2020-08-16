using FaceRecognizer.Common.Enums;
using FaceRecognizer.Common;
using FaceRecognizer.Common.Resources;
using FaceRecognizer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace FaceRecognizer.Web.Filters
{
    /// <summary>
    /// 
    /// </summary>
    public class ValidationFilter : ActionFilterAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ActionArguments.Any(x => x.Value == null))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, new LogicResult<LogicOutput>()
                {
                    ErrorList = new List<Error>
                    {
                        new Error
                        {
                            ErrorCode = ErrorCodes.INPUT_IS_NOT_VALID,
                            ErrorMessage = Resource.INVALID_INPUT,
                            StatusCode = ErrorHttpStatus.VALIDATION
                        }
                    }
                });
                return;
            }
            if (actionContext.ModelState.IsValid) return;

            List<Error> errors = actionContext.ModelState.Select(keyValuePair => new Error
            {
                ErrorCode = ErrorCodes.INPUT_IS_NOT_VALID,
                ErrorMessage = keyValuePair.Value.Errors.FirstOrDefault(x => x.ErrorMessage != string.Empty)?.ErrorMessage ?? Resource.INVALID_INPUT,
                StatusCode = ErrorHttpStatus.VALIDATION
            }).ToList();

            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, new LogicResult<LogicOutput>()
            {
                ErrorList = errors
            });
        }
    }
}