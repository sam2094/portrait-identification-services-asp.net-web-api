using FaceRecognizer.Models;
using FaceRecognizer.Models.LogicParameters.BranchLogic;

namespace FaceRecognizer.Services.Services.BranchServices
{
    public interface IBranchService
    {
        LogicResult<GetBranchesOutput> GetBranches(GetBranchesInput input);
        LogicResult<AddBranchOutput> AddBranch(AddBranchInput input);
        LogicResult<EditBranchOutput> EditBranch(EditBranchInput input);
        LogicResult<GetBranchByIdOutput> GetBranchById(GetBranchByIdInput input);
    }
}
