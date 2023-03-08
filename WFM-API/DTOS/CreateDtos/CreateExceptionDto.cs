using System.ComponentModel.DataAnnotations;

namespace WFM_API.DTOS.CreateDtos
{
    public class CreateExceptionDto
    {
        [Required]
        public int ExceptionTypeId { get; set; }

        [Required]
        public string? CreatorPID { get; set; }

        [Required]
        public string? ApprovedByPID { get; set; }

        [Required]
        public DateTime ExceptionDate { get; set; }

        [Required]
        public TimeSpan From { get; set; }
        [Required]
        public TimeSpan To { get; set; }

        public string? ExceptionComment { get; set; }

    }
}
