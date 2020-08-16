using System;

namespace FaceRecognizer.BusinessLogic.Logic.Cache
{
	public class PinSessionInfo
	{
		public int Pin { get; set; }
		public DateTime ExpireDate { get; set; }
		public int Attempt { get; set; }
		public bool IsUsed { get; set; }
	}
}
