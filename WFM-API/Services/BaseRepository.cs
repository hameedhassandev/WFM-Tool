using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WFM_API.Models;
using WFM_API.Repositories;

namespace WFM_API.Services
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context = context;    
        }

    
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

      
        public async Task<T> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }
        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<T> Find(Expression<Func<T, bool>> criteria)
        {
           return await _context.Set<T>().SingleOrDefaultAsync(criteria);
        }

        public async Task<IEnumerable<T>> FindAsQuery(Expression<Func<T, bool>> criteria,string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

        
            var result = await query.Where(criteria).ToListAsync();
            return result;
          
        }

        public async Task<T> FindAsSingleQuery(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);


            var result = await query.SingleOrDefaultAsync(criteria);
            return result;

        }


    }
}
