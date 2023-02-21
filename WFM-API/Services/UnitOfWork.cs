using WFM_API.Models;
using WFM_API.Repositories;
using WFM_API.UnitOfWork;

namespace WFM_API.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Departments = new BaseRepository<Department>(_context);
        }
        public IBaseRepository<Department> Departments { get; private set; }

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
