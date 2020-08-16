using FaceRecognizer.Common;
using FaceRecognizer.Common.Enums;
using FaceRecognizer.Models;
using FaceRecognizer.Models.LogicParameters.ContractLogic;
using FaceRecognizer.Web.Helpers;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FaceRecognizer.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseController : ApiController
    {
        /// <summary>
        /// Creates api result built by logic result.
        /// </summary>
        /// <param name="result"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        protected CreateActionResult<TResult> Result<TResult>(LogicResult<TResult> result) where TResult : LogicOutput
            => new CreateActionResult<TResult>(result, Request);
    }
}
