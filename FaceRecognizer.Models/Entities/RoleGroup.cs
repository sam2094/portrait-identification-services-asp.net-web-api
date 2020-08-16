using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognizer.Models.Entities
{
	public class RoleGroup : BaseEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int OrganizationId { get; set; }
		public virtual Organization Organization { get; set; }
	}
}
