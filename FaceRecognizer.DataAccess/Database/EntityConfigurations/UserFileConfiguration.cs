using FaceRecognizer.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace FaceRecognizer.DataAccess.Database.EntityConfigurations
{
	public class UserFileConfiguration : EntityTypeConfiguration<UserFile>
	{
		public UserFileConfiguration()
		{
			ToTable("UserFiles","dbo");

			Property(e => e.Id)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			Property(e => e.UserId)
				.IsRequired();

			Property(e => e.UserFileTypeId)
				.IsRequired();

			Property(e => e.UserFileName)
				.HasMaxLength(250)
				.IsUnicode(true);
		}
	}
}
