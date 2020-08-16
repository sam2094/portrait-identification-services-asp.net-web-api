using System;
using System.Collections.Generic;

namespace FaceRecognizer.Models.Entities
{
    public class Organization : BaseEntity
    {
        public Organization()
        {
            Branches = new HashSet<Branch>();
            Tarifs = new HashSet<Tarif>();
            RoleGroups = new HashSet<RoleGroup>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Description { get; set; }
		public string Photo { get; set; }
		public bool IsActive { get; set; }
        public DateTime AddedDate { get; set; }

        public virtual ICollection<Branch> Branches { get; set; }
        public virtual ICollection<RoleGroup> RoleGroups { get; set; }
        public virtual ICollection<Tarif> Tarifs { get; set; }
    }
}
