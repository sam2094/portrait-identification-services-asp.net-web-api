namespace FaceRecognizer.ExternalServices.Models.Azercell
{
	public class AzercellRefreshOutputModelDto
	{
		public string AccessToken { get; set; }
		public string RefreshToken { get; set; }
		public long ExpiresIn { get; set; }
	}
}
