using FaceRecognizer.Web.Filters;
using FluentValidation.WebApi;
using log4net.Config;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.Application;
using System;
using System.IO;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Cors;
using FaceRecognizer.Common.Helpers;
using FaceRecognizer.Web.Handlers;

namespace FaceRecognizer.Web.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    public class WebApiConfiguration : HttpConfiguration
    {
        /// <summary>
        /// 
        /// </summary>
        public WebApiConfiguration()
        {
            ConfigureSwagger();
            ConfigureCors();
            ConfigureRoutes();
            ConfigureFormatters();
            ConfigureProviders();
            ConfigureLogger();
            ConfigureFilters();
			ConfigureHandlers(); // Translate
		}

		private void ConfigureHandlers() => MessageHandlers.Add(new SetCulture()); // Translate
		private void ConfigureFilters() => Filters.Add(new ValidationFilter());
        private void ConfigureSwagger() => this.EnableSwagger(c =>
        {
            #if DEBUG
            #else
            c.RootUrl(req => ConfigHelper.GetAppSetting("SwaggerRootUrl"));
            #endif
            c.SingleApiVersion("v1", "FaceRecognizer Rest services");
            c.DescribeAllEnumsAsStrings();

            c.OperationFilter<RequiredParameter>();

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
            string commentsFile = Path.Combine(baseDirectory, "bin", commentsFileName);

            #if DEBUG
            c.IncludeXmlComments(commentsFile);
            #else
            #endif
        }).EnableSwaggerUi();
        private void ConfigureCors() => this.EnableCors(new EnableCorsAttribute("*", "*", "*"));
        private void ConfigureRoutes() => this.MapHttpAttributeRoutes();
        private void ConfigureFormatters()
        {
            Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            Formatters.JsonFormatter.MediaTypeMappings
                .Add(new QueryStringMapping("type", "json", new MediaTypeHeaderValue("application/json")));
            Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/octet-stream"));
            JsonMediaTypeFormatter json = Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            json.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
        }
        private void ConfigureProviders() => FluentValidationModelValidatorProvider.Configure(this);
        private void ConfigureLogger() => XmlConfigurator.Configure();
    }
}
