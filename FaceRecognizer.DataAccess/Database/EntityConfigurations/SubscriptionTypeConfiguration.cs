using FaceRecognizer.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FaceRecognizer.DataAccess.Database.EntityConfigurations
{
    public class SubscriptionTypeConfiguration : EntityTypeConfiguration<SubscriptionType>
    {
        public SubscriptionTypeConfiguration()
        {
            ToTable("SubscriptionType", "type");

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

            HasMany(e => e.Tarifs)
                .WithRequired(t => t.SubscriptionType)
                .HasForeignKey(t => t.SubscriptionTypeId)
                .WillCascadeOnDelete(false);
        }
    }
}
