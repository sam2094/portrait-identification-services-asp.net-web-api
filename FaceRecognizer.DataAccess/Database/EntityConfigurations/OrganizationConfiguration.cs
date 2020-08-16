using FaceRecognizer.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FaceRecognizer.DataAccess.Database.EntityConfigurations
{
    public class OrganizationConfiguration  : EntityTypeConfiguration<Organization>
    {
        public OrganizationConfiguration()
        {
            ToTable("Organizations", "dbo");

            Property(e => e.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(true);

            Property(e => e.Contact)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(true);

            Property(e => e.AddedDate)
               .IsRequired();

            HasMany(e => e.Branches)
                .WithRequired(t => t.Organization)
                .HasForeignKey(t => t.OrganizationId)
                .WillCascadeOnDelete(false);

            HasMany(e => e.RoleGroups)
               .WithRequired(t => t.Organization)
               .HasForeignKey(t => t.OrganizationId)
               .WillCascadeOnDelete(false);
        }
    }
}
