using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WFM_API.DTOS;
using WFM_API.DTOS.CreateDtos;
using WFM_API.Helpers;
using WFM_API.Models;
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
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;


        public EmolyeeController(IUnitOfWork unitOfWork,IMapper mapper, 
            UserManager<AppUser> userMnager, RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _userMnager = userMnager;
            _roleManager = roleManager;
            _mapper = mapper;
        }
     
    
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
             await _userMnager.AddToRoleAsync(employee, dto.RoleName);

            return Ok();   
        }


        [HttpGet("GetAllTeamLeaders")]
        public async Task<IActionResult> GetAllTeamLeaders()
        {
            var usersWithPermission = await _userMnager.GetUsersInRoleAsync(Roles.TeamLeaderRole);
            var results = _mapper.Map<IEnumerable<EmployeeDto>>(usersWithPermission);

            return Ok(results);
        }

        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            if(!roles.Any()) NotFound();

            return Ok(roles);
        }

        [HttpGet("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(string employeeId)
        {
            var employee = await _userMnager.Users.Include(d => d.Department)
               .Select(user => new
               {
                   EmployeePid = user.Id,
                   FullName = user.FullName,
                   UserName = user.UserName,
                   DepartmentName = user.Department.Name,
                   Roles = _userMnager.GetRolesAsync(user).Result,
               }).FirstOrDefaultAsync(u=>u.EmployeePid == employeeId);
           // var results = _mapper.Map<EmployeeDto>(employee);
            return Ok(employee);
        }
    }
}
