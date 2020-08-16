namespace FaceRecognizer.Models.LogicParameters.UserLogic
{
	public class PasswordResetInput : LogicInput
	{
		public int UserId { get; set; }
	}

	public class PasswordResetOutput : LogicOutput
	{
	}
}