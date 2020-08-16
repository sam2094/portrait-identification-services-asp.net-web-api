
namespace FaceRecognizer.Models.LogicParameters.ContractLogic
{
	public class DownloadContractInput : LogicInput
	{
		public int ContractId { get; set; }
		public byte ContractFileTypeId { get; set; }
	}

	public class DownloadContractOutput : LogicOutput
	{
		public byte[] Contract { get; set; }
	}
}
