namespace FaceRecognizer.ExternalServices.Models.Azercell
{
	public class UploadAzercellContractInputDto
	{
		public string Pin { get; set; }
		public byte[] RawData { get; set; }
		public string FileName { get; set; }
		public string Msisdn { get; set; }

	}
}
