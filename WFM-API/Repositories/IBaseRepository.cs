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
        Task<T> FindAsSingleQuery(Expression<Func<T, bool>> criteria, string[] includes = null);

        Task<IEnumerable<T>> FindAsQuery(Expression<Func<T, bool>> criteria, string[] includes = null);
        Task<IEnumerable<T>> FindAsQueryWithPaging(Expression<Func<T, bool>> criteria, string[] includes = null, int take=0, int skip=0);
        Task<IEnumerable<T>> FindWithIncludes(string[] includes);

    }
}
