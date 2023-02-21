using System.ComponentModel.DataAnnotations;

namespace WFM_API.Models
{
    public class Break
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int EmployeeAppointmentId { get; set; }
        public EmployeeAppointment? EmployeeAppointment { get; set; }

        [Required]
        public TimeSpan From { get; set; }
        [Required]
        public TimeSpan To { get; set; }
    }
}
