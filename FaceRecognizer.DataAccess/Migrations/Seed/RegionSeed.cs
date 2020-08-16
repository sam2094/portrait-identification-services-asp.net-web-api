using FaceRecognizer.DataAccess.Database;
using FaceRecognizer.Models.Entities;
using System;
using System.Data.Entity.Migrations;

namespace FaceRecognizer.DataAccess.Migrations.Seed
{
    public class RegionSeed : BaseSeed
    {
        public static void Seed(MyDbContext context)
        {
            DateTime date = DateTime.Now;
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 1,
                Name = "Abşeron",
                AddedDate = date,
                ParentId = 1                
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 2,
                Name = "Abşeron, Xırdalan",
                AddedDate = date,
                ParentId = 2
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 3,
                Name = "Ağcabədi",
                AddedDate = date,
                ParentId = 3
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 4,
                Name = "Ağdam",
                AddedDate = date,
                ParentId = 4
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 5,
                Name = "Ağdaş",
                AddedDate = date,
                ParentId = 5
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 6,
                Name = "Ağstafa",
                AddedDate = date,
                ParentId = 6
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 7,
                Name = "Ağsu",
                AddedDate = date,
                ParentId = 7
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 8,
                Name = "Astara",
                AddedDate = date,
                ParentId = 8
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 9,
                Name = "Bakı",
                AddedDate = date,
                ParentId = 9
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 10,
                Name = "Bakı, Binəqədi",
                AddedDate = date,
                ParentId = 9
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 11,
                Name = "Bakı, Masazır",
                AddedDate = date,
                ParentId = 9
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 12,
                Name = "Bakı, Nərimanov",
                AddedDate = date,
                ParentId = 9
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 13,
                Name = "Bakı, Nəsimi",
                AddedDate = date,
                ParentId = 9
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 14,
                Name = "Bakı, Nizami",
                AddedDate = date,
                ParentId = 9
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 15,
                Name = "Bakı, Sabunçu",
                AddedDate = date,
                ParentId = 9
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 16,
                Name = "Bakı, Suraxanı",
                AddedDate = date,
                ParentId = 9
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 17,
                Name = "Bakı, Xətai",
                AddedDate = date,
                ParentId = 9
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 18,
                Name = "Bakı, Xəzər",
                AddedDate = date,
                ParentId = 9
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 19,
                Name = "Balakən",
                AddedDate = date,
                ParentId = 19
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 20,
                Name = "Bərdə",
                AddedDate = date,
                ParentId = 20
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 21,
                Name = "Beyləqan",
                AddedDate = date,
                ParentId = 21
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 22,
                Name = "Biləsuvar",
                AddedDate = date,
                ParentId = 22
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 23,
                Name = "Cəbrayıl",
                AddedDate = date,
                ParentId = 23
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 24,
                Name = "Cəlilabad",
                AddedDate = date,
                ParentId = 24
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 25,
                Name = "Daşkəsən",
                AddedDate = date,
                ParentId = 25
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 26,
                Name = "Dəvəçi",
                AddedDate = date,
                ParentId = 26
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 27,
                Name = "Füzuli",
                AddedDate = date,
                ParentId = 27
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 28,
                Name = "Gədəbəy",
                AddedDate = date,
                ParentId = 28
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 29,
                Name = "Gəncə",
                AddedDate = date,
                ParentId = 29
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 30,
                Name = "Gəncə, Kəpəz",
                AddedDate = date,
                ParentId = 29
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 31,
                Name = "Gəncə, Nizami",
                AddedDate = date,
                ParentId = 29
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 32,
                Name = "Goranboy",
                AddedDate = date,
                ParentId = 32
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 33,
                Name = "Göyçay",
                AddedDate = date,
                ParentId = 33
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 34,
                Name = "Göygöl",
                AddedDate = date,
                ParentId = 34
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 35,
                Name = "Göytəpə",
                AddedDate = date,
                ParentId = 35
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 36,
                Name = "Hacıqabul",
                AddedDate = date,
                ParentId = 36
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 37,
                Name = "İmişli",
                AddedDate = date,
                ParentId = 37
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 38,
                Name = "İsmayıllı",
                AddedDate = date,
                ParentId = 38
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 39,
                Name = "Kəlbəcər",
                AddedDate = date,
                ParentId = 39
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 40,
                Name = "Kəpəz",
                AddedDate = date,
                ParentId = 40
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 41,
                Name = "Kürdəmir",
                AddedDate = date,
                ParentId = 41
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 42,
                Name = "Laçın",
                AddedDate = date,
                ParentId = 42
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 43,
                Name = "Lənkəran",
                AddedDate = date,
                ParentId = 43
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 44,
                Name = "Lerik",
                AddedDate = date,
                ParentId = 44
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 45,
                Name = "Masallı",
                AddedDate = date,
                ParentId = 45
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 46,
                Name = "Mingəçevir",
                AddedDate = date,
                ParentId = 46
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 47,
                Name = "Naftalan",
                AddedDate = date,
                ParentId = 47
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 48,
                Name = "Naxçıvan",
                AddedDate = date,
                ParentId = 48
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 49,
                Name = "Naxçıvan, Babək",
                AddedDate = date,
                ParentId = 48
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 50,
                Name = "Naxçıvan, Culfa",
                AddedDate = date,
                ParentId = 48
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 51,
                Name = "Naxçıvan, Şahbuz",
                AddedDate = date,
                ParentId = 48
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 52,
                Name = "Naxçıvan, Sədərək",
                AddedDate = date,
                ParentId = 48
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 53,
                Name = "Naxçıvan, Şərur",
                AddedDate = date,
                ParentId = 48
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 54,
                Name = "Naxçıvan, Ordubad",
                AddedDate = date,
                ParentId = 48
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 55,
                Name = "Neftçala",
                AddedDate = date,
                ParentId = 55
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 56,
                Name = "Oğuz",
                AddedDate = date,
                ParentId = 56
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 57,
                Name = "Ordubad",
                AddedDate = date,
                ParentId = 57
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 58,
                Name = "Qaradağ",
                AddedDate = date,
                ParentId = 58
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 59,
                Name = "Qax",
                AddedDate = date,
                ParentId = 59
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 60,
                Name = "Qazax",
                AddedDate = date,
                ParentId = 60
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 61,
                Name = "Qəbələ",
                AddedDate = date,
                ParentId = 61
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 62,
                Name = "Qobustan",
                AddedDate = date,
                ParentId = 62
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 63,
                Name = "Quba",
                AddedDate = date,
                ParentId = 63
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 64,
                Name = "Qubadlı",
                AddedDate = date,
                ParentId = 64
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 65,
                Name = "Qusar",
                AddedDate = date,
                ParentId = 65
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 66,
                Name = "Saatlı",
                AddedDate = date,
                ParentId = 66
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 67,
                Name = "Sabirabad",
                AddedDate = date,
                ParentId = 67
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 68,
                Name = "Şabran",
                AddedDate = date,
                ParentId = 68
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 69,
                Name = "Salyan",
                AddedDate = date,
                ParentId = 69
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 70,
                Name = "Şamaxı",
                AddedDate = date,
                ParentId = 70
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 71,
                Name = "Samux",
                AddedDate = date,
                ParentId = 71
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 72,
                Name = "Bakı, Səbayıl",
                AddedDate = date,
                ParentId = 72
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 73,
                Name = "Şəki",
                AddedDate = date,
                ParentId = 73
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 74,
                Name = "Şəmkir",
                AddedDate = date,
                ParentId = 74
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 75,
                Name = "Şirvan",
                AddedDate = date,
                ParentId = 75
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 76,
                Name = "Siyəzən",
                AddedDate = date,
                ParentId = 76
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 77,
                Name = "Sumqayıt",
                AddedDate = date,
                ParentId = 77
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 78,
                Name = "Şuşa",
                AddedDate = date,
                ParentId = 78
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 79,
                Name = "Tərtər",
                AddedDate = date,
                ParentId = 79
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 80,
                Name = "Tovuz",
                AddedDate = date,
                ParentId = 80
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 81,
                Name = "Ucar",
                AddedDate = date,
                ParentId = 81
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 82,
                Name = "Xaçmaz",
                AddedDate = date,
                ParentId = 82
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 83,
                Name = "Xankəndi",
                AddedDate = date,
                ParentId = 83
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 84,
                Name = "Xızı",
                AddedDate = date,
                ParentId = 84
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 85,
                Name = "Xocalı",
                AddedDate = date,
                ParentId = 85
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 86,
                Name = "Xocavənd",
                AddedDate = date,
                ParentId = 86
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 87,
                Name = "Xudat",
                AddedDate = date,
                ParentId = 87
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 88,
                Name = "Yardımlı",
                AddedDate = date,
                ParentId = 88
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 89,
                Name = "Bakı, Yasamal",
                AddedDate = date,
                ParentId = 89
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 90,
                Name = "Yevlax",
                AddedDate = date,
                ParentId = 90
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 91,
                Name = "Zaqatala",
                AddedDate = date,
                ParentId = 91
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 92,
                Name = "Zəngilan",
                AddedDate = date,
                ParentId = 92
            });
            context.Regions.AddOrUpdate(new Region()
            {
                Id = 93,
                Name = "Zərdab",
                AddedDate = date,
                ParentId = 93
            });
        }
    }
}
