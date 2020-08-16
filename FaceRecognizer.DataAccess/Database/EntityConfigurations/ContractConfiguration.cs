using FaceRecognizer.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FaceRecognizer.DataAccess.Database.EntityConfigurations
{
    public class ContractConfiguration : EntityTypeConfiguration<Contract>
    {
        public ContractConfiguration()
        {
            ToTable("Contracts", "dbo");

            Property(e => e.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.UserId)
                .IsRequired();

            Property(e => e.ContractStatusId)
                .IsRequired();

            Property(e => e.DocumentInformationId)
                .IsRequired();

            Property(e => e.OperationTypeId)
                .IsRequired();

            Property(e => e.TarifId)
                 .IsRequired();

			Property(e => e.BranchId)
			   .IsRequired();

			Property(e => e.ContactNumber)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(true);

            Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(true);

            Property(e => e.Email)
                .HasMaxLength(255)
                .IsRequired()
                .IsUnicode(false);

            Property(e => e.DeliveryAddress)
                .HasMaxLength(150)
                .IsUnicode(true);

            Property(e => e.AddedDate)
                .IsRequired();

            Property(e => e.UpdateDate)
                .IsRequired();

            Property(e => e.IMSI)
                .IsRequired();

            Property(e => e.ICCID)
                .IsRequired();

			Property(e => e.Index)
				.IsRequired()
				.HasMaxLength(250)
				.IsUnicode(true);

			HasMany(e => e.ContractFiles)
				.WithRequired(t => t.Contract)
				.HasForeignKey(t => t.ContractId)
				.WillCascadeOnDelete(false);
		}
    }
}
