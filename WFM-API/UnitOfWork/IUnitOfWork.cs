using WFM_API.Models;
using WFM_API.Repositories;

namespace WFM_API.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Department> Departments { get; }  
    }
}
