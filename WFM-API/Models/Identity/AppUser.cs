using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WFM_API.Models.Identity
{
    public class AppUser : IdentityUser
    {
        
        [Required]
        public string FullName { get; set; }
        [Required] 
        public int DepartmentId { get; set; }
        [JsonIgnore]
        public Department Department { get; set; }
    }
}
