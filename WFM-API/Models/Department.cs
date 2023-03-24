using System.ComponentModel.DataAnnotations;
using System.Numerics;
using WFM_API.Models.Identity;

namespace WFM_API.Models
{
    public class Department
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<AppUser>? Employees { get; set; }

    }
}
