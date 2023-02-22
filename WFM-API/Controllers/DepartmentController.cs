using Microsoft.AspNetCore.Mvc;
using WFM_API.Models;
using WFM_API.Repositories;
using WFM_API.UnitOfWork;

namespace WFM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        //private readonly IBaseRepository<Department> _departmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<DepartmentController>
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.Departments.GetAll());
        }

        // GET api/<DepartmentController>/GetByName
        
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName()
        {
            // return Ok(await _departmentRepository.FindAsQuery(n=>n.Name == "Data Entry" ));
            return Ok(await _unitOfWork.Departments.FindAsQuery(n => n.Name == "Data Entry"));
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            //return Ok(await _departmentRepository.GetById(id));
            return Ok(await _unitOfWork.Departments.GetById(id));
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        [HttpPost("AddException")]
        public async Task<IActionResult> AddException()
        {
            var exception = new EmpException
            {
                ExceptionTypeId = 2,
                CreatorPID = "c445dd9d-78a1-4dd7-9813-cb004f57b969",
                ApprovedByPID = "6633098b-1435-4e81-b44a-f42243c9f8c7",
                From = new TimeSpan(12, 0, 0),
                To = new TimeSpan(15, 0, 0),
                ExceptionStatusId = 4
            };
            await _unitOfWork.Exceptions.Add(exception);
            _unitOfWork.Complete();
            return Ok(exception);
        }

    }
}
