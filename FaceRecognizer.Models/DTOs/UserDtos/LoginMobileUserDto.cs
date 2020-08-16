namespace FaceRecognizer.Models.DTOs.UserDtos
{
    public class LoginMobileUserDto
    {
        public string Token { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
		public string UserRoleGroup { get; set; }
	}
}
