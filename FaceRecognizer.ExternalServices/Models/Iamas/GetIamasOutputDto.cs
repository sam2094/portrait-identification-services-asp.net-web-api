using System;

namespace FaceRecognizer.ExternalServices.Models
{
    public class GetIamasOutputDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime? BirthDate { get; set; }
		public string Gender { get; set; }
		public string BirthAddress { get; set; }
		public DateTime? EventDate { get; set; }
		public DateTime? ExpDate { get; set; }
		public string Image { get; set; }
        public bool IsActive { get; set; }
        public IamasResultStatusDto ResultStatus { get; set; }
		public PoliceDeptDto PoliceDept { get; set; }
		public RegisteredAddressDetailDto RegisteredAddressDetail { get; set; }
	}
}
