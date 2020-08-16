using FaceRecognizer.Common;
using FaceRecognizer.Common.Enums;
using FaceRecognizer.Common.Enums.DatabaseEnums.RoleEnums;
using FaceRecognizer.Common.Resources;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.RoleLogic;

namespace FaceRecognizer.BusinessLogic.Logic.RoleLogic
{
	public class AddRoleGroup : Logic<AddRoleGroupInput, AddRoleGroupOutput>
	{
		public AddRoleGroup(IUnitofWork uow,
				string firstExecutedLogicName,
				bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		public override void DoExecute()
		{
			User currentUser = _uow.GetRepository<User>().Get(x => x.Id == Parameters.CurrentUserId, i => i.Role.Claims);

			bool isSuperAdmin = currentUser.RoleId == (int)Roles.SUPER_ADMIN ? true : false;

			if (!isSuperAdmin)
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.ACCESS_DENIED,
					ErrorMessage = Resource.ACCESS_DENIED,
					StatusCode = ErrorHttpStatus.FORBIDDEN
				});
				return;
			}

			if (!_uow.GetRepository<Organization>().IsExist(x => x.Id == Parameters.OrganizationId))
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.ORGANIZATION_DOES_NOT_EXIST,
					ErrorMessage = Resource.ORGANIZATION_DOES_NOT_EXIST,
					StatusCode = ErrorHttpStatus.NOT_FOUND
				});
				return;
			}

			_uow.GetRepository<RoleGroup>().Add(new RoleGroup
			{
				Name = Parameters.Name.Trim().ToUpper(),
				OrganizationId = Parameters.OrganizationId
			});

			_uow.SaveChanges();
		}
	}
}
