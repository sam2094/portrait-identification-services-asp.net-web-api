using FaceRecognizer.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FaceRecognizer.DataAccess.Database.EntityConfigurations
{
    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            ToTable("Roles", "dbo");

            Property(e => e.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(true);

            Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(true);

            Property(e => e.Level)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            Property(e => e.AddedDate)
                .IsRequired();

            HasMany(e => e.Claims)
                .WithMany(e => e.Roles)
                .Map(m => m.ToTable("RolesClaims")
                .MapLeftKey("RoleId")
                .MapRightKey("ClaimId"));

            HasMany(e => e.Users)
               .WithRequired(t => t.Role)
               .HasForeignKey(t => t.RoleId)
               .WillCascadeOnDelete(false);
        }
    }
}
