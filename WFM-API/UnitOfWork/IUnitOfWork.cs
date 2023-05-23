using WFM_API.Models;
using WFM_API.Models.Identity;
using WFM_API.Repositories;

namespace WFM_API.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Department> Departments { get; }
        IBaseRepository<ExceptionComment> ExceptionComments { get; }
        IBaseRepository<AppUser> Employees { get; }
        IEmployeeAppointment EmployeeAppointments { get; }

        IExceptionRepository Exceptions { get; }
        IBaseRepository<EmpBreak> EmployeeBreaks { get; }
        IBaseRepository<ExceptionType> ExceptionTypes { get; }
        IBaseRepository<ExceptionStatus> ExceptionStatus { get; }
        IBaseRepository<TypeOfDay> TypeOfDays { get; }

 
        int Complete();
    }
}
