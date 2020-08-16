using FaceRecognizer.DataAccess.Database;
using FaceRecognizer.Models.Entities;
using System.Data.Entity.Migrations;

namespace FaceRecognizer.DataAccess.Migrations.Seed
{
	class RoleGroupSeed : BaseSeed
	{
		public static void Seed(MyDbContext context)
		{
			context.RoleGroups.AddOrUpdate(new RoleGroup
			{
				Id = 1,
				Name = "MXM Super Admin",
				OrganizationId = 1
			});

			context.RoleGroups.AddOrUpdate(new RoleGroup
			{
				Id = 2,
				Name = "Admin",
				OrganizationId = 2
			});

			context.RoleGroups.AddOrUpdate(new RoleGroup
			{
				Id = 3,
				Name = "Dealer",
				OrganizationId = 2
			});

			context.RoleGroups.AddOrUpdate(new RoleGroup
			{
				Id = 4,
				Name = "Operator",
				OrganizationId = 2
			});

			context.RoleGroups.AddOrUpdate(new RoleGroup
			{
				Id = 5,
				Name = "Mix",
				OrganizationId = 2
			});

			context.RoleGroups.AddOrUpdate(new RoleGroup
			{
				Id = 6,
				Name = "Admin",
				OrganizationId = 3
			});

			context.RoleGroups.AddOrUpdate(new RoleGroup
			{
				Id = 7,
				Name = "Dealer",
				OrganizationId = 3
			});

			context.RoleGroups.AddOrUpdate(new RoleGroup
			{
				Id = 8,
				Name = "Operator",
				OrganizationId = 3
			});

			context.RoleGroups.AddOrUpdate(new RoleGroup
			{
				Id = 9,
				Name = "Mix",
				OrganizationId = 3
			});
		}
	}
}
