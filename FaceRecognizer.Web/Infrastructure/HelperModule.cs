using FaceRecognizer.Common.ConfigManager;
using FaceRecognizer.Common.FileManager;
using Ninject.Modules;

namespace FaceRecognizer.Web.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public class HelperModule: NinjectModule
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Load()
        {
            Bind<IFileOperations>().To<FileOperations>().InTransientScope();
            Bind<IConfigOperations>().To<ConfigOperations>().InTransientScope();
        }
    }
}