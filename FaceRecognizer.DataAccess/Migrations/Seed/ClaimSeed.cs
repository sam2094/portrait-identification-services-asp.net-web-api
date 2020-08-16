using FaceRecognizer.Common.Attributes;
using FaceRecognizer.Common.Enums.DatabaseEnums.ClaimEnums;
using FaceRecognizer.Common.Extensions;
using FaceRecognizer.DataAccess.Database;
using FaceRecognizer.Models.Entities;
using System;
using System.Data.Entity.Migrations;

namespace FaceRecognizer.DataAccess.Migrations.Seed
{
	public class ClaimSeed : BaseSeed
	{
		public static void Seed(MyDbContext context)
		{
			DateTime date = DateTime.Now;

			SeedByEnum<Claims, MyDbContext>(context, (ctx, value, enm) =>
			{
				ctx.Claims.AddOrUpdate(new Claim
				{
					Id = value,
					Description = enm.GetAttribute<EnumDescription>().Description,
					Name = enm.ToString(),
					AddedDate = date
				});
			});
		}
	}
}
