using FaceRecognizer.Common.Enums.DatabaseEnums;
using FaceRecognizer.DataAccess.Database;
using FaceRecognizer.Models.Entities;
using System.Data.Entity.Migrations;

namespace FaceRecognizer.DataAccess.Migrations.Seed
{
    public class GenderSeed : BaseSeed
    {
        public static void Seed(MyDbContext context)
        {

            SeedByEnum<Genders, MyDbContext>(context, (ctx, value, enm) =>
            {
                ctx.Genders.AddOrUpdate(new Gender
                {
                    Id = (byte)value,
                    Name = enm.ToString(),
                });
            });
        }
    }
}
