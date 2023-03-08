using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace WFM_API.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<T> Add(T entit);
        T Update(T entity);
        void Delete(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> Find(Expression<Func<T, bool>> criteria);
        Task<IEnumerable<T>> FindAsQuery(Expression<Func<T, bool>> criteria, string[] includes = null);

    }
}
