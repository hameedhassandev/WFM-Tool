using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;
using WFM_API.Models;
using WFM_API.Models.Identity;

namespace WFM_API.DTOS
{
    public class EmployeeDto
    {
        public string? EmployeePid { get; set; }
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }


        //  public RoleManager<AppUser> Roles { get; set; }
    }
}
