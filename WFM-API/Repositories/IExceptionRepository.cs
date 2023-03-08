using WFM_API.Models;

namespace WFM_API.Repositories
{
    public interface IExceptionRepository : IBaseRepository<EmpException>
    {
        Task<bool> isExceptionDuringDay(DateTime exceptionDate,string empPID, TimeSpan from, TimeSpan to);
        Task<int> getAppointmentId(string employeeId, DateTime excdate);

    }
}
