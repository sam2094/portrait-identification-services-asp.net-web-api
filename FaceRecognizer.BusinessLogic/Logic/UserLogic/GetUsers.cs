using FaceRecognizer.Common.Enums.CommonEnums;
using FaceRecognizer.Common.Enums.DatabaseEnums.RoleEnums;
using FaceRecognizer.Common.Helpers;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.DTOs.UserDtos;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.UserLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FaceRecognizer.BusinessLogic.Logic.UserLogic
{
	public class GetUsers : Logic<GetUsersInput, GetUsersOutput>
	{
		public GetUsers(IUnitofWork uow,
				string firstExecutedLogicName,
				bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		public override void DoExecute()
		{
			User currentUser = _uow.GetRepository<User>().Get(x => x.Id == Parameters.CurrentUserId, i => i.Role, i => i.Branch);
			List<User> users = new List<User>();

			Parameters.Name = Parameters.Name?.Trim().Replace("İ", "i").ToUpper();
			Parameters.Surname = Parameters.Surname?.Trim().Replace("İ", "i").ToUpper();
			Parameters.Patronymic = Parameters.Patronymic?.Trim().Replace("İ", "i").ToUpper();
			var totalCount = 0;

			if (currentUser.RoleId == (int)Roles.SUPER_ADMIN)
			{
				users = _uow.GetRepository<User>().GetAll(x =>
				(Parameters.DocumentNumber == null || Parameters.DocumentNumber.Trim() == "" || x.DocumentNumber.Trim().ToUpper() == Parameters.DocumentNumber.Trim().ToUpper())
				&& (Parameters.DocumentPin == null || Parameters.DocumentPin.Trim() == "" || x.DocumentPin.Trim().ToUpper() == Parameters.DocumentPin.Trim().ToUpper())
				&& (Parameters.Name == null || Parameters.Name == "" || x.Name.Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Name))
				&& (Parameters.Surname == null || Parameters.Surname == "" || x.Surname.Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Surname))
				&& (Parameters.Patronymic == null || Parameters.Patronymic == "" || x.Patronymic.Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Patronymic))
				&& (Parameters.Contact == null || Parameters.Contact.Trim() == "" || x.Contact.Trim().ToUpper().Contains(Parameters.Contact.Trim().ToUpper()))
				&& (Parameters.UserStatusId == 0 || x.UserStatusId == Parameters.UserStatusId)
				&& (Parameters.RoleId == 0 || x.RoleId == Parameters.RoleId)
				&& (Parameters.RoleGroupId == 0 || x.Role.RoleGroupId == Parameters.RoleGroupId)
				&& (Parameters.BranchId == 0 || x.BranchId == Parameters.BranchId)
				&& (Parameters.OrganizationId == 0 || x.Branch.OrganizationId == Parameters.OrganizationId),
				i => i.Branch.Organization,
				i => i.Role.RoleGroup,
				i => i.UserStatus)
				.OrderByDescending(x => x.Id).Skip((Parameters.PageNumber - 1) * Parameters.DataCount).Take(Parameters.DataCount)
				.ToList();

				totalCount = _uow.GetRepository<User>().Count(x =>
				(Parameters.DocumentNumber == null || Parameters.DocumentNumber.Trim() == "" || x.DocumentNumber.Trim().ToUpper() == Parameters.DocumentNumber.Trim().ToUpper())
				&& (Parameters.DocumentPin == null || Parameters.DocumentPin.Trim() == "" || x.DocumentPin.Trim().ToUpper() == Parameters.DocumentPin.Trim().ToUpper())
				&& (Parameters.Name == null || Parameters.Name == "" || x.Name.Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Name))
				&& (Parameters.Surname == null || Parameters.Surname == "" || x.Surname.Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Surname))
				&& (Parameters.Patronymic == null || Parameters.Patronymic == "" || x.Patronymic.Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Patronymic))
				&& (Parameters.Contact == null || Parameters.Contact.Trim() == "" || x.Contact.Trim().ToUpper().Contains(Parameters.Contact.Trim().ToUpper()))
				&& (Parameters.UserStatusId == 0 || x.UserStatusId == Parameters.UserStatusId)
				&& (Parameters.RoleId == 0 || x.RoleId == Parameters.RoleId)
				&& (Parameters.RoleGroupId == 0 || x.Role.RoleGroupId == Parameters.RoleGroupId)
				&& (Parameters.BranchId == 0 || x.BranchId == Parameters.BranchId)
				&& (Parameters.OrganizationId == 0 || x.Branch.OrganizationId == Parameters.OrganizationId));
			}
			else if (currentUser.Role.Level == Levels.ORGANIZATION_LEVEL.ToString())
			{
				int orgId = _uow.GetRepository<User>().Get(x => x.Id == Parameters.CurrentUserId, i => i.Branch).Branch.OrganizationId;

				users = _uow.GetRepository<User>().GetAll(x =>
				 (Parameters.DocumentNumber == null || Parameters.DocumentNumber.Trim() == "" || x.DocumentNumber.Trim().ToUpper() == Parameters.DocumentNumber.Trim().ToUpper())
				 && (Parameters.DocumentPin == null || Parameters.DocumentPin.Trim() == "" || x.DocumentPin.Trim().ToUpper() == Parameters.DocumentPin.Trim().ToUpper())
				 && (Parameters.Name == null || Parameters.Name == "" || x.Name.Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Name))
				 && (Parameters.Surname == null || Parameters.Surname == "" || x.Surname.Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Surname))
				 && (Parameters.Patronymic == null || Parameters.Patronymic == "" || x.Patronymic.Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Patronymic))
				 && (Parameters.Contact == null || Parameters.Contact.Trim() == "" || x.Contact.Trim().ToUpper().Contains(Parameters.Contact.Trim().ToUpper()))
				 && (Parameters.UserStatusId == 0 || x.UserStatusId == Parameters.UserStatusId)
				 && (Parameters.RoleId == 0 || x.RoleId == Parameters.RoleId)
				 && (Parameters.RoleGroupId == 0 || x.Role.RoleGroupId == Parameters.RoleGroupId)
				 && ((Parameters.BranchId == 0 || x.BranchId == Parameters.BranchId) && x.Branch.OrganizationId == orgId),
					i => i.Branch.Organization,
					i => i.Role.RoleGroup,
					i => i.UserStatus)
				.OrderByDescending(x => x.Id).Skip((Parameters.PageNumber - 1) * Parameters.DataCount).Take(Parameters.DataCount)
				.ToList();

				totalCount = _uow.GetRepository<User>().Count(x =>
				 (Parameters.DocumentNumber == null || Parameters.DocumentNumber.Trim() == "" || x.DocumentNumber.Trim().ToUpper() == Parameters.DocumentNumber.Trim().ToUpper())
				 && (Parameters.DocumentPin == null || Parameters.DocumentPin.Trim() == "" || x.DocumentPin.Trim().ToUpper() == Parameters.DocumentPin.Trim().ToUpper())
				 && (Parameters.Name == null || Parameters.Name == "" || x.Name.Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Name))
				 && (Parameters.Surname == null || Parameters.Surname == "" || x.Surname.Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Surname))
				 && (Parameters.Patronymic == null || Parameters.Patronymic == "" || x.Patronymic.Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Patronymic))
				 && (Parameters.Contact == null || Parameters.Contact.Trim() == "" || x.Contact.Trim().ToUpper().Contains(Parameters.Contact.Trim().ToUpper()))
				 && (Parameters.UserStatusId == 0 || x.UserStatusId == Parameters.UserStatusId)
				 && (Parameters.RoleId == 0 || x.RoleId == Parameters.RoleId)
				 && (Parameters.RoleGroupId == 0 || x.Role.RoleGroupId == Parameters.RoleGroupId)
				 && ((Parameters.BranchId == 0 || x.BranchId == Parameters.BranchId) && x.Branch.OrganizationId == orgId));
			}
			else if (currentUser.Role.Level == Levels.BRANCH_LEVEL.ToString())
			{
				users = _uow.GetRepository<User>().GetAll(x =>
				(Parameters.DocumentNumber == null || Parameters.DocumentNumber.Trim() == "" || x.DocumentNumber.Trim().ToUpper() == Parameters.DocumentNumber.Trim().ToUpper())
				&& (Parameters.DocumentPin == null || Parameters.DocumentPin.Trim() == "" || x.DocumentPin.Trim().ToUpper() == Parameters.DocumentPin.Trim().ToUpper())
				&& (Parameters.Name == null || Parameters.Name == "" || x.Name.Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Name))
				&& (Parameters.Surname == null || Parameters.Surname == "" || x.Surname.Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Surname))
				&& (Parameters.Patronymic == null || Parameters.Patronymic == "" || x.Patronymic.Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Patronymic))
				&& (Parameters.Contact == null || Parameters.Contact.Trim() == "" || x.Contact.Trim().ToUpper().Contains(Parameters.Contact.Trim().ToUpper()))
				&& (Parameters.UserStatusId == 0 || x.UserStatusId == Parameters.UserStatusId)
				&& (Parameters.RoleId == 0 || x.RoleId == Parameters.RoleId)
				&& (Parameters.RoleGroupId == 0 || x.Role.RoleGroupId == Parameters.RoleGroupId)
				&& (x.BranchId == currentUser.BranchId),
				 i => i.Branch.Organization,
				 i => i.Role.RoleGroup,
				 i => i.UserStatus)
			 .OrderByDescending(x => x.Id).Skip((Parameters.PageNumber - 1) * Parameters.DataCount).Take(Parameters.DataCount)
			 .ToList();

				totalCount = _uow.GetRepository<User>().Count(x =>
				(Parameters.DocumentNumber == null || Parameters.DocumentNumber.Trim() == "" || x.DocumentNumber.Trim().ToUpper() == Parameters.DocumentNumber.Trim().ToUpper())
				&& (Parameters.DocumentPin == null || Parameters.DocumentPin.Trim() == "" || x.DocumentPin.Trim().ToUpper() == Parameters.DocumentPin.Trim().ToUpper())
				&& (Parameters.Name == null || Parameters.Name == "" || x.Name.Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Name))
				&& (Parameters.Surname == null || Parameters.Surname == "" || x.Surname.Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Surname))
				&& (Parameters.Patronymic == null || Parameters.Patronymic == "" || x.Patronymic.Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Patronymic))
				&& (Parameters.Contact == null || Parameters.Contact.Trim() == "" || x.Contact.Trim().ToUpper().Contains(Parameters.Contact.Trim().ToUpper()))
				&& (Parameters.UserStatusId == 0 || x.UserStatusId == Parameters.UserStatusId)
				&& (Parameters.RoleId == 0 || x.RoleId == Parameters.RoleId)
				&& (Parameters.RoleGroupId == 0 || x.Role.RoleGroupId == Parameters.RoleGroupId)
				&& (x.BranchId == currentUser.BranchId));
			}

			Result.Output.TotalDataCount = totalCount;
			Result.Output.PageCount = Parameters.DataCount > 0 ? (int)Math.Ceiling(((decimal)totalCount / Parameters.DataCount)) : 0;

			Result.Output.Users = users.Select(x => new UsersDto
			{
				Id = x.Id,
				UserStatusId = x.UserStatusId,
				UserStatusName = x.UserStatus.Name,
				BranchId = x.BranchId,
				BranchName = x.Branch.PlaceName,
				RoleId = x.RoleId,
				RoleName = x.Role.Name,
				RoleGroupId = x.Role.RoleGroupId,
				RoleGroupName = x.Role.RoleGroup.Name,
				UserOrganizationName = x.Branch.Organization.Name,
				Name = x.Name,
				Surname = x.Surname,
				Patronymic = x.Patronymic,
				Username = x.Username,
				Contact = x.Contact,
				DocumentNumber = x.DocumentNumber,
				DocumentPin = x.DocumentPin,
				PlaceCode = x.Branch.Code,
				IsFaceRecognized = x.IsFaceRecognized,
				AddedDate = x.AddedDate,
				Photo = File.Exists(Path.Combine(ConfigHelper.GetAppSetting("Photo"), x.Photo)) ?
				File.ReadAllBytes(Path.Combine(ConfigHelper.GetAppSetting("Photo"), x.Photo)) : null
			}).ToList();
		}
	}
}