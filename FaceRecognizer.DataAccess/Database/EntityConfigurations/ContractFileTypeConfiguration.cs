using FaceRecognizer.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FaceRecognizer.DataAccess.Database.EntityConfigurations
{
	public class ContractFileTypeConfiguration : EntityTypeConfiguration<ContractFileType>
	{
		public ContractFileTypeConfiguration()
		{
			ToTable("ContractFileTypes", "type");

			Property(e => e.Id)
			   .IsRequired()
			   .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			Property(e => e.Name)
			   .IsRequired()
				.HasMaxLength(50)
				.IsUnicode(true);

			Property(e => e.Description)
			   .IsRequired()
				.HasMaxLength(50)
				.IsUnicode(true);

			HasMany(e => e.ContractFiles)
				.WithRequired(t => t.ContractFileType)
				.HasForeignKey(t => t.ContractFileTypeId)
				.WillCascadeOnDelete(false);
		}
	}
}
