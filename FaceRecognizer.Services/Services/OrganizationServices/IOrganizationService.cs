using FaceRecognizer.Models;
using FaceRecognizer.Models.LogicParameters.OrganizationLogic;

namespace FaceRecognizer.Services.Services.OrganizationServices
{
	public interface IOrganizationService
	{
		LogicResult<GetOrganizationsOutput> GetOrganizations(GetOrganizationsInput input);

		LogicResult<AddOrganizationOutput> AddOrganization(AddOrganizationInput input);

		LogicResult<EditOrganizationOutput> EditOrganization(EditOrganizationInput input);
	}
}
