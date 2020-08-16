using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognizer.Models.Entities
{
	public class UserFileType : BaseEntity
	{
		public UserFileType()
		{
			UserFiles = new HashSet<UserFile>();
		}

		public byte Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public virtual ICollection<UserFile> UserFiles { get; set; }
	}
}
