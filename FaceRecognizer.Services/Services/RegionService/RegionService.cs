using FaceRecognizer.BusinessLogic.Logic.RegionLogic;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models;
using FaceRecognizer.Models.LogicParameters.RegionLogic;

namespace FaceRecognizer.Services.Services.RegionService
{
    public class RegionService : IRegionService
    {
        private readonly IUnitofWork _uow;

        public RegionService(IUnitofWork uow) => _uow = uow;

        public LogicResult<GetRegionsOutput> GetRegions()
            => new GetRegions(_uow, nameof(GetRegions)).Execute();
    }
}
