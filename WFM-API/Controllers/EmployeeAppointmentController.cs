﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WFM_API.DTOS;
using WFM_API.DTOS.CreateDtos;
using WFM_API.Helpers;
using WFM_API.Models;
using WFM_API.UnitOfWork;

namespace WFM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAppointmentController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public EmployeeAppointmentController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("EmployeeAppointments")]
        public async Task<IActionResult> EmployeeAppointments(string EmployeePID)
        {
            var emp = await _unitOfWork.EmployeeAppointments.FindAsQuery(e=>e.EmployeePID == EmployeePID , new[] { "TypeOfDay", "Breaks", "Exceptions" });

            if(emp == null) return NotFound();

            emp = emp.OrderBy(e => e.AppointMentDate);
            

            var results = _mapper.Map<IEnumerable<EmployeeAppointmentDto>>(emp);

           return Ok(results);
           //return Ok(emp);
        }

        [HttpGet("EmployeeAppointmentDetails")]
        public async Task<IActionResult> EmployeeAppointmentDetails(string EmployeePID, int appointmentId)
        {
            var appointment = await _unitOfWork.EmployeeAppointments.FindAsSingleQuery(e => e.EmployeePID == EmployeePID && e.Id == appointmentId, new[] { "TypeOfDay", "Breaks", "Exceptions" });

            if (appointment == null) return NotFound();


            var results = _mapper.Map<EmployeeAppointmentDto>(appointment);

            return Ok(results);
        }

        [HttpGet("EmployeeAppointmentsPaging")]
        public async Task<IActionResult> EmployeeAppointmentsPaging(string EmployeePID,int take,int skip)
        {
            var emp = await _unitOfWork.EmployeeAppointments.FindAsQueryWithPaging(e => e.EmployeePID == EmployeePID, new[] { "TypeOfDay", "Breaks", "Exceptions" }, take,skip);

            if (emp == null) return NotFound();

            emp = emp.OrderBy(e => e.AppointMentDate);

            var results = _mapper.Map<IEnumerable<EmployeeAppointmentDto>>(emp);

            return Ok(results);
            //return Ok(emp);
        }


        [HttpPost("AddAppointment")]
        public async Task<IActionResult> AddAppointment([FromForm] CreateAppointmentDto dto)
        {
            var dateIsExist = await _unitOfWork.EmployeeAppointments.dateIsExist(dto.EmployeePID, dto.AppointMentDate);
            if (dateIsExist) return BadRequest($"Date {dto.AppointMentDate} is alerdy exist");

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
                foreach(var b in dto.Breaks)
                {
                    EmpBreak EpBreak = new()
                    {
                        EmployeeAppointmentId = AppointmentId,
                        From = b.From,
                        To = b.To
                    };
                    await _unitOfWork.EmployeeBreaks.Add(EpBreak);
                    _unitOfWork.Complete();
                }
               
               
            }

            return Ok(results);
        }


    }
}
