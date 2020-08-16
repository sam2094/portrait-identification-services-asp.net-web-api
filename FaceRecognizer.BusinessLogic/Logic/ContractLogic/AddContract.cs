using System;
using System.IO;
using System.Text;
using FaceRecognizer.Common;
using FaceRecognizer.Common.Enums;
using FaceRecognizer.Common.Enums.CommonEnums;
using FaceRecognizer.Common.Enums.DatabaseEnums;
using FaceRecognizer.Common.Enums.DatabaseEnums.RoleEnums;
using FaceRecognizer.Common.Helpers;
using FaceRecognizer.Common.Resources;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.ContractLogic;

namespace FaceRecognizer.BusinessLogic.Logic.ContractLogic
{
    public class AddContract : Logic<AddContractInput, AddContractOutput>
	{
		public AddContract(IUnitofWork uow,
			string firstExecutedLogicName,
			bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		public override void DoExecute()
		{
			GetDto data = Data.GetData(
				Parameters.DocumentNumber.Trim().ToUpper(),
				Parameters.DocumentPin.Trim().ToUpper(),
				Parameters.DocType);

			if (data?.ResultStatus?.Code == (int)ErrorHttpStatus.INTERNAL)
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.INPUT_IS_NOT_VALID,
					ErrorMessage = Resource.INPUT_IS_NOT_VALID,
					StatusCode = ErrorHttpStatus.INTERNAL
				});
				return;
			}

			if (data == null || data.ResultStatus?.Code != (int)ErrorHttpStatus.WARNING || !data.IsActive)
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.INPUT_IS_NOT_VALID,
					ErrorMessage = Resource.INPUT_IS_NOT_VALID,
					StatusCode = ErrorHttpStatus.NOT_FOUND
				});
				return;
			}

			if (!_uow.GetRepository<DocumentType>()
				 .IsExist(x => x.Id == Parameters.DocumentTypeId))
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.DOCUMENT_TYPE_IS_NOT_EXIST,
					ErrorMessage = Resource.DOCUMENT_TYPE_IS_NOT_EXIST,
					StatusCode = ErrorHttpStatus.NOT_FOUND
				});
				return;
			}

			if (!_uow.GetRepository<Tarif>()
				 .IsExist(x => x.Id == Parameters.TarifId))
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.TARIF_IS_NOT_EXIST,
					ErrorMessage = Resource.TARIF_IS_NOT_EXIST,
					StatusCode = ErrorHttpStatus.NOT_FOUND
				});
				return;
			}

			if (!_uow.GetRepository<OperationType>()
				 .IsExist(x => x.Id == Parameters.OperationTypeId))
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.OPERATION_TYPE_IS_NOT_EXIST,
					ErrorMessage = Resource.OPERATION_TYPE_IS_NOT_EXIST,
					StatusCode = ErrorHttpStatus.NOT_FOUND
				});
				return;
			}

			if (!_uow.GetRepository<Citizenship>()
				 .IsExist(x => x.Id == Parameters.CitizenshipId))
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.CITIZENSHIP_DOES_NOT_EXIST,
					ErrorMessage = Resource.CITIZENSHIP_DOES_NOT_EXIST,
					StatusCode = ErrorHttpStatus.NOT_FOUND
				});
				return;
			}

			if (!_uow.GetRepository<Branch>().IsExist(x => x.Id == Parameters.BranchId))
			{
				Result.ErrorList.Add(new Error()
				{
					ErrorCode = ErrorCodes.BRANCH_IS_NOT_EXIST,
					ErrorMessage = Resource.BRANCH_IS_NOT_EXIST,
					StatusCode = ErrorHttpStatus.NOT_FOUND
				});
				return;
			}

			DocumentInformation documentInformation = _uow.GetRepository<DocumentInformation>().Get(x => x.DocumentPin.Trim() == Parameters.DocumentPin.Trim().ToUpper()
			 && x.DocumentNumber.Trim() == Parameters.DocumentNumber.Trim().ToUpper());

			if (documentInformation == null)
			{
				string photoName = string.Concat(Guid.NewGuid().ToString("N"), ".jpg");
				File.WriteAllBytes(Path.Combine(ConfigHelper.GetAppSetting("Photo"), photoName), Encoding.ASCII.GetBytes(data.Image));
				documentInformation = new DocumentInformation
				{
					Name = data.Name,
					Surname = data.Surname,
					DocumentPin = Parameters.DocumentPin.Trim().ToUpper(),
					DocumentNumber = Parameters.DocumentNumber.Trim().ToUpper(),
					BirthDate = data.BirthDate ?? DateTime.Now,
					Patronymic = data.Patronymic,
					DocumentTypeId = Parameters.DocumentTypeId,
					Photo = photoName,
					BirthAddress = data.BirthAddress,
					DocumentOrganization = data.PoliceDept.Name,
					RegisterCity = data.RegisteredAddressDetail.CityName,
					RegisterStreet = data.RegisteredAddressDetail.Street,
					RegisterHousing = data.RegisteredAddressDetail.Building,
					EventDate = data.EventDate.ToString(),
					ExpireDate = data.ExpDate.ToString(),
					GenderName = data.Gender,
					DocumentSeries = "TEST", // TODO
					CitizenshipId = Parameters.CitizenshipId,
					GenderId = data.Gender == "Kişi" ? (byte)2 : (byte)1
				};
				_uow.GetRepository<DocumentInformation>().Add(documentInformation);
				_uow.SaveChanges();
			}

			Contract duplicateContract = _uow.GetRepository<Contract>().Get(x => x.PhoneNumber == Parameters.Phone && x.ContractStatusId == (byte)ContractStatuses.APPROVED);
			if (duplicateContract != null)
			{
				duplicateContract.ContractStatusId = (byte)ContractStatuses.ARCHIVED;
				_uow.SaveChanges();
			}

			Contract contract = new Contract
			{
				UserId = Parameters.CurrentUserId,
				DocumentInformationId = documentInformation.Id,
				OperationTypeId = Parameters.OperationTypeId,
				ContractStatusId = (byte)ContractStatuses.NEW,
				PhoneNumber = Parameters.Phone,
				Email = Parameters.Email.Trim(),
				ContactNumber = Parameters.Contact,
				AddedDate = DateTime.Now,
				UpdateDate = DateTime.Now,
				IMSI = Parameters.IMSI,
				ICCID = Parameters.ICCID,
				TarifId = Parameters.TarifId,
				DeliveryAddress = Parameters.DeliveryAddress,
				IsSendEmail = Parameters.IsSendEmail,
				IsSendAddress = Parameters.IsSendAddress,
				IsExplanatoryContracts = Parameters.IsExplanatoryContracts,
				IsRefrainAdvertising = Parameters.IsRefrainAdvertising,
				Index = "TEST" // TODO 
			};

			User currentUser = _uow.GetRepository<User>().Get(x => x.Id == Parameters.CurrentUserId, i => i.Role, i => i.Branch);
			int orgId = _uow.GetRepository<Branch>().Get(x => x.Id == Parameters.BranchId, i => i.Organization).Organization.Id;
			bool isSuperAdmin = currentUser.RoleId == (int)Roles.SUPER_ADMIN ? true : false;

			if (isSuperAdmin)
			{
				contract.BranchId = Parameters.BranchId;
			}
			else if (currentUser.Role.Level == Levels.ORGANIZATION_LEVEL.ToString())
			{
				if (_uow.GetRepository<Branch>().IsExist(x => x.OrganizationId == orgId && currentUser.Branch.OrganizationId == orgId))
				{
					contract.BranchId = Parameters.BranchId;
				}
				else
				{
					Result.ErrorList.Add(new Error()
					{
						ErrorCode = ErrorCodes.ACCESS_DENIED,
						ErrorMessage = Resource.ACCESS_DENIED,
						StatusCode = ErrorHttpStatus.FORBIDDEN
					});
					return;
				}
			}
			else if ((currentUser.Role.Level == Levels.BRANCH_LEVEL.ToString() && currentUser.BranchId == Parameters.BranchId))
			{
				contract.BranchId = currentUser.BranchId;
			}
			else
			{
				Result.ErrorList.Add(new Error()
				{
					ErrorCode = ErrorCodes.ACCESS_DENIED,
					ErrorMessage = Resource.ACCESS_DENIED,
					StatusCode = ErrorHttpStatus.FORBIDDEN
				});
				return;
			}
			_uow.GetRepository<Contract>().Add(contract);
			_uow.SaveChanges();

			Result.Output.ContractId = contract.Id;
		}
	}
}
