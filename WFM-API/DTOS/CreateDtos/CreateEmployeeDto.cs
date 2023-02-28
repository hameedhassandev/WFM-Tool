using System.ComponentModel.DataAnnotations;

namespace WFM_API.DTOS.CreateDtos
{
    public class CreateEmployeeDto
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int DepartmentId { get; set; }

    }
}
