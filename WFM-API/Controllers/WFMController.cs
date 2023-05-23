using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WFM_API.DTOS;
using WFM_API.UnitOfWork;

namespace WFM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WFMController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public WFMController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetAllDepartmentsWithEmployees")]
        public async Task<IActionResult> GetAllDepartmentsWithEmployees()
        {
            var allDepWithEmploees = await _unitOfWork.Departments.FindWithIncludes(new[] { "Employees" });
            if (allDepWithEmploees == null) return BadRequest("Not Found");
            var results = _mapper.Map<IEnumerable<EmployeeWithDepartmentDto>>(allDepWithEmploees);

           // return Ok(allDepWithEmploees);
            return Ok(results);
        }

        [HttpGet("GetTypeOfDays")]
        public async Task<IActionResult> GetTypeOfDays()
        {
            var allTypes = await _unitOfWork.TypeOfDays.GetAll();
            if (allTypes == null) return BadRequest();

            return Ok(allTypes);
        }

    }
}
