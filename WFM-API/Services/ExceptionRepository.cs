using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Xml.Linq;
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
            var EmpApp = await _context.EmployeeAppointments.FirstOrDefaultAsync(e => e.EmployeePID == empPID && e.AppointMentDate.CompareTo(exceptionDate) == 0);
            if (EmpApp == null) return false;

            var excFrom = TimeSpan.Compare(EmpApp.From, from);
            var excTo = TimeSpan.Compare(EmpApp.To, to);
            //return true if fromExc more than or equal from, and to is less than 
            return (excFrom < 0 || excFrom == 0) && (excTo > 0 || excTo == 0);
       
        }

        public async Task<int> getAppointmentId(string employeeId, DateTime excdate)
        {
            var EmpApp = await _context.EmployeeAppointments.FirstOrDefaultAsync(e => e.EmployeePID == employeeId && e.AppointMentDate.CompareTo(excdate) == 0);
            if (EmpApp == null) return -1;

            return EmpApp.Id;
         }

        public async Task<bool> isExceptionExist(string employeeId, EmpException exceptionObj)
        {
            if (exceptionObj == null) return false;
            var allEmpxceptions = await _context.Exceptions.Where(e=>e.CreatorPID == employeeId).ToListAsync();
            if (allEmpxceptions == null) return false;
            foreach(var exc in allEmpxceptions)
            {
                if(object.Equals(exc, exceptionObj)) return true;
            }
            return false;
        }

      


    }
}
