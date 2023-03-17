using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WFM_API.Models.Identity;
using System.Text.Json.Serialization;

namespace WFM_API.Models
{
    public class EmpException
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int ExceptionTypeId { get; set; }
        public ExceptionType? ExceptionType { get; set; }

        [Required]
        public string? CreatorPID { get; set; }

        [Required]
        public string? ApprovedByPID { get; set; }

        [ForeignKey("CreatorPID")]
        public AppUser? User { get; set; }

        [ForeignKey("ApprovedByPID")]
        public AppUser? Manager { get; set; }

        [Required]
        public DateTime ExceptionDate { get; set; }

        [Required]
        public TimeSpan From { get; set; }
        [Required]
        public TimeSpan To { get; set; }

        [Required]
        public int ExceptionStatusId { get; set; }
        public ExceptionStatus? ExceptionStatus { get; set; }

        public int EmployeeAppointmentId { get; set; }

        [JsonIgnore]
        public EmployeeAppointment? EmployeeAppointment { get; set; }

        public ICollection<ExceptionComment>? ExceptionComments { get; set; }


    }
}
