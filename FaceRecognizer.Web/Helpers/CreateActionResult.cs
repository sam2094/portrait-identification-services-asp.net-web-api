using FaceRecognizer.Models;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace FaceRecognizer.Web.Helpers
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="TResult"></typeparam>
	public class CreateActionResult<TResult> : IHttpActionResult where TResult : LogicOutput
	{
		private readonly HttpStatusCode _statusCode;
		private readonly LogicResult<TResult> _result;
		private readonly HttpRequestMessage _request;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="result"></param>
		/// <param name="request"></param>
		public CreateActionResult(LogicResult<TResult> result, HttpRequestMessage request)
		{
			_result = result;
			_request = request;
			_statusCode = result.ErrorList.Count > 0
				? (HttpStatusCode)(int)result.ErrorList.Select(x => x.StatusCode).Max()
				: HttpStatusCode.OK;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="statusCode"></param>
		/// <param name="result"></param>
		/// <returns></returns>
		public HttpResponseMessage CreateResponse(HttpStatusCode statusCode, LogicResult<TResult> result)
			=> _request.CreateResponse(statusCode, result);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
			=> Task.FromResult(CreateResponse(_statusCode, _result));
	}
}
