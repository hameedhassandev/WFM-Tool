using System.ComponentModel.DataAnnotations;

namespace WFM_API.DTOS.UpdateDtos
{
    public class UpdateExceptionStatusDto
    {
        [Required]
        public int ExceptionId { get; set; }

        [Required]
        public string? CreatorPID { get; set; }
        public string? Comment { get; set; }
    }
}
