using FaceRecognizer.Models;
using FaceRecognizer.Models.LogicParameters.RoleLogic;

namespace FaceRecognizer.Services.Services.RoleServices
{
    public interface IRoleService
    {
        LogicResult<GetRolesOutput> GetRoles(GetRolesInput input);
        LogicResult<AddRoleOutput> AddRole(AddRoleInput input);
        LogicResult<EditRoleOutput> EditRole(EditRoleInput input);
        LogicResult<GetRoleGroupsOutput> GetRoleGroups(GetRoleGroupsInput input);
        LogicResult<GetRoleLevelOutput> GetRoleLevels(GetRoleLevelInput input);
		LogicResult<AddRoleGroupOutput> AddRoleGroup(AddRoleGroupInput input);
		LogicResult<EditRoleGroupOutput> EditRoleGroup(EditRoleGroupInput input);
	}
}
