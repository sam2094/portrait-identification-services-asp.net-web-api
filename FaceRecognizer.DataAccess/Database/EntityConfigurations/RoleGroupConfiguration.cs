using FaceRecognizer.Models.Entities;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace FaceRecognizer.DataAccess.Database.EntityConfigurations
{
	public class RoleGroupConfiguration : EntityTypeConfiguration<RoleGroup>
	{
		public RoleGroupConfiguration()
		{
			ToTable("RoleGroups", "dbo");

			Property(e => e.Id)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			Property(e => e.OrganizationId)
				 .IsRequired();

			Property(e => e.Name)
				.IsRequired()
				.HasMaxLength(50)
				.IsUnicode(true);
		}
	}
}
