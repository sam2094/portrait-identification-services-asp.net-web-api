using System;
using System.Collections.Generic;

namespace FaceRecognizer.Models.Entities
{
    public class Region : BaseEntity
    {
        public Region()
        {
            Branches = new HashSet<Branch>();
        }
        public byte Id { get; set; }
        public byte ParentId { get; set; }
        public string Name { get; set; }
        public DateTime AddedDate { get; set; }

        public virtual ICollection<Branch> Branches { get; set; }
    }
}
