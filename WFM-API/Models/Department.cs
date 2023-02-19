using System.ComponentModel.DataAnnotations;

namespace WFM_API.Models
{
    public class Department
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
