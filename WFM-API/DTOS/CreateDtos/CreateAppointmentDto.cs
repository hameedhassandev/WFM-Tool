using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WFM_API.Models.Identity;
using WFM_API.Models;

namespace WFM_API.DTOS.CreateDtos
{
    public class CreateAppointmentDto
    {
    
        [Required]
        public string EmployeePID { get; set; }


        [Required]
        public int TypeOfDayId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:MM/dd/yyyy}")]
        [Required]
        public DateTime AppointMentDate { get; set; }

        [Required]
        public TimeSpan From { get; set; }
        [Required]
        public TimeSpan To { get; set; }

      //public List<EmpBreakDto>? Breaks { get; set; }
      public EmpBreakDto? Breaks { get; set; }

    }
}
