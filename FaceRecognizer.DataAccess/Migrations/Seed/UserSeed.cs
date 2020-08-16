using FaceRecognizer.Common.Enums.DatabaseEnums;
using FaceRecognizer.Common.Helpers;
using FaceRecognizer.DataAccess.Database;
using FaceRecognizer.Models.Entities;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace FaceRecognizer.DataAccess.Migrations.Seed
{
    public class UserSeed : BaseSeed
    {
        public static void Seed(MyDbContext context)
        {
            byte[] salt = Hashing.RandomSalt;
            DateTime date = DateTime.Now;
            context.Users.AddOrUpdate(new User()
            {
                Id = 1,
                Name = "HÜSEYN",
                Surname = "MİKAYIL",
                Patronymic = "ELGIZ",
                BranchId = 1,
				RoleId = 1,
				ParentId = 1,
                Username = "huseyn",
                IsFaceRecognized = true,
                Cerficate = Hashing.Hash(salt, "1"),
                Password = Hashing.Hash(salt, "1"),
                Salt = salt,
                Contact = "709949796",
                DocumentPin = "5YVZNS7",
                DocumentNumber = "AA0191773",
                UserStatusId = (byte)UserStatuses.ACTIVE,
                AddedDate = date,
                Photo = "23b17f26d3cb4b7ab372b199a563ab6f.jpg"
            });
            context.Users.AddOrUpdate(new User()
            {
                Id = 2,
                Name = "CHIRICO",
                Surname = "UGO",
                Patronymic = "TEST",
                BranchId = 1,
				RoleId = 3,
				ParentId = 1,
                Username = "test",
                IsFaceRecognized = true,
                Cerficate = Hashing.Hash(salt, "1"),
                Password = Hashing.Hash(salt, "1"),
                Salt = salt,
                Contact = "709949796",
                DocumentPin = "Test",
                DocumentNumber = "Test",
                UserStatusId = (byte)UserStatuses.ACTIVE,
                AddedDate = date,
                Photo = "23b17f26d3cb4b7ab372b199a563ab6f.jpg"
            });

            context.Users.AddOrUpdate(new User()
            {
                Id = 3,
                Name = "SXM",
                Surname = "SXM",
                Patronymic = "SXM",
                BranchId = 3,
				RoleId = 6,
				ParentId = 1,
                Username = "sxm",
                IsFaceRecognized = true,
                Cerficate = Hashing.Hash(salt, "1"),
                Password = Hashing.Hash(salt, "1"),
                Salt = salt,
                Contact = "558900523",
                DocumentPin = "TEST",
                DocumentNumber = "TEST",
                UserStatusId = (byte)UserStatuses.ACTIVE,
                AddedDate = date,
                Photo = "23b17f26d3cb4b7ab372b199a563ab6f.jpg"
            });
            context.Users.AddOrUpdate(new User()
            {
                Id = 4,
                Name = "EMİN",
                Surname = "NOVRUZOV",
                Patronymic = "BƏLAHƏR",
                BranchId = 2,
				RoleId = 2,
				ParentId = 1,
                Username = "emin",
                IsFaceRecognized = false,
                Cerficate = Hashing.Hash(salt, "1"),
                Password = Hashing.Hash(salt, "1"),
                Salt = salt,
                Contact = "551111111",
                DocumentPin = "19VQAFP",
                DocumentNumber = "AA0197977",
                UserStatusId = (byte)UserStatuses.ACTIVE,
                AddedDate = date,
                Photo = "23b17f26d3cb4b7ab372b199a563ab6f.jpg"
            });

			
			context.Users.AddOrUpdate(new User()
            {
                Id = 5,
                Name = "QNYAZ",
                Surname = "YAQUBOV",
                Patronymic = "QIYAS ",
                BranchId = 3,
				RoleId = 7,
				ParentId = 1,
                Username = "qnyaz",
                IsFaceRecognized = true,
                Cerficate = Hashing.Hash(salt, "1"),
                Password = Hashing.Hash(salt, "1"),
                Salt = salt,
                Contact = "702222222",
                DocumentPin = "4QYZTCC",
                DocumentNumber = "14870378",
                UserStatusId = (byte)UserStatuses.BLOCKED,
                AddedDate = date,
                Photo = "23b17f26d3cb4b7ab372b199a563ab6f.jpg"
            });

			context.Users.AddOrUpdate(new User()
			{
				Id = 6,
				Name = "SAMIR",
				Surname = "HESENOV",
				Patronymic = "ELMAR",
				BranchId = 5,
				RoleId = 4,
				ParentId = 1,
				Username = "samir",
				IsFaceRecognized = false,
				Cerficate = Hashing.Hash(salt, "1"),
				Password = Hashing.Hash(salt, "1"),
				Salt = salt,
				Contact = "558900523",
				DocumentPin = "60LWSJG",
				DocumentNumber = "AA0628228",
				UserStatusId = (byte)UserStatuses.ACTIVE,
				AddedDate = date,
				Photo = "23b17f26d3cb4b7ab372b199a563ab6f.jpg"
			});
		}
    }
}
