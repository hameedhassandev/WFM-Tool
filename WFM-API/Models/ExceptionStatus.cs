using System.ComponentModel.DataAnnotations;

namespace WFM_API.Models
{
    public class ExceptionStatus
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Status { get; set; }

    }
}
