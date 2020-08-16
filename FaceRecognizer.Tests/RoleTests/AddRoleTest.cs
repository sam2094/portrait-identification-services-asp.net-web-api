using FaceRecognizer.BusinessLogic.Logic.RoleLogic;
using FaceRecognizer.Common.Enums;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models;
using FaceRecognizer.Models.LogicParameters.RoleLogic;
using FaceRecognizer.Tests.Mock;
using NUnit.Framework;
using System.Linq;

namespace FaceRecognizer.Tests.RoleTests
{
    [TestFixture]
    public class AddRoleTest
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
            AddRoleInput input = new AddRoleInput
            {
                Name = "TEST",
                Description = "test",
                CurrentUserId = 1
            };

            LogicResult<AddRoleOutput> result = new AddRole(_uow, nameof(AddRole)).Execute(input);

            Assert.IsTrue(result.IsSuccess);
        }

        [Test]
        public void WhenCalled_ReturnRoleIsNotExist()
        {
            AddRoleInput input = new AddRoleInput
            {
                Name = "TEST",
                Description = "test",
                CurrentUserId = 1
            };

            LogicResult<AddRoleOutput> result = new AddRole(_uow, nameof(AddRole)).Execute(input);

            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(result.ErrorList.FirstOrDefault().ErrorCode, ErrorCodes.ROLE_DOES_NOT_EXIST);
        }
    }
}
