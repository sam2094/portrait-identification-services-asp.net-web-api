using FaceRecognizer.BusinessLogic.Logic.BranchLogic;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models;
using FaceRecognizer.Models.LogicParameters.BranchLogic;

namespace FaceRecognizer.Services.Services.BranchServices
{
    public class BranchService : IBranchService
    {
        private readonly IUnitofWork _uow;

        public BranchService(IUnitofWork uow) => _uow = uow;

        public LogicResult<AddBranchOutput> AddBranch(AddBranchInput input)
           => new AddBranch(_uow, nameof(AddBranch)).Execute(parameters: input);

        public LogicResult<EditBranchOutput> EditBranch(EditBranchInput input)
           => new EditBranch(_uow, nameof(EditBranch)).Execute(parameters: input);

        public LogicResult<GetBranchByIdOutput> GetBranchById(GetBranchByIdInput input)
           => new GetBranchById(_uow, nameof(GetBranchById)).Execute(parameters: input);

        public LogicResult<GetBranchesOutput> GetBranches(GetBranchesInput input)
           => new GetBranches(_uow, nameof(GetBranches)).Execute(parameters: input);
    }
}
