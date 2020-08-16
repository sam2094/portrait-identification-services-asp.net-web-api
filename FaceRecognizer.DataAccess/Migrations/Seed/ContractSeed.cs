using FaceRecognizer.Common.Enums.DatabaseEnums;
using FaceRecognizer.DataAccess.Database;
using FaceRecognizer.Models.Entities;
using System;
using System.Data.Entity.Migrations;

namespace FaceRecognizer.DataAccess.Migrations.Seed
{
	public class ContractSeed : BaseSeed
	{
		public static void Seed(MyDbContext context)
		{
			context.Contracts.AddOrUpdate(new Contract()
			{
				Id = 1,
				AddedDate = DateTime.Now,
				ContactNumber = "709949796",
				ContractStatusId = (byte)ContractStatuses.APPROVED,
				BranchId = 1,
				DeliveryAddress = "test",
				DocumentInformationId = 1,
				Email = "test@test.com",
				ICCID = 123456789,
				IMSI = 123456789,
				Index = "test",
				IsExplanatoryContracts = true,
				IsRefrainAdvertising = true,
				IsSendAddress = true,
				IsSendEmail = true,
				PhoneNumber = "709949796",
				UpdateDate = DateTime.Now,
				TarifId = 1,
				UserId = 1,
				OperationTypeId = 1,
			});
			context.Contracts.AddOrUpdate(new Contract()
			{
				Id = 2,
				AddedDate = DateTime.Now,
				ContactNumber = "701111111",
				ContractStatusId = (byte)ContractStatuses.NEW,
				BranchId = 2,
				DeliveryAddress = "test2",
				DocumentInformationId = 2,
				Email = "test2@test.com",
				ICCID = 11213141516,
				IMSI = 11213141516,
				Index = "test2",
				IsExplanatoryContracts = false,
				IsRefrainAdvertising = true,
				IsSendAddress = true,
				IsSendEmail = true,
				PhoneNumber = "501111111",
				UpdateDate = DateTime.Now,
				TarifId = 2,
				UserId = 4,
				OperationTypeId = 2,
			});
			context.Contracts.AddOrUpdate(new Contract()
			{
				Id = 3,
				AddedDate = DateTime.Now,
				ContactNumber = "701111111",
				ContractStatusId = (byte)ContractStatuses.APPROVED,
				BranchId = 3,
				DeliveryAddress = "test",
				DocumentInformationId = 3,
				Email = "test@test.com",
				ICCID = 123456789,
				IMSI = 123456789,
				Index = "test",
				IsExplanatoryContracts = true,
				IsRefrainAdvertising = true,
				IsSendAddress = true,
				IsSendEmail = true,
				PhoneNumber = "501111111",
				UpdateDate = DateTime.Now,
				TarifId = 3,
				UserId = 1,
				OperationTypeId = 1,
			});
		}
	}
}
