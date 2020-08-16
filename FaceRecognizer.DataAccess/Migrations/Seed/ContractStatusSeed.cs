using FaceRecognizer.Common.Attributes;
using FaceRecognizer.Common.Enums.DatabaseEnums;
using FaceRecognizer.Common.Extensions;
using FaceRecognizer.DataAccess.Database;
using FaceRecognizer.Models.Entities;
using System.Data.Entity.Migrations;

namespace FaceRecognizer.DataAccess.Migrations.Seed
{
	public class ContractStatusSeed : BaseSeed
	{
		public static void Seed(MyDbContext context)
		{
			SeedByEnum<ContractStatuses, MyDbContext>(context, (ctx, value, enm) =>
			{
				ctx.ContractStatuses.AddOrUpdate(new ContractStatus
				{
					Id = (byte)value,
					Description = enm.GetAttribute<EnumDescription>().Description,
					Name = enm.ToString()
				});
			});
		}
	}

}
