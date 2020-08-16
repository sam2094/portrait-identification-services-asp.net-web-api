using FaceRecognizer.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FaceRecognizer.DataAccess.Database.EntityConfigurations
{
    public class CitizenshipConfiguration : EntityTypeConfiguration<Citizenship>
        {
            public CitizenshipConfiguration()
            {
                ToTable("Citizenship", "dbo");

                Property(e => e.Id)
                    .IsRequired()
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

                Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(true);

                Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(true);

                HasMany(e => e.DocumentInformations)
                    .WithRequired(t => t.Citizenship)
                    .HasForeignKey(t => t.CitizenshipId)
                    .WillCascadeOnDelete(false);
        }
        }
}
