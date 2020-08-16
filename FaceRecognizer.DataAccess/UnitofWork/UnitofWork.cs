using FaceRecognizer.Models.Entities;
using FaceRecognizer.DataAccess.Repositories;
using System;
using System.Data.Entity;

namespace FaceRecognizer.DataAccess.UnitofWork
{
    public class UnitofWork : IUnitofWork, IDisposable
    {
        private bool disposed = false;
        private readonly DbContext _dbContext;
        
        public DbContextTransaction Transaction { get; set; }


        public UnitofWork(DbContext dbContext) => _dbContext = dbContext;

        #region IUnitOfWork Members
        public IRepository<T> GetRepository<T>() where T : BaseEntity => new Repository<T>(_dbContext);

        public void BeginTransaction() => Transaction = _dbContext.Database.BeginTransaction();

        public void Commit()
        {
            try
            {
                Transaction.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public void Rollback()
        {
            try
            {
                Transaction.Rollback();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SaveChanges()
        {
            try
            {
                return _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region IDisposable Members
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
