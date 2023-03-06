using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WFM_API.UnitOfWork;

namespace WFM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeExceptionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeExceptionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("textEx")]
        public async Task<IActionResult> textEx(TimeSpan from, TimeSpan to)
        {
            string empId ="6403e590-a212-4b2a-9ada-b8f03b90b25f";
            DateTime dateOfExc = new DateTime(2023, 3, 6,0,0,0);
            var exc = await _unitOfWork.Exceptions.isExceptionDuringDay(dateOfExc, empId,from,to);
            if (!exc) return BadRequest();
            return Ok();
        }
    }
}
