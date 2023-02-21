using System.ComponentModel.DataAnnotations;

namespace WFM_API.Models
{
    public class ExceptionType
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? ExceptionName { get; set; }
    }
}
