using System.Collections.Generic;

namespace FaceRecognizer.Models.Entities
{
	public class ContractFileType : BaseEntity
	{
		public ContractFileType()
		{
			ContractFiles = new HashSet<ContractFile>();
		}

		public byte Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public virtual ICollection<ContractFile> ContractFiles { get; set; }
	}
}
