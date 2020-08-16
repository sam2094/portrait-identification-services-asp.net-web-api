using FaceRecognizer.BusinessLogic.Logic.RoleLogic;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models;
using FaceRecognizer.Models.LogicParameters.RoleLogic;

namespace FaceRecognizer.Services.Services.RoleServices
{
    public class RoleService : IRoleService
    {
        private readonly IUnitofWork _uow;

        public RoleService(IUnitofWork uow) => _uow = uow;

        public LogicResult<AddRoleOutput> AddRole(AddRoleInput input)
            => new AddRole(_uow, nameof(AddRole)).Execute(parameters: input);

        public LogicResult<EditRoleOutput> EditRole(EditRoleInput input)
            => new EditRole(_uow, nameof(EditRole)).Execute(parameters: input);

		public LogicResult<GetRoleGroupsOutput> GetRoleGroups(GetRoleGroupsInput input)
		  => new GetRoleGroups(_uow, nameof(GetRoleGroups)).Execute(parameters: input);

		public LogicResult<GetRolesOutput> GetRoles(GetRolesInput input)
          => new GetRoles(_uow, nameof(GetRoles)).Execute(parameters: input);

		public LogicResult<GetRoleLevelOutput> GetRoleLevels(GetRoleLevelInput input)
		  => new GetRoleLevels(_uow, nameof(GetRoleLevels)).Execute(parameters: input);

		public LogicResult<AddRoleGroupOutput> AddRoleGroup(AddRoleGroupInput input)
		 => new AddRoleGroup(_uow, nameof(AddRoleGroup)).Execute(parameters: input);

		public LogicResult<EditRoleGroupOutput> EditRoleGroup(EditRoleGroupInput input)
		 => new EditRoleGroup(_uow, nameof(EditRoleGroup)).Execute(parameters: input);
	}
}
