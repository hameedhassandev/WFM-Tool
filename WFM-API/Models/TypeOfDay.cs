using System.ComponentModel.DataAnnotations;

namespace WFM_API.Models
{
    public class TypeOfDay
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string TypeName { get; set; }
    }
}
