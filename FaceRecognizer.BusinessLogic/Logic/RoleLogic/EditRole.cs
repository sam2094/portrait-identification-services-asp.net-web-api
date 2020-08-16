using FaceRecognizer.Common;
using FaceRecognizer.Common.Enums;
using FaceRecognizer.Common.Enums.CommonEnums;
using FaceRecognizer.Common.Enums.DatabaseEnums.RoleEnums;
using FaceRecognizer.Common.Resources;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.RoleLogic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FaceRecognizer.BusinessLogic.Logic.RoleLogic
{
	public class EditRole : Logic<EditRoleInput, EditRoleOutput>
	{
		public EditRole(IUnitofWork uow,
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

			Role role = _uow.GetRepository<Role>().Get(x => x.Id == Parameters.RoleId, i => i.Claims);

			if (role == null)
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.ROLE_DOES_NOT_EXIST,
					ErrorMessage = Resource.ROLE_DOES_NOT_EXIST,
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

			if (!Enum.IsDefined(typeof(Levels), Parameters.Level.ToUpper().Trim()))
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.LEVEL_IS_NOT_EXIST,
					ErrorMessage = Resource.LEVEL_IS_NOT_EXIST,
					StatusCode = ErrorHttpStatus.NOT_FOUND
				});
				return;
			}

			// Claims that need to be added must not contains that role's claims

			List<Claim> claims = _uow.GetRepository<Claim>().GetAll(x => Parameters.ClaimIds.Contains(x.Id)).ToList();
			//claims = claims.Intersect(currentUser.Role.Claims.Except(role.Claims)).ToList();
			role.Name = Parameters.Name.Trim().ToUpper();
			role.Description = Parameters.Description.Trim();
			role.Level = Parameters.Level.Trim();
			role.Claims.Clear();
			foreach (var claim in claims)
				role.Claims.Add(claim);
			_uow.SaveChanges();
		}
	}
}
