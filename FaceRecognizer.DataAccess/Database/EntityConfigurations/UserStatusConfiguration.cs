using FaceRecognizer.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FaceRecognizer.DataAccess.Database.EntityConfigurations
{
    public class UserStatusConfiguration : EntityTypeConfiguration<UserStatus>
    {
        public UserStatusConfiguration()
        {
            ToTable("UserStatuses", "status");

            Property(e => e.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            Property(e => e.Description)
                .HasMaxLength(255)
                .IsRequired()
                .IsUnicode(false);

            HasMany(e => e.Users)
                .WithRequired(e => e.UserStatus)
                .HasForeignKey(e => e.UserStatusId)
                .WillCascadeOnDelete(false);
        }
    }
}
