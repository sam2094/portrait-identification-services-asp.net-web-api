using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognizer.Models.Entities
{
    public class Gender
    {
        public Gender()
        {
            DocumentInformations = new HashSet<DocumentInformation>();
        }
        public byte Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<DocumentInformation> DocumentInformations { get; set; }
    }
}
