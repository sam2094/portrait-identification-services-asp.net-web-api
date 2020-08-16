using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognizer.ExternalServices.Models
{
	public class RegisteredAddressDetailDto
	{
		public string Address { get; set; }
		public string Apartment { get; set; }
		public string Block { get; set; }
		public string Building { get; set; }
		public int City { get; set; }
		public string CityName { get; set; }
		public int Country { get; set; }
		public string CountryName { get; set; }
		public int District { get; set; }
		public string DistrictName { get; set; }
		public string ForeignCity { get; set; }
		public string Place { get; set; }
		public int Province { get; set; }
		public string Street { get; set; }
	}
}
