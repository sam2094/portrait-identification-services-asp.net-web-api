using FaceRecognizer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognizer.Models.DTOs.RoleDtos
{
	public class GetRoleGroupsDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int OrganizationId { get; set; }
		public string OrganizationName { get; set; }
	}
}
