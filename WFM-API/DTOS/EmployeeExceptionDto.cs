using WFM_API.Models;

namespace WFM_API.DTOS
{
    public class EmployeeExceptionDto
    {

        public int Id { get; set; }
        public string? creatorPID { get; set; }
        public string? approvedByPID { get; set; }
        public EmployeeDto? User { get; set; }
        public EmployeeDto? Manager { get; set; }
        public DateTime exceptionDate { get; set; }
        public TimeSpan from { get; set; }
        public TimeSpan to { get; set; }
        public ExceptionStatus? ExceptionStatus { get; set; }
        public ExceptionType? ExceptionType { get; set; }

    }
}
