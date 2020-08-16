using FaceRecognizer.DataAccess.Repositories;
using FaceRecognizer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FaceRecognizer.Tests.Mock
{
    public class MockRepository<T> : IRepository<T> where T : BaseEntity
    {
        public List<T> _context;

        public MockRepository(List<T> context)
        {
            _context = context;
        }
        #region IRepository Members
        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            return Include(includes);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return Include(includes).Where(predicate);
        }

        public T Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return Include(includes).FirstOrDefault(predicate);
        }

        public T GetLast(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return Include(includes).LastOrDefault(predicate);
        }

        public int Count(Expression<Func<T, bool>> predicate = null)
        {
            return predicate == null ? _context.Count() : _context.AsQueryable().Where(predicate).Count();
        }
        public bool IsExist(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return Include(includes).Any(predicate);
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.AddRange(entities);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _context.RemoveAll(x => x == entities);
        }

        private IQueryable<T> Include(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.AsQueryable();
            //includes.ForEach(includeItem =>
            //{
            //    //
            //});
            return query;
        }
        #endregion
    }
}
