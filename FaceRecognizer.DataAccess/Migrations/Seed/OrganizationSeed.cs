using FaceRecognizer.Common.Attributes;
using FaceRecognizer.Common.Enums.CommonEnums;
using FaceRecognizer.Common.Extensions;
using FaceRecognizer.DataAccess.Database;
using FaceRecognizer.Models.Entities;
using System;
using System.Data.Entity.Migrations;

namespace FaceRecognizer.DataAccess.Migrations.Seed
{
    public class OrganizationSeed : BaseSeed
    {
        public static void Seed(MyDbContext context)
        {
            DateTime date = DateTime.Now;

            SeedByEnum<Organizations, MyDbContext>(context, (ctx, value, enm) =>
            {
                ctx.Organizations.AddOrUpdate(new Organization
                {
                    Id = value,
                    Description = enm.GetAttribute<EnumDescription>().Description,
                    Name = enm.ToString(),
                    IsActive = true,
                    Contact = "550000000",
                    AddedDate = date,
					Photo = "23b17f26d3cb4b7ab372b199a563ab6f.jpg"
				});
            });
        }
    }
}
