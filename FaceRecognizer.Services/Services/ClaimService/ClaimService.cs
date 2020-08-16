using FaceRecognizer.BusinessLogic.Logic.ClaimLogic;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models;
using FaceRecognizer.Models.LogicParameters.ClaimLogic;

namespace FaceRecognizer.Services.Services.ClaimService
{
    public class ClaimService : IClaimService
    {
        private readonly IUnitofWork _uow;

        public ClaimService(IUnitofWork uow) => _uow = uow;

        public LogicResult<GetClaimsOutput> GetClaims(GetClaimsInput input)
          => new GetClaims(_uow, nameof(GetClaims)).Execute(parameters: input);
    }
}
