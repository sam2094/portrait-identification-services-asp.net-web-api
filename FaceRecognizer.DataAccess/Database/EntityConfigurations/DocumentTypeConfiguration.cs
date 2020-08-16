using FaceRecognizer.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FaceRecognizer.DataAccess.Database.EntityConfigurations
{
    public class DocumentTypeConfiguration : EntityTypeConfiguration<DocumentType>
    {
        public DocumentTypeConfiguration()
        {
            ToTable("DocumentTypes", "type");

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
                .IsUnicode(true);

            HasMany(e => e.DocumentInformations)
             .WithRequired(e => e.DocumentType)
             .HasForeignKey(e => e.DocumentTypeId)
             .WillCascadeOnDelete(false);
        }
    }
}
