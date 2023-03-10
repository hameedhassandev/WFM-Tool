using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WFM_API.DTOS;
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
        private readonly IMapper _mapper;


        public EmolyeeController(IUnitOfWork unitOfWork,IMapper mapper, UserManager<AppUser> userMnager)
        {
            _unitOfWork = unitOfWork;
            _userMnager = userMnager;
            _mapper = mapper;
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


        [HttpGet("GetAllTeamLeaders")]
        public async Task<IActionResult> GetAllTeamLeaders()
        {
            var usersWithPermission = await _userMnager.GetUsersInRoleAsync(Roles.TeamLeaderRole);
            var results = _mapper.Map<IEnumerable<EmployeeDto>>(usersWithPermission);

            return Ok(results);
        }
    }
}
