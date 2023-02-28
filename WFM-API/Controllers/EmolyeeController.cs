using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WFM_API.DTOS.CreateDtos;
using WFM_API.Helpers;
using WFM_API.Models.Identity;
using WFM_API.Repositories;
using WFM_API.UnitOfWork;

namespace WFM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmolyeeController : ControllerBase
    {
        private readonly UserManager<AppUser> _userMnager;
        //private readonly IBaseRepository<AppUser> _userRepo;

        private readonly IUnitOfWork _unitOfWork;

        public EmolyeeController(IUnitOfWork unitOfWork, UserManager<AppUser> userMnager)
        {
            _unitOfWork = unitOfWork;
            _userMnager = userMnager;
        }
       /* public EmolyeeController(UserManager<AppUser> userMnager, IBaseRepository<AppUser> userRepo)
        {
                _userMnager = userMnager;
                 _userRepo = userRepo;
        }*/
    
        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee ([FromForm] CreateEmployeeDto dto)
        {
            var emp = await _userMnager.FindByNameAsync(dto.UserName);
            if (emp != null) return BadRequest($"Username {dto.UserName} is exist!");

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
            var employees = await _unitOfWork.Employees.FindAsQuery(n => n.DepartmentId == 2, new[] { "Department" });
            return Ok(employees);
        }
    }
}
