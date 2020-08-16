using FaceRecognizer.Common.Enums.DatabaseEnums;
using FaceRecognizer.DataAccess.Database;
using FaceRecognizer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognizer.DataAccess.Migrations.Seed
{
    public class DocumentInformationSeed : BaseSeed
    {
        public static void Seed(MyDbContext context)
        {
            context.DocumentInformations.AddOrUpdate(new DocumentInformation()
            {
                Id = 1,
                BirthAddress = "test",
                BirthDate = DateTime.Now,
                CitizenshipId = (byte)Citizenships.CITIZEN,
                DocumentNumber = "AA0197977",
                DocumentPin = "19VQAFP",
                DocumentOrganization = "test",
                DocumentSeries = "test",
                DocumentTypeId = 1,
                EventDate = "test",
                ExpireDate = "test",
                GenderId = (byte)Genders.MALE,
                Name = "EMİN",
                Surname = "NOVRUZOV",
                Patronymic = "BƏLAHƏR",
                RegisterCity = "test",
                RegisterHousing = "test",
                RegisterStreet = "test",
				Photo = "23b17f26d3cb4b7ab372b199a563ab6f.jpg"
			});
			context.DocumentInformations.AddOrUpdate(new DocumentInformation()
			{
				Id = 2,
				BirthAddress = "test2",
				BirthDate = DateTime.Now,
				CitizenshipId = (byte)Citizenships.CITIZEN,
				DocumentNumber = "14870378",
				DocumentPin = "4QYZTCC",
				DocumentOrganization = "test2",
				DocumentSeries = "test2",
				DocumentTypeId = 1,
				EventDate = "test2",
				ExpireDate = "test2",
				GenderId = (byte)Genders.MALE,
				Name = "QNYAZ",
				Surname = "YAQUBOV",
				Patronymic = "QIYAS ",
				RegisterCity = "test2",
				RegisterHousing = "test2",
				RegisterStreet = "test2",
				Photo = "23b17f26d3cb4b7ab372b199a563ab6f.jpg"
			});
			context.DocumentInformations.AddOrUpdate(new DocumentInformation()
			{
				Id = 3,
				BirthAddress = "test3",
				BirthDate = DateTime.Now,
				CitizenshipId = (byte)Citizenships.CITIZEN,
				DocumentNumber = "16632738",
				DocumentPin = "2BCLF7Q",
				DocumentOrganization = "test",
				DocumentSeries = "test3",
				DocumentTypeId = 1,
				EventDate = "test3",
				ExpireDate = "test3",
				GenderId = (byte)Genders.MALE,
				Name = "RÜFƏT",
				Surname = "ƏSGƏROV",
				Patronymic = "CƏLALƏDDİN",
				RegisterCity = "test3",
				RegisterHousing = "test3",
				RegisterStreet = "test3",
				Photo = "23b17f26d3cb4b7ab372b199a563ab6f.jpg"
			});
			context.DocumentInformations.AddOrUpdate(new DocumentInformation()
			{
				Id = 4,
				BirthAddress = "test4",
				BirthDate = DateTime.Now,
				CitizenshipId = (byte)Citizenships.CITIZEN,
				DocumentNumber = "17302183",
				DocumentPin = "2LX437L",
				DocumentOrganization = "test4",
				DocumentSeries = "test4",
				DocumentTypeId = 1,
				EventDate = "test4",
				ExpireDate = "test4",
				GenderId = (byte)Genders.MALE,
				Name = "NƏSİR",
				Surname = "ƏLİYEV",
				Patronymic = "QURBAN ",
				RegisterCity = "test4",
				RegisterHousing = "test4",
				RegisterStreet = "test4",
				Photo = "23b17f26d3cb4b7ab372b199a563ab6f.jpg"
			});
		}
    }
}
