using System;
using System.Collections.Generic;

namespace FaceRecognizer.Models.Entities
{
    public class DocumentInformation : BaseEntity
    {
        public int Id { get; set; }
        public byte DocumentTypeId { get; set; }
        public byte CitizenshipId { get; set; }
        public byte GenderId { get; set; }
        public string GenderName { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentPin { get; set; }
        public string DocumentSeries { get; set; }
        public string BirthAddress { get; set; }
        public string DocumentOrganization { get; set; }
        public string RegisterCity { get; set; }
        public string RegisterStreet { get; set; }
        public string RegisterHousing { get; set; }
        public string EventDate { get; set; }
        public string ExpireDate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
		public string Photo { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual DocumentType DocumentType { get; set; }
        public virtual Citizenship Citizenship { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
