using Ninject.Modules;
using FaceRecognizer.DataAccess.UnitofWork;
using System.Data.Entity;
using FaceRecognizer.DataAccess.Database;

namespace FaceRecognizer.Web.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public class DataAccessModule: NinjectModule
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Load()
        {
            Bind<IUnitofWork>().To<UnitofWork>().InTransientScope();
            Bind<DbContext>().To<MyDbContext>().InTransientScope();
        }
    }
}
