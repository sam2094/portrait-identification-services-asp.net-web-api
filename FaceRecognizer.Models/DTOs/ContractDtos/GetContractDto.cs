using System;

namespace FaceRecognizer.Models.DTOs.ContractDtos.GetContract
{
	public class GetContractDto
	{
		public ContractDto ContractDto { get; set; }
		public DocumentInformationDto DocumentInformationDto { get; set; }
		public UserDto UserDto { get; set; }
		public BranchDto BranchDto { get; set; }
	}

	public class ContractDto
	{
        public int ContractId { get; set; }
        public byte DocumentTypeId { get; set; }
		public string DocumentTypeName { get; set; }
		public string OperationTypeName { get; set; }
		public byte OperationTypeId { get; set; }
		public byte TarifId { get; set; }
		public string TarifName { get; set; }
		public byte ContractStatusId { get; set; }
		public string ContractStatusName { get; set; }
		public string Contact { get; set; } 
		public string Phone { get; set; } 
        public string Email { get; set; }
		public long IMSI { get; set; }
		public long ICCID { get; set; }
		public string SubsriptionTypeName { get; set; }
		public DateTime AddedDate { get; set; }
		public DateTime UpdateDate { get; set; }
	}

	// Client
	public class DocumentInformationDto
	{
		public int DocumentInformationId { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Patronymic { get; set; }
		public string DocumentPin { get; set; }
		public string DocumentNumber { get; set; }
		public string BirthAddress { get; set; }
		public string DocumentOrganization { get; set; }
		public string RegisterCity { get; set; }
		public string RegisterStreet { get; set; }
		public string RegisterHousing { get; set; }
		public DateTime BirthDate { get; set; }
		public byte[] Photo { get; set; }
        public byte GenderId { get; set; }
        public string GenderName { get; set; }
        public string EventDate { get; set; }

    }

    // Seller
    public class UserDto
	{
		public int UserId { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Patronymic { get; set; }
		public string Username { get; set; }
		public string DocumentPin { get; set; }
		public string DocumentNumber { get; set; }
		public string Contact { get; set; }
		public int UserStatusId { get; set; }
		public string UserStatusName { get; set; }
		public int RoleId { get; set; }
		public string RoleName { get; set; }
		public bool IsFaceRecognize { get; set; }
		public byte[] Photo { get; set; }
	}

	public class BranchDto
	{
		public int BranchId { get; set; }
		public int OrganizationId { get; set; }
		public string OrganizationName { get; set; }
		public string Code { get; set; }
		public string PlaceName { get; set; }
		public string PlaceAddress { get; set; }
		public string ContactNumber { get; set; }
		public string Email { get; set; }
	}
}
