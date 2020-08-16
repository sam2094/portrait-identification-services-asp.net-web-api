using System;

namespace FaceRecognizer.Models.DTOs.OrganizationDto
{
    public class OrganizationsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contacts { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime AddedDate { get; set; }
        public byte[] Photo { get; set; }
    }
}
