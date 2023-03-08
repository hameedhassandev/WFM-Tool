using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using WFM_API.Models.Identity;

namespace WFM_API.Models
{
    public class ExceptionComment
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Comment { get; set; }


        [Required]
        public string? CreatorPID { get; set; }


        [Required]
        public int EmpExceptionId { get; set; }
        [JsonIgnore]
        public EmpException? Exception { get; set; }
    }
}
