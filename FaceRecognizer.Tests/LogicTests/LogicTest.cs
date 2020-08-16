using FaceRecognizer.BusinessLogic;
using FaceRecognizer.Common;
using FaceRecognizer.Common.Enums;
using FaceRecognizer.Common.Resources;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FaceRecognizer.Tests.LogicTests
{
    [TestFixture]
    public class LogicTest
    {
        private Mock<IUnitofWork> _uow;
        private Mock<Logic<LogicInput, LogicOutput>> _logic;

        [SetUp]
        public void SetUp()
        {
            _uow = new Mock<IUnitofWork>();
        }

        [Test]
        public void WhenCalledWithTransaction_ReturnSuccess()
        {
            _logic = new Mock<Logic<LogicInput, LogicOutput>>(_uow.Object, "Logic`2Proxy", true);
            _uow.Setup(s => s.BeginTransaction());
            _uow.Setup(s => s.Commit());
            _uow.Setup(s => s.Dispose());
            _logic.Setup(s => s.DoExecute());

            LogicResult<LogicOutput> result = _logic.Object.Execute(new LogicInput { });

            _uow.Verify(v => v.BeginTransaction());
            _uow.Verify(v => v.Commit());
            _uow.Verify(v => v.Dispose());
            Assert.IsTrue(result.IsSuccess);
        }

        [Test]
        public void WhenCalledWithTransactionAsync_ReturnSuccess()
        {
            _logic = new Mock<Logic<LogicInput, LogicOutput>>(_uow.Object, "Logic`2Proxy", true);
            _uow.Setup(s => s.BeginTransaction());
            _uow.Setup(s => s.Commit());
            _uow.Setup(s => s.Dispose());
            _logic.Setup(s => s.DoExecuteAsync());

            LogicResult<LogicOutput> result = _logic.Object.Execute(new LogicInput { });

            _uow.Verify(v => v.BeginTransaction());
            _uow.Verify(v => v.Commit());
            _uow.Verify(v => v.Dispose());
            Assert.IsTrue(result.IsSuccess);
        }

        [Test]
        public void WhenCalledWithOutTransaction_ReturnSuccess()
        {
            _logic = new Mock<Logic<LogicInput, LogicOutput>>(_uow.Object, "Logic`2Proxy", false);
            _uow.Setup(s => s.Dispose());
            _logic.Setup(s => s.DoExecute());

            LogicResult<LogicOutput> result = _logic.Object.Execute(new LogicInput { });

            _uow.Verify(v => v.Dispose());
            Assert.IsTrue(result.IsSuccess);
        }

        [Test]
        public async Task WhenCalledWithOutTransactionAsync_ReturnSuccess()
        {
            _logic = new Mock<Logic<LogicInput, LogicOutput>>(_uow.Object, "Logic`2Proxy", false);
            _uow.Setup(s => s.Dispose());
            _logic.Setup(s => s.DoExecuteAsync());

            LogicResult<LogicOutput> result =await _logic.Object.ExecuteAsync(new LogicInput { });

            _uow.Verify(v => v.Dispose());
            Assert.IsTrue(result.IsSuccess);
        }

        [Test]
        public void WhenCalledWithInnerLogic_ReturnSuccess()
        {
            _logic = new Mock<Logic<LogicInput, LogicOutput>>(_uow.Object, It.IsAny<string>(), It.IsAny<bool>());
            _logic.Setup(s => s.DoExecute());

            LogicResult<LogicOutput> result = _logic.Object.Execute(new LogicInput { });

            Assert.IsTrue(result.IsSuccess);
        }

        [Test]
        public async Task WhenCalledWithInnerLogicAsync_ReturnSuccess()
        {
            _logic = new Mock<Logic<LogicInput, LogicOutput>>(_uow.Object, It.IsAny<string>(), It.IsAny<bool>());
            _logic.Setup(s => s.DoExecuteAsync());

            LogicResult<LogicOutput> result =await _logic.Object.ExecuteAsync(new LogicInput { });

            Assert.IsTrue(result.IsSuccess);
        }

        [Test]
        public void DoExecuteWithTransaction_WhenCalled_ReturnInternalError()
        {
            _logic = new Mock<Logic<LogicInput, LogicOutput>>(_uow.Object, "Logic`2Proxy", true);
            _uow.Setup(s => s.BeginTransaction());
            _uow.Setup(s => s.Commit());
            _uow.Setup(s => s.Rollback());
            _uow.Setup(s => s.Dispose());
            _logic.Setup(s => s.DoExecute()).Throws<Exception>();

            LogicResult<LogicOutput> result = _logic.Object.Execute(new LogicInput { });

            _uow.Verify(v => v.BeginTransaction());
            _uow.Verify(v => v.Rollback());
            _uow.Verify(v => v.Dispose());
            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(ErrorCodes.INTERNAL_ERROR, result.ErrorList.FirstOrDefault().ErrorCode);
        }

        [Test]
        public async Task DoExecuteWithTransactionAsync_WhenCalled_ReturnInternalError()
        {
            _logic = new Mock<Logic<LogicInput, LogicOutput>>(_uow.Object, "Logic`2Proxy", true);
            _uow.Setup(s => s.BeginTransaction());
            _uow.Setup(s => s.Commit());
            _uow.Setup(s => s.Rollback());
            _uow.Setup(s => s.Dispose());
            _logic.Setup(s => s.DoExecuteAsync()).Throws<Exception>();

            LogicResult<LogicOutput> result =await _logic.Object.ExecuteAsync(new LogicInput { });

            _uow.Verify(v => v.BeginTransaction());
            _uow.Verify(v => v.Rollback());
            _uow.Verify(v => v.Dispose());
            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(ErrorCodes.INTERNAL_ERROR, result.ErrorList.FirstOrDefault().ErrorCode);
        }

        [Test]
        public void DoExecuteWithOutTransaction_WhenCalled_ReturnInternalError()
        {
            _logic = new Mock<Logic<LogicInput, LogicOutput>>(_uow.Object, "Logic`2Proxy", false);
            _uow.Setup(s => s.Dispose());
            _logic.Setup(s => s.DoExecute()).Throws<Exception>();

            LogicResult<LogicOutput> result = _logic.Object.Execute(new LogicInput { });

            _uow.Verify(v => v.Dispose());
            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(ErrorCodes.INTERNAL_ERROR, result.ErrorList.FirstOrDefault().ErrorCode);
        }

        [Test]
        public async Task DoExecuteWithOutTransactionAsync_WhenCalled_ReturnInternalError()
        {
            _logic = new Mock<Logic<LogicInput, LogicOutput>>(_uow.Object, "Logic`2Proxy", false);
            _uow.Setup(s => s.Dispose());
            _logic.Setup(s => s.DoExecuteAsync()).Throws<Exception>();

            LogicResult<LogicOutput> result = await _logic.Object.ExecuteAsync(new LogicInput { });

            _uow.Verify(v => v.Dispose());
            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(ErrorCodes.INTERNAL_ERROR, result.ErrorList.FirstOrDefault().ErrorCode);
        }

        [Test]
        public void DoExecuteWithInnerLogic_WhenCalled_ReturnInternalError()
        {
            _logic = new Mock<Logic<LogicInput, LogicOutput>>(_uow.Object, It.IsAny<string>(), It.IsAny<bool>());
            _logic.Setup(s => s.DoExecute()).Throws<Exception>();

            LogicResult<LogicOutput> result = _logic.Object.Execute(new LogicInput { });

            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(ErrorCodes.INTERNAL_ERROR, result.ErrorList.FirstOrDefault().ErrorCode);
        }

        [Test]
        public async Task DoExecuteWithInnerLogicAsync_WhenCalled_ReturnInternalError()
        {
            _logic = new Mock<Logic<LogicInput, LogicOutput>>(_uow.Object, It.IsAny<string>(), It.IsAny<bool>());
            _logic.Setup(s => s.DoExecuteAsync()).Throws<Exception>();

            LogicResult<LogicOutput> result = await _logic.Object.ExecuteAsync(new LogicInput { });

            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(ErrorCodes.INTERNAL_ERROR, result.ErrorList.FirstOrDefault().ErrorCode);
        }

        [Test]
        public void DoExecuteWithBaseLogicWithTransaction_WhenInnerLogicExecute_ReturnInternalError()
        {
            _logic = new Mock<Logic<LogicInput, LogicOutput>>(_uow.Object, "Logic`2Proxy", true);
            _logic.Object.Result.ErrorList.Add(new Error
            {
                ErrorCode = ErrorCodes.INTERNAL_ERROR,
                ErrorMessage = Resource.UNHANDLED_EXCEPTION,
                StatusCode = ErrorHttpStatus.INTERNAL
            });
            _logic.Setup(s => s.DoExecute());
            _uow.Setup(s => s.Rollback());

            LogicResult<LogicOutput> result = _logic.Object.Execute(new LogicInput { });

            _uow.Verify(v => v.Rollback());
            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(ErrorCodes.INTERNAL_ERROR, result.ErrorList.FirstOrDefault().ErrorCode);
        }

        [Test]
        public void DoExecuteWithBaseLogicWithTransactionAsync_WhenInnerLogicExecute_ReturnInternalError()
        {
            _logic = new Mock<Logic<LogicInput, LogicOutput>>(_uow.Object, "Logic`2Proxy", true);
            _logic.Object.Result.ErrorList.Add(new Error
            {
                ErrorCode = ErrorCodes.INTERNAL_ERROR,
                ErrorMessage = Resource.UNHANDLED_EXCEPTION,
                StatusCode = ErrorHttpStatus.INTERNAL
            });
            _logic.Setup(s => s.DoExecuteAsync());
            _uow.Setup(s => s.Rollback());

            LogicResult<LogicOutput> result = _logic.Object.Execute(new LogicInput { });

            _uow.Verify(v => v.Rollback());
            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(ErrorCodes.INTERNAL_ERROR, result.ErrorList.FirstOrDefault().ErrorCode);
        }

        [Test]
        public void DoExecuteWithBaseLogicWithoutTransaction_WhenInnerLogicExecute_ReturnInternalError()
        {
            _logic = new Mock<Logic<LogicInput, LogicOutput>>(_uow.Object, "Logic`2Proxy", false);
            _logic.Object.Result.ErrorList.Add(new Error
            {
                ErrorCode = ErrorCodes.INTERNAL_ERROR,
                ErrorMessage = Resource.UNHANDLED_EXCEPTION,
                StatusCode = ErrorHttpStatus.INTERNAL
            });
            _logic.Setup(s => s.DoExecute());

            LogicResult<LogicOutput> result = _logic.Object.Execute(new LogicInput { });

            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(ErrorCodes.INTERNAL_ERROR, result.ErrorList.FirstOrDefault().ErrorCode);
        }

        [Test]
        public void DoExecuteWithBaseLogicWithoutTransactionAsync_WhenInnerLogicExecute_ReturnInternalError()
        {
            _logic = new Mock<Logic<LogicInput, LogicOutput>>(_uow.Object, "Logic`2Proxy", false);
            _logic.Object.Result.ErrorList.Add(new Error
            {
                ErrorCode = ErrorCodes.INTERNAL_ERROR,
                ErrorMessage = Resource.UNHANDLED_EXCEPTION,
                StatusCode = ErrorHttpStatus.INTERNAL
            });
            _logic.Setup(s => s.DoExecuteAsync());

            LogicResult<LogicOutput> result = _logic.Object.Execute(new LogicInput { });

            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(ErrorCodes.INTERNAL_ERROR, result.ErrorList.FirstOrDefault().ErrorCode);
        }

        [Test]
        public void BeginTransaction_WhenCalled_ReturnInternalError()
        {
            _logic = new Mock<Logic<LogicInput, LogicOutput>>(_uow.Object, "Logic`2Proxy", true);
            _uow.Setup(s => s.BeginTransaction()).Throws<Exception>();

            LogicResult<LogicOutput> result = _logic.Object.Execute(new LogicInput { });

            _uow.Verify(v => v.Rollback());
            _uow.Verify(v => v.Dispose());
            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(ErrorCodes.INTERNAL_ERROR, result.ErrorList.FirstOrDefault().ErrorCode);
        }


        [Test]
        public void Commit_WhenCalled_ReturnInternalError()
        {
            _logic = new Mock<Logic<LogicInput, LogicOutput>>(_uow.Object, "Logic`2Proxy", true);
            _uow.Setup(s => s.BeginTransaction());
            _uow.Setup(s => s.Dispose());
            _uow.Setup(s => s.Commit()).Throws<Exception>();

            LogicResult<LogicOutput> result = _logic.Object.Execute(new LogicInput { });

            _uow.Verify(v => v.BeginTransaction());
            _uow.Verify(v => v.Dispose());
            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(ErrorCodes.INTERNAL_ERROR, result.ErrorList.FirstOrDefault().ErrorCode);
        }

        [Test]
        public void RollBack_WhenCalled_ReturnInternalError()
        {
            _logic = new Mock<Logic<LogicInput, LogicOutput>>(_uow.Object, "Logic`2Proxy", true);
            _logic.Setup(s => s.DoExecute()).Throws<Exception>();
            _uow.Setup(s => s.BeginTransaction());
            _uow.Setup(s => s.Dispose());
            _uow.Setup(s => s.Rollback()).Throws<Exception>();

            LogicResult<LogicOutput> result = _logic.Object.Execute(new LogicInput { });

            _uow.Verify(v => v.BeginTransaction());
            _uow.Verify(v => v.Dispose());
            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(ErrorCodes.INTERNAL_ERROR, result.ErrorList.FirstOrDefault().ErrorCode);
        }

        [Test]
        public async Task RollBack_WhenCalledAsync_ReturnInternalError()
        {
            _logic = new Mock<Logic<LogicInput, LogicOutput>>(_uow.Object, "Logic`2Proxy", true);
            _logic.Setup(s => s.DoExecuteAsync()).Throws<Exception>();
            _uow.Setup(s => s.BeginTransaction());
            _uow.Setup(s => s.Dispose());
            _uow.Setup(s => s.Rollback()).Throws<Exception>();

            LogicResult<LogicOutput> result = await _logic.Object.ExecuteAsync(new LogicInput { });

            _uow.Verify(v => v.BeginTransaction());
            _uow.Verify(v => v.Dispose());
            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(ErrorCodes.INTERNAL_ERROR, result.ErrorList.FirstOrDefault().ErrorCode);
        }
    }
}
