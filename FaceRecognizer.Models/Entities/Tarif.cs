using System.Collections.Generic;

namespace FaceRecognizer.Models.Entities
{
    public class Tarif : BaseEntity
    {
        public Tarif()
        {
            Contracts = new HashSet<Contract>();
        }
        public byte Id { get; set; }
        public byte OrganizationId { get; set; }
        public byte SubscriptionTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual SubscriptionType SubscriptionType { get; set; }
    }
}
