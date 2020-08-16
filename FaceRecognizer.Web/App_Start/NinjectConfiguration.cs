using Ninject;
using Ninject.Modules;
using System;
using System.Linq;
using System.Reflection;

namespace FaceRecognizer.Web
{
    /// <summary>
    /// 
    /// </summary>
    public static class NinjectConfiguration
    {
        /// <summary>
        /// 
        /// </summary>
        public static Lazy<IKernel> CreateKernel = new Lazy<IKernel>(() =>
        {
            NinjectModule[] modules = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof(NinjectModule).IsAssignableFrom(t))
                .Select(t => (NinjectModule)Activator.CreateInstance(t))
                .ToArray();
            return new StandardKernel(modules);
        });
    }
}
