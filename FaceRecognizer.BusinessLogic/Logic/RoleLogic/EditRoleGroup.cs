using FaceRecognizer.Common;
using FaceRecognizer.Common.Enums;
using FaceRecognizer.Common.Enums.DatabaseEnums.RoleEnums;
using FaceRecognizer.Common.Resources;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.RoleLogic;

namespace FaceRecognizer.BusinessLogic.Logic.RoleLogic
{
	public class EditRoleGroup : Logic<EditRoleGroupInput, EditRoleGroupOutput>
	{
		public EditRoleGroup(IUnitofWork uow,
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

			RoleGroup roleGroup = _uow.GetRepository<RoleGroup>().Get(x => x.Id == Parameters.RoleGroupId);

			if (roleGroup == null)
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.ROLE_GROUP_DOES_NOT_EXIST,
					ErrorMessage = Resource.ROLE_GROUP_DOES_NOT_EXIST,
					StatusCode = ErrorHttpStatus.NOT_FOUND
				});
				return;
			}

			roleGroup.Name = Parameters.Name;
			_uow.SaveChanges();
		}
	}
}
