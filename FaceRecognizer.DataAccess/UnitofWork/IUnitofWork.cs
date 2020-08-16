using FaceRecognizer.Models.Entities;
using FaceRecognizer.DataAccess.Repositories;
using System;

namespace FaceRecognizer.DataAccess.UnitofWork
{
    public interface IUnitofWork : IDisposable
    {
        /// <summary> 
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
        /// <summary>
        /// 
        /// </summary>
        void BeginTransaction();
        /// <summary>
        /// 
        /// </summary>
        void Commit();
        /// <summary>
        /// 
        /// </summary>
        void Rollback();
    }
}
