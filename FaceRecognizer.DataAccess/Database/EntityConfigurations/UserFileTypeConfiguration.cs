using FaceRecognizer.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FaceRecognizer.DataAccess.Database.EntityConfigurations
{
	public class UserFileTypeConfiguration : EntityTypeConfiguration<UserFileType>
	{
		public UserFileTypeConfiguration()
		{
			ToTable("UserFileTypes", "type");

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

			HasMany(e => e.UserFiles)
				.WithRequired(t => t.UserFileType)
				.HasForeignKey(t => t.UserFileTypeId)
				.WillCascadeOnDelete(false);
		}
	}
}
