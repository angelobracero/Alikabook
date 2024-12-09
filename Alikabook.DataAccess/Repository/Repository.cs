using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Alikabook.DataAccess.Data;
using Alikabook.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Alikabook.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {
           dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return await query.FirstOrDefaultAsync();
        }


        public IQueryable<T> GetWithIncludes(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query.Where(filter);
        }


        public IQueryable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query;
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        {
            try
            {
                if (filter != null)
                {
                    return await dbSet.Where(filter).ToListAsync();
                }
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                // You can use a logging framework like Serilog, NLog, or built-in logging
                throw new Exception("An error occurred while retrieving data", ex);
            }
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
