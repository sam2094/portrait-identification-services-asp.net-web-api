using FaceRecognizer.Models;
using FaceRecognizer.Models.LogicParameters.RegionLogic;

namespace FaceRecognizer.Services.Services.RegionService
{
    public interface IRegionService
    {
        LogicResult<GetRegionsOutput> GetRegions();
    }
}
