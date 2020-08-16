using FaceRecognizer.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace FaceRecognizer.DataAccess.Database.EntityConfigurations
{
	public class ContractFileConfiguration : EntityTypeConfiguration<ContractFile>
	{
		public ContractFileConfiguration()
		{
			ToTable("ContractFiles", "dbo");

			Property(e => e.Id)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			Property(e => e.ContractId)
				.IsRequired();

			Property(e => e.ContractFileTypeId)
				.IsRequired();

			Property(e => e.ContractFileName)
				.HasMaxLength(250)
				.IsUnicode(true);
		}
	}
}
