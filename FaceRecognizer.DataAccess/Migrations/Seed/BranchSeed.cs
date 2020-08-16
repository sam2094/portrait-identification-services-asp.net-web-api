using FaceRecognizer.DataAccess.Database;
using FaceRecognizer.Models.Entities;
using System;
using System.Data.Entity.Migrations;

namespace FaceRecognizer.DataAccess.Migrations.Seed
{
	public class BranchSeed : BaseSeed
	{
		public static void Seed(MyDbContext context)
		{
			DateTime date = DateTime.Now;
			context.Branches.AddOrUpdate(new Branch()
			{
				Id = 1,
				Code = "MHM",
				PlaceAddress = "MHM Place Address",
				PlaceName = "MHM Place Name",
				ContactNumber = "111111",
				Email = "mhm@rabita.az",
				RegionId = 1,
				OrganizationId = 1,
				AddedDate = date,
				UpdateDate = date,
			});
			context.Branches.AddOrUpdate(new Branch()
			{
				Id = 2,
				Code = "code_test1",
				PlaceAddress = "Quba Place Address",
				PlaceName = "Quba Place Name",
				ContactNumber = "222222",
				Email = "dddd@mail.az",
				RegionId = 63,
				OrganizationId = 2,
				AddedDate = date,
				UpdateDate = date,
			});
			context.Branches.AddOrUpdate(new Branch()
			{
				Id = 3,
				Code = "code_test2",
				PlaceAddress = "Salyan Place Address",
				PlaceName = "Salyan Place Name",
				ContactNumber = "333333",
				Email = "bakcell@mail.az",
				RegionId = 69,
				OrganizationId = 3,
				AddedDate = date,
				UpdateDate = date,
			});
			context.Branches.AddOrUpdate(new Branch()
			{
				Id = 4,
				Code = "code_test3",
				PlaceAddress = "Lerik Place Address",
				PlaceName = "Lerik Place Name",
				ContactNumber = "444444",
				Email = "azerfon@mail.az",
				RegionId = 44,
				OrganizationId = 4,
				AddedDate = date,
				UpdateDate = date,
			});

			context.Branches.AddOrUpdate(new Branch()
			{
				Id = 5,
				Code = "code_test4",
				PlaceAddress = "Massalli Place Address",
				PlaceName = "Massalli Place Name",
				ContactNumber = "5555555",
				Email = "code_test4@mail.az",
				RegionId = 40,
				OrganizationId = 2,
				AddedDate = date,
				UpdateDate = date,
			});
		}
	}
}
