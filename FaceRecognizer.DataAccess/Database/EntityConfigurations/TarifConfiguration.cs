using FaceRecognizer.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FaceRecognizer.DataAccess.Database.EntityConfigurations
{
    public class TarifConfiguration : EntityTypeConfiguration<Tarif>
    {
        public TarifConfiguration()
        {
            ToTable("Tarifs", "dbo");

            Property(e => e.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            Property(e => e.SubscriptionTypeId)
                .IsRequired();

            Property(e => e.Description)
                .HasMaxLength(255)
                .IsRequired()
                .IsUnicode(false);

            HasMany(e => e.Contracts)
             .WithRequired(e => e.Tarif)
             .HasForeignKey(e => e.TarifId)
             .WillCascadeOnDelete(false);
        }
    }
}
