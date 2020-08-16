using FaceRecognizer.ExternalServices.Enums;

namespace FaceRecognizer.ExternalServices.Models
{
    public class GetIamasInputDto
    {
        public string DocumentNumber { get; set; }
        public string Pin { get; set; }
        public byte Lang { get; set; }
        public DocType DocType { get; set; }
    }
}
