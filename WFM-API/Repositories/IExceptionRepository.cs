using WFM_API.Models;

namespace WFM_API.Repositories
{
    public interface IExceptionRepository : IBaseRepository<EmpException>
    {
        IEnumerable<EmpException> GetAllException();
    }
}
