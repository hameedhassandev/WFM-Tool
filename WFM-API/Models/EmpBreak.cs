using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace WFM_API.Models
{
    public class EmpBreak
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int EmployeeAppointmentId { get; set; }
        [JsonIgnore]
        public EmployeeAppointment? EmployeeAppointment { get; set; }

        [Required]
        public TimeSpan From { get; set; }
        [Required]
        public TimeSpan To { get; set; }
    }
}
