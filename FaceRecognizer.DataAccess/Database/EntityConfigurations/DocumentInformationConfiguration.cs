using FaceRecognizer.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FaceRecognizer.DataAccess.Database.EntityConfigurations
{
    public class DocumentInformationConfiguration : EntityTypeConfiguration<DocumentInformation>
    {
        public DocumentInformationConfiguration()
        {
            ToTable("DocumentInformations", "dbo");

            Property(e => e.Id)
                 .IsRequired()
                 .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.DocumentTypeId)
                .IsRequired();

            Property(e => e.CitizenshipId)
                .IsRequired();

            Property(e => e.GenderId)
                .IsRequired();

            Property(e => e.DocumentPin)
               .IsRequired()
               .HasMaxLength(10)
               .IsUnicode(true);

            Property(e => e.DocumentNumber)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(true);

            Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(true);

            Property(e => e.Surname)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(true);

            Property(e => e.Surname)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(true);

            Property(e => e.BirthDate)
                .IsRequired();

            HasMany(e => e.Contracts)
                .WithRequired(e => e.DocumentInformation)
                .HasForeignKey(e => e.DocumentInformationId)
                .WillCascadeOnDelete(false);

            Property(e => e.DocumentSeries)
                .IsRequired()
                .HasMaxLength(5)
                .IsUnicode(false);

            Property(e => e.BirthAddress)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(true);

            Property(e => e.DocumentOrganization)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(true);

            Property(e => e.RegisterCity)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(true);

            Property(e => e.RegisterStreet)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(true);

            Property(e => e.RegisterHousing)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(true);

            Property(e => e.EventDate)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(true);

            Property(e => e.ExpireDate)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(true);

			Property(e => e.Photo)
				.IsRequired()
				.HasMaxLength(250)
				.IsUnicode(true);
		}
    }
}
