using System;
using System.Collections.Generic;

namespace FaceRecognizer.Models.Entities
{
    public class Role : BaseEntity
    {
        public Role()
        {
            Claims = new HashSet<Claim>();
            Users = new HashSet<User>();
        }
        public int Id { get; set; }
        public int RoleGroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public string Level { get; set; }
        public DateTime AddedDate { get; set; }

        public virtual ICollection<Claim> Claims { get; set; }
        public virtual ICollection<User> Users { get; set; }
		public virtual RoleGroup RoleGroup { get; set; }
    }
}
