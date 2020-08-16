using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognizer.Models.DTOs.DocumentTypesDto
{
	public class DocumentTypeDto
	{
		public byte Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
