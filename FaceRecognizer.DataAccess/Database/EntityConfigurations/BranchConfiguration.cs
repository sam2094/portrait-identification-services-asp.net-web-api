using FaceRecognizer.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FaceRecognizer.DataAccess.Database.EntityConfigurations
{
	public class BranchConfiguration : EntityTypeConfiguration<Branch>
    {
        public BranchConfiguration()
        {
            ToTable("Branches", "dbo");

            Property(e => e.Id)
           .IsRequired()
           .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.OrganizationId)
             .IsRequired();

            Property(e => e.RegionId)
               .IsRequired();

            Property(e => e.PlaceName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(true);

			Property(e => e.Code)
				.IsRequired()
				.HasMaxLength(50)
				.IsUnicode(false);

			Property(e => e.PlaceAddress)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(true);

            Property(e => e.ContactNumber)
              .IsRequired();

            Property(e => e.Email)
               .HasMaxLength(255)
               .IsRequired()
               .IsUnicode(false);

            Property(e => e.AddedDate)
               .IsRequired();

            Property(e => e.UpdateDate)
                .IsRequired();

            HasMany(e => e.Users)
                .WithRequired(e => e.Branch)
                .HasForeignKey(e => e.BranchId)
                .WillCascadeOnDelete(false);

			HasMany(e => e.Contracts)
			   .WithRequired(e => e.Branch)
			   .HasForeignKey(e => e.BranchId)
			   .WillCascadeOnDelete(false);
		}
    }
}
