using WFM_API.Models;
using WFM_API.Repositories;

namespace WFM_API.Services
{
    public class ExceptionRepository: BaseRepository<EmpException>, IExceptionRepository
    {
        private readonly AppDbContext _context;
        public ExceptionRepository(AppDbContext context) :base(context) 
        {
            _context = context;
        }

        public async Task<bool> isExceptionDuringDay(DateTime exceptionDate, string empPID, TimeSpan from, TimeSpan to)
        {
            var dateOfException = _context.EmployeeAppointments.FirstOrDefault(e=>e.AppointMentDate.ToString() == exceptionDate.ToString() && e.EmployeePID == empPID);
            if (dateOfException == null) return false;

            var excFrom = TimeSpan.Compare(dateOfException.From, from);
            var excTo = TimeSpan.Compare(dateOfException.To, to);
            //return true if fromExc more than or equal from, and to is less than 
            return (excFrom > 0 || excFrom == 0) && (excTo < 0 || excTo == 0);
        }
    }
}
