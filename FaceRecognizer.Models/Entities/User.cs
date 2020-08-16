using System;
using System.Collections.Generic;

namespace FaceRecognizer.Models.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            Tokens = new HashSet<Token>();
            Contracts = new HashSet<Contract>();
			UserFiles = new HashSet<UserFile>();
        }

        public int Id { get; set; }
        public byte UserStatusId { get; set; }
        public int ParentId { get; set; }
        public int BranchId { get; set; }
        public int RoleId { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentPin { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; } 
        public string Patronymic { get; set; }
        public string Contact { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public byte[] Cerficate { get; set; }
        public bool IsFaceRecognized { get; set; }
        public string Photo { get; set; }
        public DateTime AddedDate { get; set; }
        public virtual UserStatus UserStatus { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Token> Tokens { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
		public virtual ICollection<UserFile> UserFiles { get; set; }

	}
}
