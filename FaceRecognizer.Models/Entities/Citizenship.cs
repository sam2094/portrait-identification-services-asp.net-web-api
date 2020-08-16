using System.Collections.Generic;

namespace FaceRecognizer.Models.Entities
{
    public class Citizenship : BaseEntity
        
    {
        public Citizenship()
        {
            DocumentInformations = new HashSet<DocumentInformation>();
        }
        public byte Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<DocumentInformation> DocumentInformations { get; set; }
    }
}
