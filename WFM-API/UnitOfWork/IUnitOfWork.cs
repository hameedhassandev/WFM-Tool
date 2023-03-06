using WFM_API.Models;
using WFM_API.Models.Identity;
using WFM_API.Repositories;

namespace WFM_API.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Department> Departments { get; }
        IBaseRepository<AppUser> Employees { get; }
        IEmployeeAppointment EmployeeAppointments { get; }

        IExceptionRepository Exceptions { get; }
        IBaseRepository<EmpBreak> EmployeeBreaks { get; }

        int Complete();
    }
}
