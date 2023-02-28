using System.Linq.Expressions;

namespace WFM_API.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<T> GetById(string id);
        Task<T> Add(T entit);
        Task<IEnumerable<T>> GetAll();
        Task<T> Find(Expression<Func<T, bool>> criteria);
        Task<IEnumerable<T>> FindAsQuery(Expression<Func<T, bool>> criteria, string[] includes = null);

    }
}
