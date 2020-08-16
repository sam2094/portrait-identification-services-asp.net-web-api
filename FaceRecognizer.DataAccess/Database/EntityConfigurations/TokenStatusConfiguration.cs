using FaceRecognizer.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FaceRecognizer.DataAccess.Database.EntityConfigurations
{
    public class TokenStatusConfiguration : EntityTypeConfiguration<TokenStatus>
    {
        public TokenStatusConfiguration()
        {
            ToTable("TokenStatuses", "status");

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

            HasMany(e => e.Tokens)
                .WithRequired(e => e.TokenStatus)
                .HasForeignKey(e => e.TokenStatusId)
                .WillCascadeOnDelete(false);
        }
    }
}
