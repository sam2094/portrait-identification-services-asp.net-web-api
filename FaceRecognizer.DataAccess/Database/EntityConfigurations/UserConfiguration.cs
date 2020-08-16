using FaceRecognizer.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FaceRecognizer.DataAccess.Database.EntityConfigurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("Users", "dbo");

            Property(e => e.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.UserStatusId)
               .IsRequired();

            Property(e => e.BranchId)
               .IsRequired();

            Property(e => e.ParentId)
               .IsRequired();

            Property(e => e.RoleId)
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

            Property(e => e.Patronymic)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(true);

            Property(e => e.Contact)
                .IsRequired();

            Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(true);

            Property(e => e.Password)
                .IsRequired();

            Property(e => e.Salt)
                .IsRequired();

            Property(e => e.AddedDate)
                .IsRequired();

            Property(e => e.Photo)
               .IsRequired()
               .HasMaxLength(150)
               .IsUnicode(true);

            Property(e => e.IsFaceRecognized)
                .IsRequired();

            HasMany(e => e.Tokens)
                .WithRequired(t => t.User)
                .HasForeignKey(t => t.UserId)
                .WillCascadeOnDelete(false);

            HasMany(e => e.Contracts)
                .WithRequired(t => t.User)
                .HasForeignKey(t => t.UserId)
                .WillCascadeOnDelete();

			HasMany(e => e.UserFiles)
				.WithRequired(t => t.User)
				.HasForeignKey(t => t.UserId)
				.WillCascadeOnDelete(false);
		}
    }
}
