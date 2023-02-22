using WFM_API.Models;
using WFM_API.Repositories;

namespace WFM_API.Services
{
    public class ExceptionRepository: BaseRepository<EmpException>, IExceptionRepository
    {
        private readonly AppDbContext _context;
        public ExceptionRepository(AppDbContext context) :base(context) 
        {

        } 
        public IEnumerable<EmpException> GetAllException()
        {
            throw new NotImplementedException();    
        }
    }
}
