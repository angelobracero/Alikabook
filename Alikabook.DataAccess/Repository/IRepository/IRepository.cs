using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Alikabook.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        IQueryable<T> GetWithIncludes(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);

        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
