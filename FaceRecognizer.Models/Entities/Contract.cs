using System;
using System.Collections.Generic;

namespace FaceRecognizer.Models.Entities
{
	public class Contract : BaseEntity
	{
		public Contract()
		{
			ContractFiles = new HashSet<ContractFile>();
		}

		public int Id { get; set; }
		public int UserId { get; set; }
		public int DocumentInformationId { get; set; }
		public byte ContractStatusId { get; set; }
		public byte OperationTypeId { get; set; }
		public byte TarifId { get; set; }
		public int BranchId { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public string ContactNumber { get; set; }
		public DateTime AddedDate { get; set; }
		public DateTime UpdateDate { get; set; }
		public long IMSI { get; set; }
		public bool IsSendEmail { get; set; }
		public bool IsSendAddress { get; set; }
		public bool IsExplanatoryContracts { get; set; }
		public bool IsRefrainAdvertising { get; set; }
		public string DeliveryAddress { get; set; }
		public string Index { get; set; }
		public long ICCID { get; set; }
		public virtual User User { get; set; }
		public virtual ContractStatus ContractStatus { get; set; }
		public virtual DocumentInformation DocumentInformation { get; set; }
		public virtual OperationType OperationType { get; set; }
		public virtual Tarif Tarif { get; set; }
		public virtual Branch Branch { get; set; }
		public virtual ICollection<ContractFile> ContractFiles { get; set; }

	}
}
