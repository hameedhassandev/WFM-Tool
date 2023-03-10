using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WFM_API.DTOS;
using WFM_API.DTOS.CreateDtos;
using WFM_API.DTOS.UpdateDtos;
using WFM_API.Helpers;
using WFM_API.Models;
using WFM_API.UnitOfWork;

namespace WFM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeExceptionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeExceptionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;   
        }

        [HttpPost("CreateException")]
        public async Task<IActionResult> CreateException([FromForm]CreateExceptionDto dto)
        {

            var appointmentId = await _unitOfWork.Exceptions.getAppointmentId(dto.CreatorPID, dto.ExceptionDate);
            if (appointmentId is -1) return BadRequest("Invalid Appointment");
                var excIsValid = await _unitOfWork.Exceptions.isExceptionDuringDay(dto.ExceptionDate, dto.CreatorPID, dto.From, dto.To);
            if (!excIsValid) return BadRequest("Invalid Exception Time");


            EmpException empExc = new()
            {
                EmployeeAppointmentId = appointmentId,
                ExceptionTypeId = dto.ExceptionTypeId,
                CreatorPID = dto.CreatorPID,
                ApprovedByPID = dto.ApprovedByPID,
                From = dto.From,
                To = dto.To,
                ExceptionDate = dto.ExceptionDate,
                ExceptionStatusId = (int)ExceptionStatusVal.Pending,
            };

            var result = await _unitOfWork.Exceptions.Add(empExc);
            _unitOfWork.Complete();


            var exceptionId = empExc.Id;


            if (!String.IsNullOrEmpty(dto.ExceptionComment))
            {
                ExceptionComment excComment = new() 
                {
                    Comment = dto.ExceptionComment,
                    CreatorPID = dto.CreatorPID,
                    EmpExceptionId = exceptionId,
                };
                await _unitOfWork.ExceptionComments.Add(excComment);
                _unitOfWork.Complete();
            }

            return Ok(result);
        }

        [HttpPut("ApproveExceptionByTeamLeader")]
        public async Task<IActionResult> ApproveExceptionByTeamLeader([FromForm] int ExceptionId)
        {
            var except = await _unitOfWork.Exceptions.GetById(ExceptionId);

            if (except == null) return NotFound();

            except.ExceptionStatusId = (int)ExceptionStatusVal.WaitingForWfm;
            _unitOfWork.Exceptions.Update(except);
            _unitOfWork.Complete();
            return Ok(except);  
        }

        [HttpPut("ApproveExceptionByWFM")]
        public async Task<IActionResult> ApproveExceptionByWFM([FromForm] int ExceptionId)
        {
            var except = await _unitOfWork.Exceptions.GetById(ExceptionId);

            if (except == null) return NotFound();

            except.ExceptionStatusId = (int)ExceptionStatusVal.Approved;
            _unitOfWork.Exceptions.Update(except);
            _unitOfWork.Complete();
            return Ok(except);
        }

        [HttpPut("RejectException")]
        public async Task<IActionResult> RejectException([FromForm]UpdateExceptionStatusDto dto)
        {
            var except = await _unitOfWork.Exceptions.GetById(dto.ExceptionId);

            if (except == null) return NotFound();

            if (!String.IsNullOrEmpty(dto.Comment))
            {
                ExceptionComment excComment = new()
                {
                    Comment = dto.Comment,
                    CreatorPID = dto.CreatorPID,
                    EmpExceptionId = dto.ExceptionId,
                };
                await _unitOfWork.ExceptionComments.Add(excComment);
                _unitOfWork.Complete();
            }

            except.ExceptionStatusId = (int)ExceptionStatusVal.Rejected;
            _unitOfWork.Exceptions.Update(except);
            _unitOfWork.Complete();
            return Ok(except);
        }

        [HttpPut("DisputeException")]
        public async Task<IActionResult> DisputeException([FromForm] UpdateExceptionStatusDto dto)
        {
            var except = await _unitOfWork.Exceptions.GetById(dto.ExceptionId);

            if (except == null) return NotFound();

            if (except.ExceptionStatusId == (int)ExceptionStatusVal.Approved)
                return BadRequest("Cannot Dispute Approved Exception");

            if (except.ExceptionStatusId == (int)ExceptionStatusVal.CanceledByCreator)
                return BadRequest("Cannot Dispute Exception that canceled by you");

            if (!String.IsNullOrEmpty(dto.Comment))
            {
                ExceptionComment excComment = new()
                {
                    Comment = dto.Comment,
                    CreatorPID = dto.CreatorPID,
                    EmpExceptionId = dto.ExceptionId,
                };
                await _unitOfWork.ExceptionComments.Add(excComment);
                _unitOfWork.Complete();
            }

            except.ExceptionStatusId = (int)ExceptionStatusVal.Dispute;
            _unitOfWork.Exceptions.Update(except);
            _unitOfWork.Complete();
            return Ok(except);
        }



        [HttpPut("CancelException")]
        public async Task<IActionResult> CancelException([FromForm] int ExceptionId)
        {
            var except = await _unitOfWork.Exceptions.GetById(ExceptionId);

            if (except == null) return NotFound();

            except.ExceptionStatusId = (int)ExceptionStatusVal.CanceledByCreator;
            _unitOfWork.Exceptions.Update(except);
            _unitOfWork.Complete();
            return Ok(except);
        }

        [HttpGet("GetAllEmpExceptoins")]
        public async Task<IActionResult> GetAllEmpExceptoins(string employeePID)
        {
            var employee = await _unitOfWork.Employees.Find(e => e.Id == employeePID);
            if (employee == null) return NotFound();

            var allExceptions  = await _unitOfWork.Exceptions.FindAsQuery(e=>e.CreatorPID == employeePID, new[] { "ExceptionStatus", "ExceptionComments", "ExceptionType" }  );

            var results = _mapper.Map<IEnumerable<EmployeeExceptionDto>>(allExceptions);

            return Ok(results);
        }

        [HttpGet("GetExceptonTypes")]
        public async Task<IActionResult> GetExceptonTypes()
        {
            var allTypes = await _unitOfWork.ExceptionTypes.GetAll();
            if (allTypes == null) return NotFound();
            return Ok(allTypes);
        }

    }
}
