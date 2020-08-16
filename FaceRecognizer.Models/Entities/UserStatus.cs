using System.Collections.Generic;

namespace FaceRecognizer.Models.Entities
{
    public class UserStatus : BaseEntity
    {
        public UserStatus()
        {
            Users = new HashSet<User>();
        }
        public byte Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
