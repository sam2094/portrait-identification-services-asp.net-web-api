using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognizer.Models.DTOs.UserDtos
{
	public class GetUserByIdDto
	{
		public int Id { get; set; }
		public byte UserStatusId { get; set; }
		public int ParentId { get; set; }
		public int BranchId { get; set; }
		public int OrganizationId { get; set; }
		public int RoleId { get; set; }
		public string RoleName { get; set; }
		public int RoleGroupId { get; set; }
		public string RoleGroupName { get; set; }
		public string DocumentNumber { get; set; }
		public string DocumentPin { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Patronymic { get; set; }
		public string UserStatusName { get; set; }
		public string BranchName { get; set; }
		public string OrganizationName { get; set; }
		public byte[] Photo { get; set; }
		public string Contact { get; set; }
		public string Username { get; set; }
		public bool IsFaceRecognized { get; set; }
		public DateTime AddedDate { get; set; }
	}
}
