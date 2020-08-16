using FaceRecognizer.Common;
using FaceRecognizer.Common.Enums;
using FaceRecognizer.Models;
using log4net;
using FaceRecognizer.DataAccess.UnitofWork;
using System;
using System.Linq;
using System.Reflection;
using FaceRecognizer.Common.Resources;
using System.Threading.Tasks;

namespace FaceRecognizer.BusinessLogic
{
    public class Logic<TInput, TOutput>
        where TInput : LogicInput
        where TOutput : LogicOutput, new() 
    {
        public static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Input of the logic
        /// </summary>
        protected TInput Parameters;
        protected readonly IUnitofWork _uow;
        protected readonly string _firstExecutedLogicName; 
        protected readonly bool _beginTransaction;

        /// <summary>
        /// Output of the logic
        /// </summary>
        public LogicResult<TOutput> Result;

        public Logic(IUnitofWork uow,
            string firstExecutedLogicName,
            bool beginTransaction = false)
        {
            _uow = uow;
            _firstExecutedLogicName = firstExecutedLogicName;
            _beginTransaction = beginTransaction;
            Result = new LogicResult<TOutput>
            {
                Output = new TOutput()
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters">Input of the logic. If the method doesn't need input, you have to send empty input object</param>
        /// <param name="beginTransaction">If you want to use entity framework transaction, you must set this parameter true. IMPORTANT: You should set this parameter only when you call from services.</param>
        /// <returns></returns>
        public LogicResult<TOutput> Execute(TInput parameters = null)
        {
            Parameters = parameters;

            try
            {
                Logger.Info($"Executing process started from this class : {GetType()}");

                Begin(_beginTransaction);

                DoExecute();

                if (!Result.IsSuccess)
                {
                    RollBack(_beginTransaction);
                    Logger.Error($"Error occured from this class : {GetType()} : {Result.ErrorList.FirstOrDefault().ErrorMessage}");
                    return Result;
                }

                Commit(_beginTransaction);

                Logger.Info($"Executing process finished from this class : {GetType()}");
            }
            catch (Exception ex)
            {
                Result.ErrorList.Add(new Error
                {
                    ErrorCode = ErrorCodes.INTERNAL_ERROR,
                    ErrorMessage = Resource.UNHANDLED_EXCEPTION,
                    StatusCode = ErrorHttpStatus.INTERNAL
                });

                RollBack(_beginTransaction);

                Logger.Error($"Error occured from this class : {GetType()} : {ex.ToString()}");
            }

            return Result;
        }

        /// <summary>
        /// Main logic method
        /// </summary>
        public virtual void DoExecute() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters">Input of the logic. If the method doesn't need input, you have to send empty input object</param>
        /// <param name="beginTransaction">If you want to use entity framework transaction, you must set this parameter true. IMPORTANT: You should set this parameter only when you call from services.</param>
        /// <returns></returns>
        public async Task<LogicResult<TOutput>> ExecuteAsync(TInput parameters = null)
        {
            Parameters = parameters;

            try
            {
                Logger.Info($"Executing process started from this class : {GetType()}");

                Begin(_beginTransaction);

                await DoExecuteAsync();

                if (!Result.IsSuccess)
                {
                    RollBack(_beginTransaction);
                    Logger.Error($"Error occured from this class : {GetType()} : {Result.ErrorList.FirstOrDefault().ErrorMessage}");
                    return Result;
                }

                Commit(_beginTransaction);

                Logger.Info($"Executing process finished from this class : {GetType()}");
            }
            catch (Exception ex)
            {
                Result.ErrorList.Add(new Error
                {
                    ErrorCode = ErrorCodes.INTERNAL_ERROR,
                    ErrorMessage = Resource.UNHANDLED_EXCEPTION,
                    StatusCode = ErrorHttpStatus.INTERNAL
                });

                RollBack(_beginTransaction);

                Logger.Error($"Error occured from this class : {GetType()} : {ex.ToString()}");
            }

            return Result;
        }

        /// <summary>
        /// Main logic method
        /// </summary>
        public virtual async Task DoExecuteAsync() { await Task.CompletedTask; }

        /// <summary>
        /// If the instance belong first called logic in logic-chain it will begin transaction
        /// </summary>
        /// <param name="beginTransaction"></param>
        private void Begin(bool beginTransaction)
        {
            if (GetType().Name == _firstExecutedLogicName && beginTransaction)
                _uow.BeginTransaction();
        }

        /// <summary>
        /// If the instance belong first called logic in logic-chain it will commit transaction
        /// </summary>
        /// <param name="beginTransaction"></param>
        private void Commit(bool beginTransaction)
        {
            bool disposed = GetType().Name == _firstExecutedLogicName;
            if (disposed)
            {
                try
                {
                    if (beginTransaction) _uow.Commit();
                }
                catch (Exception ex)
                {
                    Result.ErrorList.Add(new Error
                    {
                        ErrorCode = ErrorCodes.INTERNAL_ERROR,
                        ErrorMessage = Resource.UNHANDLED_EXCEPTION,
                        StatusCode = ErrorHttpStatus.INTERNAL
                    });

                    Logger.Error($"Error occured commit : {ex.ToString()}");
                }
                finally
                {
                    _uow.Dispose();
                }
            }
        }

        /// <summary>
        /// If the instance belong first called logic in logic-chain it will rollback transaction
        /// </summary>
        /// <param name="beginTransaction"></param>
        private void RollBack(bool beginTransaction)
        {
            bool disposed = GetType().Name == _firstExecutedLogicName;
            if (disposed)
            {
                try
                {
                    if (beginTransaction) _uow.Rollback();
                }
                catch (Exception ex)
                {
                    Result.ErrorList.Add(new Error
                    {
                        ErrorCode = ErrorCodes.INTERNAL_ERROR,
                        ErrorMessage = Resource.UNHANDLED_EXCEPTION,
                        StatusCode = ErrorHttpStatus.INTERNAL
                    });

                    Logger.Error($"Error occured rollback : {ex.ToString()}");
                }
                finally
                {
                    _uow.Dispose();
                }
            }
        }
    }
}
