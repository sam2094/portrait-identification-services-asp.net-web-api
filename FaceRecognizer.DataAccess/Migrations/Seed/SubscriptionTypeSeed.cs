using FaceRecognizer.Common.Attributes;
using FaceRecognizer.Common.Enums.DatabaseEnums;
using FaceRecognizer.Common.Extensions;
using FaceRecognizer.DataAccess.Database;
using FaceRecognizer.Models.Entities;
using System.Data.Entity.Migrations;

namespace FaceRecognizer.DataAccess.Migrations.Seed
{
    public class SubscriptionTypeSeed : BaseSeed
    {
        public static void Seed(MyDbContext context)
        {
            SeedByEnum<SubscriptionTypes, MyDbContext>(context, (ctx, value, enm) =>
            {
                ctx.SubscriptionTypes.AddOrUpdate(new SubscriptionType
                {
                    Id = (byte)value,
                    Description = enm.GetAttribute<EnumDescription>().Description,
                    Name = enm.ToString()
                });
            });
        }
    }
}
