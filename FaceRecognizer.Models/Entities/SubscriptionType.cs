using System.Collections;
using System.Collections.Generic;

namespace FaceRecognizer.Models.Entities
{
    public class SubscriptionType : BaseEntity
    {
        public SubscriptionType()
        {
            Tarifs = new HashSet<Tarif>();
        }
        public byte Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Tarif> Tarifs { get; set; }
    }
}
