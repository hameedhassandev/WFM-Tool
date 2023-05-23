using System.ComponentModel.DataAnnotations;

namespace WFM_API.DTOS.UpdateDtos
{
    public class UpdateExceptionStatusDto
    {
        [Required]
        public int ExceptionId { get; set; }

        public string? CreatorPID { get; set; }
        public string? CreatorName { get; set; }
        
        public string? Comment { get; set; }
    }
}
