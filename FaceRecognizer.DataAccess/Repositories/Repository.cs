using FaceRecognizer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace FaceRecognizer.DataAccess.Repositories
{
	public sealed class Repository<T> : IRepository<T> where T : BaseEntity
	{
		private readonly DbContext _dbContext;
		private readonly DbSet<T> _dbSet;

		public Repository(DbContext dbContext)
		{
			_dbContext = dbContext;
			_dbSet = _dbContext.Set<T>();
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
			return GetAll(predicate).ToList().LastOrDefault();
		}

		public int Count(Expression<Func<T, bool>> predicate = null)
		{
			return predicate == null ? _dbSet.Count() : _dbSet.Count(predicate);
		}

		public bool IsExist(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
		{
			return Include(includes).Any(predicate);
		}

		public void Add(T entity)
		{
			_dbSet.Add(entity);
		}

		public void AddRange(IEnumerable<T> entities)
		{
			_dbSet.AddRange(entities);
		}

		public void Delete(T entity)
		{
			_dbSet.Remove(entity);
		}

		public void DeleteRange(IEnumerable<T> entities)
		{
			_dbSet.RemoveRange(entities);
		}

		private IQueryable<T> Include(params Expression<Func<T, object>>[] includes)
		{
			IQueryable<T> query = _dbSet;
			includes.ForEach(includeItem => query = query.Include(includeItem));
			return query;
		}
		#endregion
	}
}
