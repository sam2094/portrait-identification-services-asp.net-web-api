using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognizer.Models.DTOs.SubscriptionTypesDto
{
	public class SubscriptionTypeDto
	{
		public byte Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsActive { get; set; }
	}
}
