using FaceRecognizer.Models.DTOs.UserDtos;
using System.Collections.Generic;

namespace FaceRecognizer.Models.LogicParameters.UserLogic
{
	public class GetUsersInput : LogicInput
	{
		public string DocumentNumber { get; set; }
		public string DocumentPin { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Patronymic { get; set; }
		public byte UserStatusId { get; set; }
		public int RoleId { get; set; }
		public int RoleGroupId { get; set; }
		public int BranchId { get; set; }
		public int OrganizationId { get; set; }
		public string Contact { get; set; }
		public int PageNumber { get; set; }
		public int DataCount { get; set; }
	}
	public class GetUsersOutput : LogicOutput
	{
		public List<UsersDto> Users { get; set; }
		public int TotalDataCount { get; set; }
		public int PageCount { get; set; }
	}
}