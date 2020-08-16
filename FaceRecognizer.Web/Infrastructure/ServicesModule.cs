using Ninject.Modules;
using FaceRecognizer.Services.Services.UserServices;
using FaceRecognizer.Services.Services.ContractServices;
using FaceRecognizer.Services.Services.OrganizationServices;
using FaceRecognizer.Services.Services.RegionService;
using FaceRecognizer.Services.Services.ClaimService;
using FaceRecognizer.Services.Services.BranchServices;
using FaceRecognizer.Services.Services.RoleServices;

namespace FaceRecognizer.WebAPI.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public class ServicesModule : NinjectModule
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Load()
        {
            Bind<IUserService>().To<UserService>().InTransientScope();
            Bind<IContractService>().To<ContractService>().InTransientScope();
            Bind<IOrganizationService>().To<OrganizationService>().InTransientScope();
            Bind<IRegionService>().To<RegionService>().InTransientScope();
            Bind<IClaimService>().To<ClaimService>().InTransientScope();
            Bind<IBranchService>().To<BranchService>().InTransientScope();
            Bind<IRoleService>().To<RoleService>().InTransientScope();
        }
    }
}
