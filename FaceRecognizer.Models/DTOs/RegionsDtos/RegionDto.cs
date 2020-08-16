using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognizer.Models.DTOs.RegionsDto
{
    public class RegionDto
    {
        public byte Id { get; set; }
        public byte ParentId { get; set; }
        public string Name { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
