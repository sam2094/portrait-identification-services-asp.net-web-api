using FaceRecognizer.Models.Entities;
using Moq;
using System;
using System.Collections.Generic;

namespace FaceRecognizer.Tests.Mock
{
	public class MockDataContext
	{
		//public List<User> User
		//{
		//	get
		//	{
		//		return new List<User>
		//		{
		//			new User
		//			{
		//				Id = 1,
		//				Name = It.IsAny<string>(),
		//				BranchId = 1,
		//				AddedDate = It.IsAny<DateTime>(),
		//				Username= It.IsAny<string>(),
		//				DocumentNumber =It.IsAny<string>(),
		//				DocumentPin = It.IsAny<string>(),
		//				IsFaceRecognized = true,
		//				Patronymic = It.IsAny<string>(),
		//				Branch = new Branch{ PlaceName = It.IsAny<string>(), OrganizationId =1, Organization = new Organization { Id = 1,  Name = It.IsAny<string>() } },
		//				UserStatus = new UserStatus{ Name = It.IsAny<string>() },
		//				Photo = "test",
		//				Role = new Role {OrganizationId =1, Id = 1, Claims = new List<Claim>(){
		//				new Claim { Id = 1 },
		//				new Claim { Id = 2 },
		//				new Claim { Id = 3 },
		//				new Claim { Id = 4 },
		//				} }

		//			},
		//			new User
		//			{
		//				Id = 2,
		//				Name = It.IsAny<string>(),
		//			}
		//		};
		//	}
		//}

		//public List<Branch> Branch
		//{
		//	get
		//	{
		//		return new List<Branch>
		//		{
		//			new Branch
		//			{
		//				Id = 1,
		//				PlaceName = It.IsAny<string>(),
		//				OrganizationId =1
		//			},
		//			new Branch
		//			{
		//				Id = 2,
		//				PlaceName = It.IsAny<string>(),
		//			},
		//			new Branch
		//			{
		//				Id = 3,
		//				PlaceName = It.IsAny<string>(),
		//			}
		//		};
		//	}
		//}

		//public List<Role> Role
		//{
		//	get
		//	{
		//		return new List<Role>
		//		{
		//			new Role{
		//					Id = 1,
		//					Name = "TEST",
		//					Description = "test",
		//					OrganizationId = 1,
		//					Claims=new List<Claim>(){
		//					new Claim { Id = 1 },
		//					new Claim { Id = 2 },
		//					new Claim { Id = 3 }
		//					}
		//					 },
		//			new Role{
		//					Id = 2,
		//					Name = "TEST",
		//					Description = "test",
		//					OrganizationId = 1
		//					 }
		//		};
		//	}
		}
	}
