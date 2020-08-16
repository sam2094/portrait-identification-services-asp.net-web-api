using FaceRecognizer.BusinessLogic.Logic.RoleLogic;
using FaceRecognizer.Common.Enums;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models;
using FaceRecognizer.Models.LogicParameters.RoleLogic;
using FaceRecognizer.Tests.Mock;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace FaceRecognizer.Tests.RoleTests
{
    [TestFixture]
    public class EditRoleTest
    {
        private IUnitofWork _uow;
        private MockDataContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = new MockDataContext();
            _uow = new MockUnitOfWork(_context);
        }

        [Test]
        public void WhenCalled_ReturnSuccess()
        {
            EditRoleInput input = new EditRoleInput
            {
                Name = "TEST",
                Description = "test",
                RoleId = 1,
                ClaimIds = new List<int>() { 1, 2, 3 },
                CurrentUserId = 1
            };

            LogicResult<EditRoleOutput> result = new EditRole(_uow, nameof(EditRole)).Execute(input);

            Assert.IsTrue(result.IsSuccess);
        }

        [Test]
        public void WhenCalled_ReturnRoleIsNotExist()
        {
            EditRoleInput input = new EditRoleInput
            {
                Name = "TEST",
                Description = "test",
                RoleId = 35,
                ClaimIds = new List<int>() { 1, 2, 3 },
                CurrentUserId = 1
            };

            LogicResult<EditRoleOutput> result = new EditRole(_uow, nameof(EditRole)).Execute(input);

            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(result.ErrorList.FirstOrDefault().ErrorCode, ErrorCodes.ROLE_DOES_NOT_EXIST);
        }

        [Test]
        public void WhenCalled_ReturnClaimIsNotExist()
        {
            EditRoleInput input = new EditRoleInput
            {
                Name = "TEST",
                Description = "test",
                RoleId = 1,
                ClaimIds = new List<int>() { 1, 2, 3, 5 },
                CurrentUserId = 1
            };

            LogicResult<EditRoleOutput> result = new EditRole(_uow, nameof(EditRole)).Execute(input);

            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(result.ErrorList.FirstOrDefault().ErrorCode, ErrorCodes.CLAIM_DOES_NOT_EXIST);
        }
    }
}
