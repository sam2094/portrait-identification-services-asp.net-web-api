﻿using FaceRecognizer.Common.Attributes;
using FaceRecognizer.Common.Enums.DatabaseEnums;
using FaceRecognizer.Common.Extensions;
using FaceRecognizer.DataAccess.Database;
using FaceRecognizer.Models.Entities;
using System.Data.Entity.Migrations;

namespace FaceRecognizer.DataAccess.Migrations.Seed
{
	public class UserFileTypeSeed : BaseSeed
	{
		public static void Seed(MyDbContext context)
		{
			SeedByEnum<UserFileTypes, MyDbContext>(context, (ctx, value, enm) =>
			{
				ctx.UserFileTypes.AddOrUpdate(new UserFileType
				{
					Id = (byte)value,
					Description = enm.GetAttribute<EnumDescription>().Description,
					Name = enm.ToString(),
				});
			});
		}
	}
}
