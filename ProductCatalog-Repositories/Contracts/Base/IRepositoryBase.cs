using ProductCatolog_Core.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Repositories.Contracts.Base
{
    public interface IRepositoryBase<T> where T : BaseEntity
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindAllCondition(Expression<Func<T, bool>> condition);
        T? FindById(int id);
        T? FindByCondition(Expression<Func<T, bool>> condition);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
