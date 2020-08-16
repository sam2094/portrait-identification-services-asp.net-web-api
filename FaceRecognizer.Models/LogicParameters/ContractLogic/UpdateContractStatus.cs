namespace FaceRecognizer.Models.LogicParameters.ContractLogic
{
	public class UpdateContractStatusInput : LogicInput
	{
		public int ContractId { get; set; }
		public byte ContractStatusId { get; set; }
	}

	public class UpdateContractStatusOutput : LogicOutput { }
}
