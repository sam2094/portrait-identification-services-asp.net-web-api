using FaceRecognizer.ExternalServices.Enums;
using System;

namespace FaceRecognizer.ExternalServices.Models
{
    public class PersonData
    {
        public string FullName => $"{Firstname} {Lastname} {Patronymic}";
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public string Pin { get; set; }
        public string Serial { get; set; }
        public string City { get; set; }
        public GenderTypes Gender { get; set; }
        public string BirthPlace { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string IssuedOrganization { get; set; }
        public string Address { get; set; }
        public byte[] Picture { get; set; }
    }
}
