using FaceRecognizer.ExternalServices.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;

namespace FaceRecognizer.ExternalServices
{
	public static class CertificateManager
	{
		private static readonly string KEY = "KEY";
		private static readonly string TEMPLATE = "TEMPLATE";

		public static GetCertificateOutputDto GetCertificate(GetCertificateInputDto input)
		{
			input.Template = TEMPLATE;
			var json = JsonConvert.SerializeObject(input);
			string makeSign = SignHMACAsString(KEY, json);

			using (HttpClient client = new HttpClient())
			{
				client.Timeout = new TimeSpan(0, 0, 60);
				client.BaseAddress = new Uri("http://address");
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Add("sign", makeSign);
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				StringContent stringContent = new StringContent(json);
				stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

				return client.PostAsync("v1/CAManager/Certificate", stringContent)
					.Result.Content.ReadAsAsync<GetCertificateOutputDto>().Result;
			};
		}

		public static string SignHMACAsString(string key, string content)
		{
			using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
			{
				byte[] signatureBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(content));
				return Convert.ToBase64String(signatureBytes);
			}
		}
	}
}
