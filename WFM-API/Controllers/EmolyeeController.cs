using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WFM_API.DTOS;
using WFM_API.Helpers;
using WFM_API.Models.Identity;
using WFM_API.Repositories;

namespace WFM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmolyeeController : ControllerBase
    {
        private readonly UserManager<AppUser> _userMnager;
        private readonly IBaseRepository<AppUser> _userRepo;

        public EmolyeeController(UserManager<AppUser> userMnager, IBaseRepository<AppUser> userRepo)
        {
                _userMnager = userMnager;
                 _userRepo = userRepo;
        }
    
        [HttpPost]
        public async Task<IActionResult> AddEmployee ([FromForm] EmployeeDto dto)
        {
            var employee = new AppUser
            {
                UserName = dto.UserName,
                PhoneNumber = dto.PhoneNo,
                FullName = dto.FullName,
                DepartmentId = dto.DepartmentId,
            };
            var result = await _userMnager.CreateAsync(employee,dto.Password);
            if (!result.Succeeded)
            {
                var errors = string.Empty;
                foreach (var err in result.Errors) errors += $"{err.Description}, ";

                return BadRequest(errors);
            }
            //add role
             await _userMnager.AddToRoleAsync(employee, Roles.EmployeeRole);

            return Ok();   
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await _userRepo.FindAsQuery(n => n.DepartmentId == 2, new[] { "Department" });
            return Ok(employees);
        }
    }
}
