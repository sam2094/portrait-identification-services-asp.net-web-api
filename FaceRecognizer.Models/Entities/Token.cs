using System;

namespace FaceRecognizer.Models.Entities
{
    public class Token :  BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public byte TokenStatusId { get; set; }
        public string Value { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ExpireDate { get; set; }

        public virtual User User { get; set; }
        public virtual TokenStatus TokenStatus { get; set; }
    }
}
