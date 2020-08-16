using FaceRecognizer.ExternalServices.Models;
using System;
using FaceRecognizer.ExternalServices.az.rabita.mhm.ws;
using FaceRecognizer.ExternalServices.Enums;
using FaceRecognizer.Common.Helpers;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using FaceRecognizer.Common.Resources;
using FaceRecognizer.Common.Enums;
using log4net;
using System.Reflection;

namespace FaceRecognizer.ExternalServices
{
	public static class Iamas
	{
		public static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		public static GetIamasOutputDto GetIamasData(string documentNumber, string pin, DocType docType)
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					client.Timeout = new TimeSpan(0, 1, 0);
					client.BaseAddress = new Uri("http://address");
					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Add("customersRequestKey", "wVh6JH+jICN6PGt3gyI0VEIyDfE=");
					client.DefaultRequestHeaders.Add("permissionsRequestKey", "kS/XQGJhKthU6HrbdXJeBBh9qxU=");
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					StringContent stringContent =
						new StringContent(JsonConvert.SerializeObject(new GetIamasInputDto { DocumentNumber = documentNumber, Pin = pin, Lang = 10, DocType = docType }));
					stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

					return client.PostAsync("api/v1/iamas/basicInfoByDocNumberPIN", stringContent)
						.Result.Content.ReadAsAsync<GetIamasOutputDto>().Result;
				};
			}
			catch (Exception ex)
			{
				Logger.Error($"Error occured from this class : {nameof(Iamas)} : {ex.ToString()}");
				return new GetIamasOutputDto
				{
					ResultStatus = new IamasResultStatusDto
					{
						Code = (int)ErrorHttpStatus.INTERNAL,
						Text = Resource.UNHANDLED_EXCEPTION
					}
				};
			}
		}
	}
}
