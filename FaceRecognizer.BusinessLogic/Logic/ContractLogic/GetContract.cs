using FaceRecognizer.Common;
using FaceRecognizer.Common.Enums;
using FaceRecognizer.Common.Enums.CommonEnums;
using FaceRecognizer.Common.Enums.DatabaseEnums.RoleEnums;
using FaceRecognizer.Common.Helpers;
using FaceRecognizer.Common.Resources;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.DTOs.ContractDtos.GetContract;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.ContractLogic;
using System.IO;

namespace FaceRecognizer.BusinessLogic.Logic.ContractLogic
{
	public class GetContract : Logic<GetContractInput, GetContractOutput>
	{
		public GetContract(IUnitofWork uow,
				string firstExecutedLogicName,
				bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		public override void DoExecute()
		{
			User currentUser = _uow.GetRepository<User>().Get(x => x.Id == Parameters.CurrentUserId, i => i.Role, i => i.Branch);
			bool isSuperAdmin = currentUser.RoleId == (int)Roles.SUPER_ADMIN ? true : false;
			int orgId = _uow.GetRepository<User>().Get(x => x.Id == currentUser.Id, i => i.Branch).Branch.OrganizationId;

			Contract contract = null;

			if (isSuperAdmin)
			{
				contract = _uow.GetRepository<Contract>().Get(x => x.Id == Parameters.ContractId,
					i => i.OperationType, i => i.DocumentInformation.Gender,
					i => i.DocumentInformation.DocumentType, i => i.ContractStatus,
					i => i.Tarif.SubscriptionType, i => i.User.UserStatus,
					i => i.User.Role, i => i.Branch.Organization);
			}
			else if (currentUser.Role.Level == Levels.ORGANIZATION_LEVEL.ToString())
			{
				contract = _uow.GetRepository<Contract>().Get(x => x.Id == Parameters.ContractId && x.Branch.OrganizationId == orgId,
					i => i.OperationType, i => i.DocumentInformation.Gender,
					i => i.DocumentInformation.DocumentType, i => i.ContractStatus,
					i => i.Tarif.SubscriptionType, i => i.User.UserStatus,
					i => i.User.Role, i => i.Branch.Organization);
			}
			else if ((currentUser.Role.Level == Levels.BRANCH_LEVEL.ToString()))
			{
				contract = _uow.GetRepository<Contract>().Get(x => x.Id == Parameters.ContractId && x.BranchId == currentUser.BranchId,
					i => i.OperationType, i => i.DocumentInformation.Gender,
					i => i.DocumentInformation.DocumentType, i => i.ContractStatus,
					i => i.Tarif.SubscriptionType, i => i.User.UserStatus,
					i => i.User.Role, i => i.Branch.Organization);
			}

			if (contract == null)
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.CONTRACT_IS_NOT_EXIST,
					ErrorMessage = Resource.CONTRACT_IS_NOT_EXIST,
					StatusCode = ErrorHttpStatus.NOT_FOUND
				});
				return;
			}

			// Contract
			ContractDto contractDto = new ContractDto
			{
				ContractId = contract.Id,
				DocumentTypeId = contract.DocumentInformation.DocumentType.Id,
				DocumentTypeName = contract.DocumentInformation.DocumentType.Name,
				OperationTypeId = contract.OperationType.Id,
				OperationTypeName = contract.OperationType.Name,
				TarifId = contract.Tarif.Id,
				TarifName = contract.Tarif.Name,
				ContractStatusId = contract.ContractStatus.Id,
				ContractStatusName = contract.ContractStatus.Name,
				Contact = contract.ContactNumber,
				Phone = contract.PhoneNumber,
				Email = contract.Email,
				IMSI = contract.IMSI,
				ICCID = contract.ICCID,
				SubsriptionTypeName = contract.Tarif.SubscriptionType.Name,
				AddedDate = contract.AddedDate,
				UpdateDate = contract.UpdateDate
			};
			// Client
			DocumentInformationDto documentInformationDto = new DocumentInformationDto
			{
				DocumentInformationId = contract.DocumentInformation.Id,
				Name = contract.DocumentInformation.Name,
				Surname = contract.DocumentInformation.Surname,
				Patronymic = contract.DocumentInformation.Patronymic,
				DocumentPin = contract.DocumentInformation.DocumentPin,
				DocumentNumber = contract.DocumentInformation.DocumentNumber,
				BirthAddress = contract.DocumentInformation.BirthAddress,
				DocumentOrganization = contract.DocumentInformation.DocumentOrganization,
				RegisterCity = contract.DocumentInformation.RegisterCity,
				RegisterStreet = contract.DocumentInformation.RegisterStreet,
				RegisterHousing = contract.DocumentInformation.RegisterHousing,
				BirthDate = contract.DocumentInformation.BirthDate,
				Photo = File.Exists(Path.Combine(ConfigHelper.GetAppSetting("Photo"), contract.DocumentInformation.Photo)) ?
				File.ReadAllBytes(Path.Combine(ConfigHelper.GetAppSetting("Photo"), contract.DocumentInformation.Photo)) : null,
				GenderId = contract.DocumentInformation.Gender.Id,
				GenderName = contract.DocumentInformation.Gender.Name,
				EventDate = contract.DocumentInformation.EventDate,
			};

			// Seller
			UserDto userDto = new UserDto
			{
				UserId = contract.UserId,
				Name = contract.User.Name,
				Surname = contract.User.Surname,
				Patronymic = contract.User.Patronymic,
				Username = contract.User.Username,
				DocumentPin = contract.User.DocumentPin,
				DocumentNumber = contract.User.DocumentNumber,
				Contact = contract.User.Contact,
				UserStatusId = contract.User.UserStatus.Id,
				UserStatusName = contract.User.UserStatus.Name,
				RoleId = contract.User.Role.Id,
				RoleName = contract.User.Role.Name,
				IsFaceRecognize = contract.User.IsFaceRecognized,
				Photo = File.Exists(Path.Combine(ConfigHelper.GetAppSetting("Photo"), contract.User.Photo)) ?
				File.ReadAllBytes(Path.Combine(ConfigHelper.GetAppSetting("Photo"), contract.User.Photo)) : null
			};

			// Branch (dealer)
			BranchDto branchDto = new BranchDto
			{
				BranchId = contract.Branch.Id,
				Code = contract.Branch.Code,
				PlaceName = contract.Branch.PlaceName,
				PlaceAddress = contract.Branch.PlaceAddress,
				ContactNumber = contract.Branch.ContactNumber,
				Email = contract.Branch.Email,
				OrganizationId = contract.Branch.OrganizationId,
				OrganizationName = contract.Branch.Organization.Name
			};

			Result.Output.Contract = new GetContractDto
			{
				ContractDto = contractDto,
				DocumentInformationDto = documentInformationDto,
				UserDto = userDto,
				BranchDto = branchDto
			};
		}
	}
}
