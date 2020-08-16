using System;

namespace FaceRecognizer.Models.DTOs.ContractDtos
{
    public class ContractsDto
    {
        public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Patronymic { get; set; }
		public string DocumentNumber { get; set; }
        public string DocumentPin { get; set; }
		public string ContactNumber { get; set; }
		public string PhoneNumber { get; set; }
		public DateTime AddedDate { get; set; }
		public int OrganizationId { get; set; }
		public string OrganizationName { get; set; }
		public byte ContractStatusId { get; set; }
		public string ContractStatusName { get; set; }
		public byte UserStatusId { get; set; }
		public string UserStatusName { get; set; }
		public int BranchId { get; set; }
		public string BranchPlaceAddress { get; set; }
		public string BranchEmail { get; set; }
		public string BranchContactNumber { get; set; }
		public byte OperationTypeId { get; set; }
		public string OperationTypeName { get; set; }
		public byte TarifId { get; set; }
		public string TarifName { get; set; }
		public byte[] Photo { get; set; }
		public byte SubcriptionTypeId { get; set; }
		public string SubcriptionTypeName { get; set; }
	}
}
