using FaceRecognizer.Common.Enums.DatabaseEnums;
using FaceRecognizer.Common.Helpers;
using FaceRecognizer.DataAccess.Database;
using FaceRecognizer.Models.Entities;
using System;
using System.Data.Entity.Migrations;

namespace FaceRecognizer.DataAccess.Migrations.Seed
{
    public class TokenSeed : BaseSeed
    {
        public static void Seed(MyDbContext context)
        {
            string guid = "bd025748d0534974b8c8ba1f7b6335e7";
            context.Tokens.AddOrUpdate(new Token
            {
                Id = 1,
                AddedDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddYears(1000),
                UserId = 2,
                TokenStatusId = (byte)TokenStatuses.ACTIVE,
                Value = Hashing.GetSha512HashData(guid)                
            });
        }
    }
}
