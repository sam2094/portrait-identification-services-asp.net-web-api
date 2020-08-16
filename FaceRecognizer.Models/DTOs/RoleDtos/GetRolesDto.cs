namespace FaceRecognizer.Models.DTOs.RoleDtos
{
    public class GetRolesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Level { get; set; }
        public string RoleGroup { get; set; }
    }
}
