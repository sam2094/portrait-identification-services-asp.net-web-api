using FaceRecognizer.BusinessLogic.Logic.OrganizationLogic;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models;
using FaceRecognizer.Models.LogicParameters.OrganizationLogic;

namespace FaceRecognizer.Services.Services.OrganizationServices
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IUnitofWork _uow;
        public OrganizationService(IUnitofWork uow) => _uow = uow;

		public LogicResult<GetOrganizationsOutput> GetOrganizations(GetOrganizationsInput input)
         => new GetOrganizations(_uow, nameof(GetOrganizations)).Execute(parameters: input);

		public LogicResult<AddOrganizationOutput> AddOrganization(AddOrganizationInput input)
        => new AddOrganization(_uow, nameof(AddOrganization)).Execute(parameters: input);

		public LogicResult<EditOrganizationOutput> EditOrganization(EditOrganizationInput input)
		=> new EditOrganization(_uow, nameof(EditOrganization)).Execute(parameters: input);
	}
}
