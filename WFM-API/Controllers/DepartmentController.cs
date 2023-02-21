using Microsoft.AspNetCore.Mvc;
using WFM_API.Models;
using WFM_API.Repositories;

namespace WFM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IBaseRepository<Department> _departmentRepository;

        public DepartmentController(IBaseRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        // GET: api/<DepartmentController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _departmentRepository.GetAll());
        }

        // GET api/<DepartmentController>/GetByName
        
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName()
        {
            return Ok(await _departmentRepository.FindAsQuery(n=>n.Name == "Data Entry" ));
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _departmentRepository.GetById(id));
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
    }
}
