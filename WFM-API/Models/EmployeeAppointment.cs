using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WFM_API.Models.Identity;


namespace WFM_API.Models
{
    public class EmployeeAppointment
    {
        [Required]
        public int Id { get; set; }


        [Required]
        public string? EmployeePID { get; set; }

        [ForeignKey("EmployeePID")]

        public AppUser? User { get; set; }

        [Required]
        public int TypeOfDayId { get; set; }

        [Required]
        public DateTime AppointMentDate { get; set; }

        [Required]
        public TimeSpan From { get; set; }
        [Required]
        public TimeSpan To { get; set; }
        public TypeOfDay? TypeOfDay { get; set; }

        public ICollection<EmpBreak>? Breaks { get; set; }
        public ICollection<EmpException>? Exceptions { get; set; }




    }
}
