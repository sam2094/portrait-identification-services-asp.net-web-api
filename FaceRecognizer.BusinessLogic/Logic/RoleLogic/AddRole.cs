using FaceRecognizer.Common;
using FaceRecognizer.Common.Enums;
using FaceRecognizer.Common.Enums.CommonEnums;
using FaceRecognizer.Common.Enums.DatabaseEnums.RoleEnums;
using FaceRecognizer.Common.Resources;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.RoleLogic;
using System;
using System.Linq;

namespace FaceRecognizer.BusinessLogic.Logic.RoleLogic
{
	public class AddRole : Logic<AddRoleInput, AddRoleOutput>
	{
		public AddRole(IUnitofWork uow,
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

			if (!_uow.GetRepository<RoleGroup>().IsExist(x => x.Id == Parameters.RoleGroupId))
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.ROLE_GROUP_DOES_NOT_EXIST,
					ErrorMessage = Resource.ROLE_GROUP_DOES_NOT_EXIST,
					StatusCode = ErrorHttpStatus.NOT_FOUND
				});
				return;
			}

			// Claims that need to be added must contains current user role's claims
			if (!Parameters.ClaimIds.All(x => currentUser.Role.Claims.Any(a => a.Id == x)))
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.CLAIM_DOES_NOT_EXIST,
					ErrorMessage = Resource.CLAIM_DOES_NOT_EXIST,
					StatusCode = ErrorHttpStatus.NOT_FOUND
				});
				return;
			}

			bool isExist = Enum.IsDefined(typeof(Levels), Parameters.Level.ToUpper().Trim());

			if (!isExist)
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.LEVEL_IS_NOT_EXIST,
					ErrorMessage = Resource.LEVEL_IS_NOT_EXIST,
					StatusCode = ErrorHttpStatus.NOT_FOUND
				});
				return;
			}

			_uow.GetRepository<Role>().Add(new Role
			{
				Name = Parameters.Name.Trim().ToUpper(),
				Description = Parameters.Description.Trim(),
				RoleGroupId = Parameters.RoleGroupId,
				Claims = _uow.GetRepository<Claim>().GetAll(x => Parameters.ClaimIds.Contains(x.Id)).ToList(),
				AddedDate = DateTime.Now,
				Level = Parameters.Level
			});

			_uow.SaveChanges();
		}
	}
}
