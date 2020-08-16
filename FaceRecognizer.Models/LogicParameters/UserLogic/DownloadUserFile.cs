namespace FaceRecognizer.Models.LogicParameters.UserLogic
{
	public class DownloadUserFileInput : LogicInput
	{
		public int UserId { get; set; }
		public int UserFileTypeId { get; set; }
	}

	public class DownloadUserFileOutput : LogicOutput
	{
		public byte[] UserFile { get; set; }
	}
}
