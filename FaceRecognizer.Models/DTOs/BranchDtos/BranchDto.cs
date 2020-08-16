using System;

namespace FaceRecognizer.Models.DTOs.BranchDtos
{
	public class BranchDto
    {
		public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public byte RegionId { get; set; }
        public string RegionName { get; set; }
        public string Code { get; set; }
        public string PlaceName { get; set; }
        public string PlaceAddress { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
		public byte[] Photo { get; set; }
		public DateTime AddedDate { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
