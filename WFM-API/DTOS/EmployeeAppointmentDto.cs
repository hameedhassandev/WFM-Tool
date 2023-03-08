using WFM_API.Models;

namespace WFM_API.DTOS
{
    public class EmployeeAppointmentDto
    {
        public int Id { get; set; }
        public string? employeePID { get; set; }
        public TypeOfDay? typeOfDay { get; set; }
        public DateTime appointMentDate { get; set; }
        public TimeSpan from { get; set; }
        public TimeSpan to { get; set; }
        //public EmpBreaksDto? Breaks { get; set; }
       // public ICollection<EmpBreaksDto>? Breaks { get; set; }
        public ICollection<EmpBreaksDto>? Breaks { get; set; }
        public ICollection<EmpException>? Exceptions { get; set; }

        // public ICollection<EmployeeExceptionDto>? exceptions { get; set; }
    }
}
