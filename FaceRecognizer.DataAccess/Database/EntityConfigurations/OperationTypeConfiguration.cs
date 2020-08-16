using FaceRecognizer.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FaceRecognizer.DataAccess.Database.EntityConfigurations
{
    public class OperationTypeConfiguration : EntityTypeConfiguration<OperationType>
    {
        public OperationTypeConfiguration()
        {
            ToTable("OperationTypes", "type");

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

            HasMany(e => e.Contracts)
                .WithRequired(e => e.OperationType)
                .HasForeignKey(e => e.OperationTypeId)
                .WillCascadeOnDelete(false);
        }
    }
}
