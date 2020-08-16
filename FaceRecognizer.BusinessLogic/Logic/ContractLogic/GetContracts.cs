using FaceRecognizer.Common.Enums.CommonEnums;
using FaceRecognizer.Common.Enums.DatabaseEnums.RoleEnums;
using FaceRecognizer.Common.Helpers;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.DTOs.ContractDtos;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.ContractLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FaceRecognizer.BusinessLogic.Logic.ContractLogic
{
	public class GetContracts : Logic<GetContractsInput, GetContractsOutput>
	{
		public GetContracts(IUnitofWork uow,
				string firstExecutedLogicName,
				bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		public override void DoExecute()
		{
			User currentUser = _uow.GetRepository<User>().Get(x => x.Id == Parameters.CurrentUserId, i => i.Role, i => i.Branch);
			bool isSuperAdmin = currentUser.RoleId == (int)Roles.SUPER_ADMIN ? true : false;
			int orgId = _uow.GetRepository<User>().Get(x => x.Id == currentUser.Id, i => i.Branch).Branch.OrganizationId;

			List<Contract> contracts = new List<Contract>();

			Parameters.Name = Parameters.Name?.Trim().Replace("İ", "i").ToUpper();
			Parameters.Surname = Parameters.Surname?.Trim().Replace("İ", "i").ToUpper();
			Parameters.Patronymic = Parameters.Patronymic?.Trim().Replace("İ", "i").ToUpper();
			var totalCount = 0;

			if (isSuperAdmin)
			{
				contracts = _uow.GetRepository<Contract>().GetAll(x => (Parameters.OrganizationId == 0 || x.Branch.OrganizationId == Parameters.OrganizationId)
					&& (Parameters.BranchId == 0 || x.User.BranchId == Parameters.BranchId)
					&& (Parameters.OperationTypeId == 0 || x.OperationTypeId == Parameters.OperationTypeId)
					&& (Parameters.ContractStatusId == 0 || x.ContractStatusId == Parameters.ContractStatusId)
					&& (Parameters.DocumentPin == null || Parameters.DocumentPin.Trim() == "" || x.DocumentInformation.DocumentPin.Trim().ToUpper() == Parameters.DocumentPin.Trim().ToUpper())
					&& (Parameters.DocumentNumber == null || Parameters.DocumentNumber.Trim() == "" || x.DocumentInformation.DocumentNumber.Trim().ToUpper() == Parameters.DocumentNumber.Trim().ToUpper())
					&& (Parameters.PhoneNumber == null || Parameters.PhoneNumber.Trim() == "" || x.PhoneNumber.Trim().ToUpper().Contains(Parameters.PhoneNumber.Trim().ToUpper()))
					&& (Parameters.Name == null || Parameters.Name == "" || x.DocumentInformation.Name.Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Name))
					&& (Parameters.Surname == null || Parameters.Surname == "" || x.DocumentInformation.Surname.Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Surname))
					&& (Parameters.Patronymic == null || Parameters.Patronymic == "" || x.DocumentInformation.Patronymic
					  .Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Patronymic)),
					i => i.Branch.Organization, i => i.DocumentInformation, i => i.ContractStatus,
					i => i.OperationType, i => i.User.UserStatus, i => i.Tarif.SubscriptionType)
					.OrderByDescending(x => x.Id).Skip((Parameters.PageNumber - 1) * Parameters.DataCount).Take(Parameters.DataCount)
					.ToList();

				totalCount = _uow.GetRepository<Contract>().Count(x => (Parameters.OrganizationId == 0 || x.Branch.OrganizationId == Parameters.OrganizationId)
					&& (Parameters.BranchId == 0 || x.User.BranchId == Parameters.BranchId)
					&& (Parameters.OperationTypeId == 0 || x.OperationTypeId == Parameters.OperationTypeId)
					&& (Parameters.ContractStatusId == 0 || x.ContractStatusId == Parameters.ContractStatusId)
					&& (Parameters.DocumentPin == null || Parameters.DocumentPin.Trim() == "" || x.DocumentInformation.DocumentPin.Trim().ToUpper() == Parameters.DocumentPin.Trim().ToUpper())
					&& (Parameters.DocumentNumber == null || Parameters.DocumentNumber.Trim() == "" || x.DocumentInformation.DocumentNumber.Trim().ToUpper() == Parameters.DocumentNumber.Trim().ToUpper())
					&& (Parameters.PhoneNumber == null || Parameters.PhoneNumber.Trim() == "" || x.PhoneNumber.Trim().ToUpper().Contains(Parameters.PhoneNumber.Trim().ToUpper()))
					&& (Parameters.Name == null || Parameters.Name == "" || x.DocumentInformation.Name.Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Name))
					&& (Parameters.Surname == null || Parameters.Surname == "" || x.DocumentInformation.Surname.Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Surname))
					&& (Parameters.Patronymic == null || Parameters.Patronymic == "" || x.DocumentInformation.Patronymic
					  .Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Patronymic)));
			}
			else if (currentUser.Role.Level == Levels.ORGANIZATION_LEVEL.ToString())
			{
				contracts = _uow.GetRepository<Contract>().GetAll(x => ((Parameters.BranchId == 0 || x.BranchId == Parameters.BranchId) && x.Branch.OrganizationId == orgId)
					&& (Parameters.OperationTypeId == 0 || x.OperationTypeId == Parameters.OperationTypeId)
					&& (Parameters.ContractStatusId == 0 || x.ContractStatusId == Parameters.ContractStatusId)
					&& (Parameters.DocumentPin == null || Parameters.DocumentPin.Trim() == "" || x.DocumentInformation.DocumentPin.Trim().ToUpper() == Parameters.DocumentPin.Trim().ToUpper())
					&& (Parameters.DocumentNumber == null || Parameters.DocumentNumber.Trim() == "" || x.DocumentInformation.DocumentNumber.Trim().ToUpper() == Parameters.DocumentNumber.Trim().ToUpper())
					&& (Parameters.PhoneNumber == null || Parameters.PhoneNumber.Trim() == "" || x.PhoneNumber.Trim().ToUpper().Contains(Parameters.PhoneNumber.Trim().ToUpper()))
					&& (Parameters.Name == null || Parameters.Name == "" || x.DocumentInformation.Name.Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Name))
					&& (Parameters.Surname == null || Parameters.Surname == "" || x.DocumentInformation.Surname.Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Surname))
					&& (Parameters.Patronymic == null || Parameters.Patronymic == "" || x.DocumentInformation.Patronymic
					  .Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Patronymic)),
					i => i.Branch.Organization, i => i.DocumentInformation, i => i.ContractStatus,
					i => i.OperationType, i => i.User.UserStatus, i => i.Tarif.SubscriptionType)
					.OrderByDescending(x => x.Id).Skip((Parameters.PageNumber - 1) * Parameters.DataCount).Take(Parameters.DataCount)
					.ToList();

				totalCount = _uow.GetRepository<Contract>().Count(x => ((Parameters.BranchId == 0 || x.BranchId == Parameters.BranchId) && x.Branch.OrganizationId == orgId)
					&& (Parameters.OperationTypeId == 0 || x.OperationTypeId == Parameters.OperationTypeId)
					&& (Parameters.ContractStatusId == 0 || x.ContractStatusId == Parameters.ContractStatusId)
					&& (Parameters.DocumentPin == null || Parameters.DocumentPin.Trim() == "" || x.DocumentInformation.DocumentPin.Trim().ToUpper() == Parameters.DocumentPin.Trim().ToUpper())
					&& (Parameters.DocumentNumber == null || Parameters.DocumentNumber.Trim() == "" || x.DocumentInformation.DocumentNumber.Trim().ToUpper() == Parameters.DocumentNumber.Trim().ToUpper())
					&& (Parameters.PhoneNumber == null || Parameters.PhoneNumber.Trim() == "" || x.PhoneNumber.Trim().ToUpper().Contains(Parameters.PhoneNumber.Trim().ToUpper()))
					&& (Parameters.Name == null || Parameters.Name == "" || x.DocumentInformation.Name.Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Name))
					&& (Parameters.Surname == null || Parameters.Surname == "" || x.DocumentInformation.Surname.Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Surname))
					&& (Parameters.Patronymic == null || Parameters.Patronymic == "" || x.DocumentInformation.Patronymic
					  .Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Patronymic)));
			}
			else if ((currentUser.Role.Level == Levels.BRANCH_LEVEL.ToString()))
			{
				contracts = _uow.GetRepository<Contract>().GetAll(x => (x.BranchId == currentUser.BranchId)
					&& (Parameters.OperationTypeId == 0 || x.OperationTypeId == Parameters.OperationTypeId)
					&& (Parameters.ContractStatusId == 0 || x.ContractStatusId == Parameters.ContractStatusId)
					&& (Parameters.DocumentPin == null || Parameters.DocumentPin.Trim() == "" || x.DocumentInformation.DocumentPin.Trim().ToUpper() == Parameters.DocumentPin.Trim().ToUpper())
					&& (Parameters.DocumentNumber == null || Parameters.DocumentNumber.Trim() == "" || x.DocumentInformation.DocumentNumber.Trim().ToUpper() == Parameters.DocumentNumber.Trim().ToUpper())
					&& (Parameters.PhoneNumber == null || Parameters.PhoneNumber.Trim() == "" || x.PhoneNumber.Trim().ToUpper().Contains(Parameters.PhoneNumber.Trim().ToUpper()))
					&& (Parameters.Name == null || Parameters.Name == "" || x.DocumentInformation.Name.Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Name))
					&& (Parameters.Surname == null || Parameters.Surname == "" || x.DocumentInformation.Surname.Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Surname))
					&& (Parameters.Patronymic == null || Parameters.Patronymic == "" || x.DocumentInformation.Patronymic
					  .Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Patronymic)),
					i => i.Branch.Organization, i => i.DocumentInformation, i => i.ContractStatus,
					i => i.OperationType, i => i.User.UserStatus, i => i.Tarif.SubscriptionType)
					.OrderByDescending(x => x.Id).Skip((Parameters.PageNumber - 1) * Parameters.DataCount).Take(Parameters.DataCount)
					.ToList();

				totalCount = _uow.GetRepository<Contract>().Count(x => (x.BranchId == currentUser.BranchId)
					&& (Parameters.OperationTypeId == 0 || x.OperationTypeId == Parameters.OperationTypeId)
					&& (Parameters.ContractStatusId == 0 || x.ContractStatusId == Parameters.ContractStatusId)
					&& (Parameters.DocumentPin == null || Parameters.DocumentPin.Trim() == "" || x.DocumentInformation.DocumentPin.Trim().ToUpper() == Parameters.DocumentPin.Trim().ToUpper())
					&& (Parameters.DocumentNumber == null || Parameters.DocumentNumber.Trim() == "" || x.DocumentInformation.DocumentNumber.Trim().ToUpper() == Parameters.DocumentNumber.Trim().ToUpper())
					&& (Parameters.PhoneNumber == null || Parameters.PhoneNumber.Trim() == "" || x.PhoneNumber.Trim().ToUpper().Contains(Parameters.PhoneNumber.Trim().ToUpper()))
					&& (Parameters.Name == null || Parameters.Name == "" || x.DocumentInformation.Name.Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Name))
					&& (Parameters.Surname == null || Parameters.Surname == "" || x.DocumentInformation.Surname.Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Surname))
					&& (Parameters.Patronymic == null || Parameters.Patronymic == "" || x.DocumentInformation.Patronymic
					  .Trim().Replace("İ", "i").ToUpper().Contains(Parameters.Patronymic)));
			}

			Result.Output.TotalDataCount = totalCount;
			Result.Output.PageCount = Parameters.DataCount > 0 ? (int)Math.Ceiling(((decimal)totalCount / Parameters.DataCount)) : 0;

			Result.Output.Contracts = contracts.Select(x => new ContractsDto
			{
				Id = x.Id,
				Name = x.DocumentInformation.Name,
				Surname = x.DocumentInformation.Surname,
				Patronymic = x.DocumentInformation.Patronymic,
				DocumentNumber = x.DocumentInformation.DocumentNumber,
				DocumentPin = x.DocumentInformation.DocumentPin,
				Photo = File.Exists(Path.Combine(ConfigHelper.GetAppSetting("Photo"), x.DocumentInformation.Photo)) ?
				File.ReadAllBytes(Path.Combine(ConfigHelper.GetAppSetting("Photo"), x.DocumentInformation.Photo)) : null,
				ContactNumber = x.ContactNumber,
				PhoneNumber = x.PhoneNumber,
				OrganizationId = x.Branch.Organization.Id,
				OrganizationName = x.Branch.Organization.Name,
				ContractStatusId = x.ContractStatus.Id,
				ContractStatusName = x.ContractStatus.Name,
				UserStatusId = x.User.UserStatus.Id,
				UserStatusName = x.User.UserStatus.Name,
				BranchId = x.Branch.Id,
				BranchPlaceAddress = x.Branch.PlaceAddress,
				BranchEmail = x.Branch.Email,
				BranchContactNumber = x.Branch.ContactNumber,
				OperationTypeId = x.OperationType.Id,
				OperationTypeName = x.OperationType.Name,
				TarifId = x.Tarif.Id,
				TarifName = x.Tarif.Name,
				SubcriptionTypeId = x.Tarif.SubscriptionType.Id,
				SubcriptionTypeName = x.Tarif.SubscriptionType.Description,
				AddedDate = x.AddedDate
			}).ToList();
		}
	}
}
