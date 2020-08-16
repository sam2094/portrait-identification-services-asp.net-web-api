using System;
using System.Collections.Generic;

namespace FaceRecognizer.Models.Entities
{
    public class Branch : BaseEntity
    {
        public Branch()
        {
            Users = new HashSet<User>();
            Contracts = new HashSet<Contract>();
        }

        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public byte RegionId { get; set; }
		public string Code { get; set; }
        public string PlaceName { get; set; }
        public string PlaceAddress { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual Region Region { get; set; }

    }
}
