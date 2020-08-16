using FaceRecognizer.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognizer.DataAccess.Database.EntityConfigurations
{
    class GenderConfiguration : EntityTypeConfiguration<Gender>
    {
        public GenderConfiguration()
        {
            ToTable("Gender", "dbo");

            Property(e => e.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(true);

            HasMany(e => e.DocumentInformations)
                 .WithRequired(e => e.Gender)
                 .HasForeignKey(e => e.GenderId)
                 .WillCascadeOnDelete(false);
        }
    }
}