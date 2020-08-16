using System;
using System.Collections.Generic;

namespace FaceRecognizer.Models.Entities
{
    public class Claim : BaseEntity
    {
        public Claim()
        {
            Roles = new HashSet<Role>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
