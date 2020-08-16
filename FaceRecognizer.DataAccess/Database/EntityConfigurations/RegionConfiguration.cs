using FaceRecognizer.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FaceRecognizer.DataAccess.Database.EntityConfigurations
{
    public class RegionConfiguration  : EntityTypeConfiguration<Region>
    {
        public RegionConfiguration()
        {
            ToTable("Regions", "dbo");

            Property(e => e.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.ParentId)
               .IsRequired();

            Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(true);

            HasMany(e => e.Branches)
                .WithRequired(t => t.Region)
                .HasForeignKey(t => t.RegionId)
                .WillCascadeOnDelete(false);
        }
    }
}
