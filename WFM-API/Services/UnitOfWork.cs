using WFM_API.Models;
using WFM_API.Models.Identity;
using WFM_API.Repositories;
using WFM_API.UnitOfWork;

namespace WFM_API.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IBaseRepository<Department> Departments { get; private set; }
        public IExceptionRepository Exceptions { get; private set; }
        public IBaseRepository<AppUser> Employees { get; private set; }
        public IBaseRepository<EmployeeAppointment> EmployeeAppointments { get; private set; }
        public IBaseRepository<EmpBreak> EmployeeBreaks { get; private set; }




        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Departments = new BaseRepository<Department>(_context);
            Exceptions = new ExceptionRepository(_context);
            Employees = new BaseRepository<AppUser>(_context);
            EmployeeAppointments = new BaseRepository<EmployeeAppointment>(_context);
            EmployeeBreaks = new BaseRepository<EmpBreak>(_context);
        }

        public int Complete()
        {
           
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
