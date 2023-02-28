using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WFM_API.DTOS.CreateDtos;
using WFM_API.Models;
using WFM_API.UnitOfWork;

namespace WFM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAppointmentController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public EmployeeAppointmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("EmployeeAppointments")]
        public async Task<IActionResult> EmployeeAppointments(string EmployeePID)
        {
            var emp = await _unitOfWork.EmployeeAppointments.FindAsQuery(e=>e.EmployeePID == EmployeePID, new[] { "TypeOfDay", "Breaks" });
          /*  var employee = await _unitOfWork.EmployeeAppointments.GetById(EmployeePID);
            if(employee == null)   return NotFound();*/

            var appointments = await _unitOfWork.EmployeeAppointments.GetAll();
            return Ok(emp);
        }


        private async void addBreak(int appointmentId,TimeSpan from, TimeSpan to)
        {
            EmpBreak EpBreak = new() 
            {
                EmployeeAppointmentId = appointmentId,
                From = from,
                To = to
            };
           await _unitOfWork.EmployeeBreaks.Add(EpBreak);
            _unitOfWork.Complete();
        }

        [HttpPost("AddAppointment")]
        public async Task<IActionResult> AddAppointment([FromForm] CreateAppointmentDto dto)
        {
            
            EmployeeAppointment appointment = new() { 
                EmployeePID = dto.EmployeePID,
                TypeOfDayId = dto.TypeOfDayId,
                AppointMentDate = dto.AppointMentDate,
                From = dto.From,
                To = dto.To
                
            };

            var results = await _unitOfWork.EmployeeAppointments.Add(appointment);
            _unitOfWork.Complete();

            var AppointmentId = appointment.Id;
            if(dto.Breaks != null)
            {
                addBreak(AppointmentId, dto.Breaks.From, dto.Breaks.To);
            }



            return Ok(results);
        }
    }
}
