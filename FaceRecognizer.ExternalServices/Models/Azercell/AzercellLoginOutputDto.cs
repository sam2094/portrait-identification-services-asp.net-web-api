namespace FaceRecognizer.ExternalServices.Models.Azercell
{
	public class AzercellLoginOutputDto
	{
		public string access_token { get; set; }
		public string refresh_token { get; set; }
		public long expires_in { get; set; }
		public long refresh_expires_in { get; set; }
		public string message { get; set; }
		public int status { get; set; }
	}
}
