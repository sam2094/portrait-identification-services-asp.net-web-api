using FaceRecognizer.Common.Resources;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FaceRecognizer.Web.Handlers
{
	/// <summary>
	/// 
	/// </summary>
	public class SetCulture : DelegatingHandler
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="request"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			Resource.Culture = new CultureInfo("az");
			return base.SendAsync(request, cancellationToken);
		}
	}
}