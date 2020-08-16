using FaceRecognizer.Models;
using FaceRecognizer.Models.LogicParameters.ClaimLogic;

namespace FaceRecognizer.Services.Services.ClaimService
{
    public interface IClaimService
    {
        LogicResult<GetClaimsOutput> GetClaims(GetClaimsInput input);
    }
}
