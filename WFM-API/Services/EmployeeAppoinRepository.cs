using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WFM_API.Models;
using WFM_API.Repositories;

namespace WFM_API.Services
{
    public class EmployeeAppoinRepository : BaseRepository<EmployeeAppointment>, IEmployeeAppointment
    {
        private readonly AppDbContext _context;
        public EmployeeAppoinRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> dateIsExist(string employeeId, DateTime workDate)
        {
            Expression<Func<EmployeeAppointment, bool>> expression = e=>e.EmployeePID == employeeId;

            var empAppointments = await _context.EmployeeAppointments.Where(expression).ToListAsync();
            if (empAppointments == null) return false;

            int result;
            foreach(var emp in empAppointments)
            {
                result = DateTime.Compare(emp.AppointMentDate, workDate);
                if (result == 0) return true;
            }
                
            return false;
        }
    }
}
