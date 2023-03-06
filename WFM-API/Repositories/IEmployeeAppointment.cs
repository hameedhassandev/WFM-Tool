using WFM_API.Models;

namespace WFM_API.Repositories
{
    public interface IEmployeeAppointment : IBaseRepository<EmployeeAppointment>
    {
        Task<bool> dateIsExist(string employeeId, DateTime workDate);
    }
}
