using FaceRecognizer.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FaceRecognizer.DataAccess.Database.EntityConfigurations
{
    public class TokenConfiguration : EntityTypeConfiguration<Token>
    {
        public TokenConfiguration()
        {
            ToTable("Tokens", "dbo");

            Property(e => e.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.TokenStatusId)
               .IsRequired();

            Property(e => e.UserId)
                .IsRequired();

            Property(e => e.Value)
                .IsRequired()
                .HasMaxLength(128)
                .IsUnicode(true);

            Property(e => e.AddedDate)
                .IsRequired();

            Property(e => e.ExpireDate)
                .IsRequired();
        }
    }
}
