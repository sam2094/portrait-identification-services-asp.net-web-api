using FaceRecognizer.Models.DTOs.ClaimDtos;
using FaceRecognizer.Models.Entities;
using System;
using System.Collections.Generic;

namespace FaceRecognizer.Models.DTOs.UserDtos
{
    public class UsersDto
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public int RoleId { get; set; }
		public string RoleName { get; set; }
		public int RoleGroupId { get; set; }
		public string RoleGroupName { get; set; }
		public string DocumentNumber { get; set; }
        public string DocumentPin { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string BranchName { get; set; }
        public string PlaceCode { get; set; }
        public string UserStatusName { get; set; }
        public string UserOrganizationName { get; set; }
        public string Contact { get; set; }
        public byte UserStatusId { get; set; }
        public string Username { get; set; }
        public byte[] Photo { get; set; }
        public byte[] Cerficate { get; set; }
        public bool IsFaceRecognized { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
