using FaceRecognizer.BusinessLogic.Logic.UserLogic;
using FaceRecognizer.Common.ConfigManager;
using FaceRecognizer.Common.Enums;
using FaceRecognizer.Common.FileManager;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models;
using FaceRecognizer.Models.LogicParameters.UserLogic;
using FaceRecognizer.Tests.Mock;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;

namespace FaceRecognizer.Tests.UserTests
{
    [TestFixture]
    public class GetUserByIdTest
    {
        private IUnitofWork _uow;
        private MockDataContext _context;
        private Mock<IFileOperations> _fileOperations;
        private Mock<IConfigOperations> _configOperation;

        [SetUp]
        public void SetUp()
        {
            _context = new MockDataContext();
            _uow = new MockUnitOfWork(_context);
            _fileOperations = new Mock<IFileOperations>();
            _configOperation = new Mock<IConfigOperations>();
        }

        [Test]
        public void WhenCalled_ReturnSuccess()
        {
            GetUserByIdInput input = new GetUserByIdInput
            {
                UserId = 1,
                CurrentUserId = 1
            };
            _fileOperations.Setup(s => s.ReadAllBytes(It.IsAny<string>())).Returns(It.IsAny<byte[]>());
            _configOperation.Setup(s => s.Get(It.IsAny<string>())).Returns("test");

            LogicResult<GetUserByIdOutput> result = new GetUserById(_uow, _fileOperations.Object, _configOperation.Object, nameof(GetUserById)).Execute(input);


            _fileOperations.Verify(s => s.ReadAllBytes(It.IsAny<string>()));
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual(result.Output.User.Id, input.UserId);
        }

        [Test]
        public void WhenCalled_ReturnUserNotFound()
        {
            GetUserByIdInput input = new GetUserByIdInput
            {
                UserId = 85,
                CurrentUserId = 1
            };

            LogicResult<GetUserByIdOutput> result = new GetUserById(_uow, _fileOperations.Object, _configOperation.Object, nameof(GetUserById)).Execute(input);

            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(result.ErrorList.FirstOrDefault().ErrorCode, ErrorCodes.USER_IS_NOT_EXIST);
        }



        [Test]
        public void WhenCalled_ReturnBranchNotFound()
        {
            GetUserByIdInput input = new GetUserByIdInput
            {
                UserId = 2,
                CurrentUserId = 1
            };

            LogicResult<GetUserByIdOutput> result = new GetUserById(_uow, _fileOperations.Object, _configOperation.Object, nameof(GetUserById)).Execute(input);

            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(result.ErrorList.FirstOrDefault().ErrorCode, ErrorCodes.BRANCH_IS_NOT_EXIST);
        }

        [Test]
        public void When_ConfigOperation_Throws_Exception_ReturnInternalError()
        {
            GetUserByIdInput input = new GetUserByIdInput
            {
                UserId = 1
            };
            _configOperation.Setup(s => s.Get(It.IsAny<string>())).Throws<Exception>();

            LogicResult<GetUserByIdOutput> result = new GetUserById(_uow, _fileOperations.Object, _configOperation.Object, nameof(GetUserById)).Execute(input);

            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(result.ErrorList.FirstOrDefault().ErrorCode, ErrorCodes.INTERNAL_ERROR);
        }

        [Test]
        public void When_FileOperation_Throws_Exception_ReturnInternalError()
        {
            GetUserByIdInput input = new GetUserByIdInput
            {
                UserId = 1
            };
            _fileOperations.Setup(s => s.ReadAllBytes(It.IsAny<string>())).Throws<Exception>();

            LogicResult<GetUserByIdOutput> result = new GetUserById(_uow, _fileOperations.Object, _configOperation.Object, nameof(GetUserById)).Execute(input);

            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(result.ErrorList.FirstOrDefault().ErrorCode, ErrorCodes.INTERNAL_ERROR);
        }

    }
}
