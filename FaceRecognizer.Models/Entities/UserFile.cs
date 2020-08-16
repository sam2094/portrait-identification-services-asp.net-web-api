namespace FaceRecognizer.Models.Entities
{
	public class UserFile : BaseEntity
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public byte UserFileTypeId { get; set; }
		public string UserFileName { get; set; }
		public byte[] UserRawData { get; set; }
		public virtual User User { get; set; }
		public virtual UserFileType UserFileType { get; set; }
	}
}
