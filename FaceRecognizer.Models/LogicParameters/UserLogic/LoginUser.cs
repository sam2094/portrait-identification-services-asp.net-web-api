namespace FaceRecognizer.Models.LogicParameters.UserLogic
{
    public class LoginUserInput : LogicInput
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginUserOutput : LogicOutput
    {
        public string Token { get; set; }
        public int UserId { get; set; }
        public string UserRoleGroup { get; set; }
    }
}
