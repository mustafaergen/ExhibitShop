using ProductCatalog_Repositories.Contexts;
using ProductCatalog_Repositories.Contracts.Base;
using ProductCatolog_Core.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        protected readonly RepositoryContext _context;
        protected RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAllCondition(Expression<Func<T, bool>> condition)
        {
            return _context.Set<T>().Where(condition);
        }

        public T? FindByCondition(Expression<Func<T, bool>> condition)
        {
            return _context.Set<T>().Where(condition).SingleOrDefault();
        }

        public T? FindById(int id)
        {
            return _context.Set<T>().SingleOrDefault(x=>x.Id == id);
        }

        public IQueryable<T> FindAll()
        {
            return _context.Set<T>();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
