namespace FaceRecognizer.Models.Entities
{
	public class ContractFile : BaseEntity
	{
		public int Id { get; set; }
		public int ContractId { get; set; }
		public byte ContractFileTypeId { get; set; }
		public string ContractFileName { get; set; }
		public byte[] ContractRawData { get; set; }
		public virtual Contract Contract { get; set; }
		public virtual ContractFileType ContractFileType { get; set; }

	}
}
