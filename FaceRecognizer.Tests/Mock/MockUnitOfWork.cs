using FaceRecognizer.DataAccess.Repositories;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FaceRecognizer.Tests.Mock
{
    public class MockUnitOfWork : IUnitofWork
    {
        private readonly MockDataContext _context; 
        private readonly Dictionary<Type, object> _repositories;
        public MockUnitOfWork(MockDataContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public void BeginTransaction()
        {

        }

        public void Commit()
        {

        }

        public void Dispose()
        {

        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
            {
                return _repositories[typeof(TEntity)] as IRepository<TEntity>;
            }

            var entityName = typeof(TEntity).Name;
            var prop = _context.GetType().GetProperty(entityName);
            MockRepository<TEntity> repository;
            if (prop != null)
            {
                var entityValue = prop.GetValue(_context, null);
                repository = new MockRepository<TEntity>(entityValue as List<TEntity>);
            }
            else
            {
                repository = new MockRepository<TEntity>(new List<TEntity>());
            }
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public void Rollback()
        {

        }

        public int SaveChanges()
        {
            return 0;
        }
    }
}
