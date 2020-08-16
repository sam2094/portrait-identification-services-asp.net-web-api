using FaceRecognizer.Common.Attributes;
using FaceRecognizer.Common.Enums.CommonEnums;
using FaceRecognizer.Common.Enums.DatabaseEnums.ClaimEnums;
using FaceRecognizer.Common.Enums.DatabaseEnums.RoleEnums;
using FaceRecognizer.Common.Extensions;
using FaceRecognizer.DataAccess.Database;
using FaceRecognizer.Models.Entities;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace FaceRecognizer.DataAccess.Migrations.Seed
{
    public class RoleSeed : BaseSeed
    {
        public static void Seed(MyDbContext context)
        {
            DateTime date = DateTime.Now;
            context.Roles.AddOrUpdate(new Role()
            {
                Id = 1,
                RoleGroupId = 1,
                Name = Roles.SUPER_ADMIN.ToString(),
                Description = Roles.SUPER_ADMIN.GetAttribute<EnumDescription>().Description,
                Level = Levels.ORGANIZATION_LEVEL.ToString(),
                Claims = context.Claims.ToList(),
                AddedDate = date
            });
			
            context.Roles.AddOrUpdate(new Role()
            {
                Id = 2,
                RoleGroupId = 2,
                Name = Roles.ADMIN.ToString(),
                Description = Roles.ADMIN.GetAttribute<EnumDescription>().Description,
                Level = Levels.ORGANIZATION_LEVEL.ToString(),
				Claims = context.Claims.ToList(),
				AddedDate = date
            });

			context.Roles.AddOrUpdate(new Role()
			{
				Id = 3,
				RoleGroupId = 3,
				Name = Roles.DEALER.ToString(),
				Description = Roles.DEALER.GetAttribute<EnumDescription>().Description,
				Level = Levels.ORGANIZATION_LEVEL.ToString(),
				Claims = context.Claims.Where(x =>
				 x.Id == (int)Claims.CAN_GET_SUBSCRIPTION_TYPES
				|| x.Id == (int)Claims.CAN_GET_OPERATION_TYPES
				|| x.Id == (int)Claims.CAN_GET_TARIFS
				|| x.Id == (int)Claims.CAN_CHANGE_PASSWORD
				|| x.Id == (int)Claims.CAN_ADD_CONTRACT
				|| x.Id == (int)Claims.CAN_UPLOAD_CONTRACT
				|| x.Id == (int)Claims.CAN_DOWNLOAD_CONTRACT
				|| x.Id == (int)Claims.CAN_GET_CITIZENSHIP_TYPES
				|| x.Id == (int)Claims.CAN_GET_CONTRACT_FILE_TYPES
				|| x.Id == (int)Claims.CAN_GET_USER_FILE_TYPES
				|| x.Id == (int)Claims.CAN_UPLOAD_USER_FILE
				|| x.Id == (int)Claims.CAN_DOWNLOAD_USER_FILE
				|| x.Id == (int)Claims.CAN_GET_DOCUMENT_TYPES).ToList(),
				AddedDate = date
			});

			context.Roles.AddOrUpdate(new Role()
            {
                Id = 4,
                RoleGroupId = 4,
                Name = Roles.OPERATOR.ToString(),
                Description = Roles.OPERATOR.GetAttribute<EnumDescription>().Description,
                Level = Levels.BRANCH_LEVEL.ToString(),
                AddedDate = date
            });

            context.Roles.AddOrUpdate(new Role()
            {
                Id = 5,
                RoleGroupId = 5,
                Name = Roles.MIX.ToString(),
                Description = Roles.MIX.GetAttribute<EnumDescription>().Description,
                Level = Levels.BRANCH_LEVEL.ToString(),
                AddedDate = date
            });


			context.Roles.AddOrUpdate(new Role()
			{
				Id = 6,
				RoleGroupId = 6,
				Name = Roles.ADMIN.ToString(),
				Description = Roles.ADMIN.GetAttribute<EnumDescription>().Description,
				Level = Levels.ORGANIZATION_LEVEL.ToString(),
				Claims = context.Claims.ToList(),
				AddedDate = date
			});

			context.Roles.AddOrUpdate(new Role()
			{
				Id = 7,
				RoleGroupId = 7,
				Name = Roles.DEALER.ToString(),
				Description = Roles.DEALER.GetAttribute<EnumDescription>().Description,
				Level = Levels.BRANCH_LEVEL.ToString(),
				Claims = context.Claims.Where(x =>
				x.Id == (int)Claims.CAN_GET_SUBSCRIPTION_TYPES
				|| x.Id == (int)Claims.CAN_GET_OPERATION_TYPES
				|| x.Id == (int)Claims.CAN_GET_TARIFS
				|| x.Id == (int)Claims.CAN_CHANGE_PASSWORD
				|| x.Id == (int)Claims.CAN_ADD_CONTRACT
				|| x.Id == (int)Claims.CAN_UPLOAD_CONTRACT
				|| x.Id == (int)Claims.CAN_GET_DOCUMENT_TYPES).ToList(),
				AddedDate = date
			});

			context.Roles.AddOrUpdate(new Role()
			{
				Id = 8,
				RoleGroupId = 8,
				Name = Roles.OPERATOR.ToString(),
				Description = Roles.OPERATOR.GetAttribute<EnumDescription>().Description,
				Level = Levels.BRANCH_LEVEL.ToString(),
				AddedDate = date
			});

			context.Roles.AddOrUpdate(new Role()
			{
				Id = 9,
				RoleGroupId = 9,
				Name = Roles.MIX.ToString(),
				Description = Roles.MIX.GetAttribute<EnumDescription>().Description,
				Level = Levels.BRANCH_LEVEL.ToString(),
				AddedDate = date
			});
		}
    }
}
