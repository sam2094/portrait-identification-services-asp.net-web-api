using FaceRecognizer.Common.Enums.DatabaseEnums;
using FaceRecognizer.DataAccess.Database;
using FaceRecognizer.Models.Entities;
using System;
using System.Data.Entity.Migrations;

namespace FaceRecognizer.DataAccess.Migrations.Seed
{
    public class TarifSeed : BaseSeed
    {
        public static void Seed(MyDbContext context)
        {
            DateTime date = DateTime.Now;
			context.Tarifs.AddOrUpdate(new Tarif
			{
				Id = 1,
				SubscriptionTypeId = (byte)SubscriptionTypes.INVOICE,
				Name = "TEST",
				Description = "TEST",
				OrganizationId = 1
			}); ;
			context.Tarifs.AddOrUpdate(new Tarif
			{
				Id = 2,
				SubscriptionTypeId = (byte)SubscriptionTypes.NON_INVOICE,
				Name = "TEST2",
				Description = "TEST2",
				OrganizationId = 2
			});
			context.Tarifs.AddOrUpdate(new Tarif
			{
				Id = 3,
				SubscriptionTypeId = (byte)SubscriptionTypes.INVOICE,
				Name = "TEST3",
				Description = "TEST3",
				OrganizationId = 3
			});
		}
    }
}
