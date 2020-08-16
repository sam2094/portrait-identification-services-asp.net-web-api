using System.Collections.Generic;

namespace FaceRecognizer.Models.Entities
{
    public class ContractStatus : BaseEntity
    {
        public ContractStatus()
        {
            Contracts = new HashSet<Contract>();
        }
        public byte Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
