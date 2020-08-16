using FaceRecognizer.Common.Enums;
using FaceRecognizer.Common.Resources;
using FaceRecognizer.ExternalServices.Models.Azercell;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using log4net;
using System.Reflection;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace FaceRecognizer.ExternalServices
{
	public static class Azercell
	{
		public static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		public static AzercellLoginOutputDto Login(AzercellLoginInputDto azercellLogin)
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					client.Timeout = new TimeSpan(0, 0, 40);
					client.BaseAddress = new Uri("http://customeractivation.appazercell.uat/");
					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					StringContent stringContent =
							new StringContent(JsonConvert.SerializeObject(new AzercellLoginInputDto
							{
								username = azercellLogin.username,
								password = azercellLogin.password,
								fin = azercellLogin.fin,
							}));

					stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

					return client.PostAsync("auth/dealer/login", stringContent)
						.Result.Content.ReadAsAsync<AzercellLoginOutputDto>().Result;

				}
			}
			catch (Exception ex)
			{
				Logger.Error($"Error occured from this class : {nameof(Azercell)} : {ex.ToString()}");
				return new AzercellLoginOutputDto
				{
					status = (int)ErrorHttpStatus.INTERNAL,
					message = Resource.UNHANDLED_EXCEPTION
				};
			}
		}

		public static AzercellLogoutOutputDto Logout(AzercellLogoutInputDto azercellLogout)
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					client.Timeout = new TimeSpan(0, 0, 40);
					client.BaseAddress = new Uri("http://customeractivation.appazercell.uat/");
					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					StringContent stringContent =
							new StringContent(JsonConvert.SerializeObject(new AzercellLogoutInputDto
							{
								refresh_token = azercellLogout.refresh_token
							}));

					stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

					return client.PostAsync("auth/logout", stringContent)
						.Result.Content.ReadAsAsync<AzercellLogoutOutputDto>().Result;
				};
			}
			catch (Exception ex)
			{

				Logger.Error($"Error occured from this class : {nameof(Azercell)} : {ex.ToString()}");
				return new AzercellLogoutOutputDto
				{
					status = (int)ErrorHttpStatus.INTERNAL,
					message = Resource.UNHANDLED_EXCEPTION
				};
			}
		}

		public static AzercellRefreshOutputDto Refresh(AzercellRefreshInputDto azercellRefresh)
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					client.Timeout = new TimeSpan(0, 0, 40);
					client.BaseAddress = new Uri("http://customeractivation.appazercell.uat/");
					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					StringContent stringContent =
							new StringContent(JsonConvert.SerializeObject(new AzercellRefreshInputDto
							{
								refresh_token = azercellRefresh.refresh_token
							}));

					stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

					return client.PostAsync("auth/refresh", stringContent)
						.Result.Content.ReadAsAsync<AzercellRefreshOutputDto>().Result;
				};
			}
			catch (Exception ex)
			{

				Logger.Error($"Error occured from this class : {nameof(Azercell)} : {ex.ToString()}");
				return new AzercellRefreshOutputDto
				{
					status = (int)ErrorHttpStatus.INTERNAL,
					message = Resource.UNHANDLED_EXCEPTION
				};
			}
		}


		public static async Task<UploadAzercellContractOutputDto> UploadContract(UploadAzercellContractInputDto uploadContract, string authToken)
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					client.Timeout = new TimeSpan(0, 0, 40);
					client.BaseAddress = new Uri("http://customeractivation.appazercell.uat/");
					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Add("Auth-Token", authToken);

					var requestContent = new MultipartFormDataContent();
					var documentContent = new ByteArrayContent(uploadContract.RawData);
					documentContent.Headers.ContentType =
						MediaTypeHeaderValue.Parse("application/pdf");
					StringContent pin =
						new StringContent(uploadContract.Pin);
					requestContent.Add(pin, "pin");
					requestContent.Add(documentContent, "file", uploadContract.FileName);
					return  client.PostAsync($"/documents/msisdn/{uploadContract.Msisdn}", requestContent)
						.Result.Content.ReadAsAsync<UploadAzercellContractOutputDto>().Result;
				};
			}
			catch (Exception ex)
			{
				Logger.Error($"Error occured from this class : {nameof(Azercell)} : {ex.ToString()}");
				return new UploadAzercellContractOutputDto
				{
					status = (int)ErrorHttpStatus.INTERNAL,
					message = Resource.UNHANDLED_EXCEPTION
				};
			}
		}

		public static async Task GetActivasionForm(string inputBase64, string authToken)
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					client.Timeout = new TimeSpan(0, 0, 40);
					client.BaseAddress = new Uri("http://customeractivation.appazercell.uat/");
					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					client.DefaultRequestHeaders.Add("Auth-token", authToken);
					HttpResponseMessage response = await client.GetAsync(string
						.Concat("activation/home?redirectUrl=https://rabita.az&mhmData=", inputBase64));
				};
			}
			catch (Exception ex)
			{
				Logger.Error($"Error occured from this class : {nameof(Azercell)} : {ex.ToString()}");
			}
		}
	}
}
