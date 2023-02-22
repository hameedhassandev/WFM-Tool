using WFM_API.Models;
using WFM_API.Repositories;
using WFM_API.UnitOfWork;

namespace WFM_API.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IBaseRepository<Department> Departments { get; private set; }
        public IExceptionRepository Exceptions { get; private set; }


        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Departments = new BaseRepository<Department>(_context);
            Exceptions = new ExceptionRepository(_context);
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
