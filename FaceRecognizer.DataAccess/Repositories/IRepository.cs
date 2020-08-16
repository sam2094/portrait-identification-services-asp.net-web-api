using FaceRecognizer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FaceRecognizer.DataAccess.Repositories
{
    public interface IRepository<T> where T: BaseEntity
    {
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        T Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        T GetLast(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        int Count(Expression<Func<T, bool>> predicate = null);
        bool IsExist(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
    }
}
