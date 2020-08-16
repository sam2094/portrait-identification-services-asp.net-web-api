using FaceRecognizer.Models.Entities;
using System;
using System.Collections.Generic;

namespace FaceRecognizer.BusinessLogic.Logic.Cache
{
	public class TokenSessionInfo
	{
		public int UserId { get; set; }
		public DateTime ExpireDate { get; set; }
		public List<Claim> Claims { get; set; }
	}
}
