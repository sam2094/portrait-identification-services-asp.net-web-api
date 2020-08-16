using Owin;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Ninject;
using FaceRecognizer.Web.Configuration;

namespace FaceRecognizer.Web
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            IKernel kernelValue = NinjectConfiguration.CreateKernel.Value;

            app.UseNinjectMiddleware(() => kernelValue)
                .UseNinjectWebApi(new WebApiConfiguration());
        }
    }
}