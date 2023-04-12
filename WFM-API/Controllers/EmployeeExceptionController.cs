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

            var isExceptionExist = await _unitOfWork.Exceptions.isExceptionExist(dto.CreatorPID, empExc);
            if (isExceptionExist) return BadRequest($"This Exception is overlap with exceptionId = {empExc.Id}");

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
        public async Task<IActionResult> CancelException([FromForm] UpdateExceptionStatusDto dto)
        {
            var except = await _unitOfWork.Exceptions.GetById(dto.ExceptionId);

            if (except == null) return NotFound("No Exception Found!");

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

            except.ExceptionStatusId = (int)ExceptionStatusVal.CanceledByCreator;
            _unitOfWork.Exceptions.Update(except);
            _unitOfWork.Complete();
            return Ok(except);
        }

        [HttpGet("GetAllEmployeeExceptions")]
        public async Task<IActionResult> GetAllEmployeeExceptions()
        {
           

            var allEmpExceptions = await _unitOfWork.Exceptions.FindWithIncludes(new[] { "ExceptionStatus", "ExceptionComments", "ExceptionType", "Manager", "User" });

            var results = _mapper.Map<IEnumerable<EmployeeExceptionDto>>(allEmpExceptions);

            return Ok(results);
        }


        [HttpGet("GetAllEmpExceptoins")]
        public async Task<IActionResult> GetAllEmpExceptoins(string employeePID)
        {
            var employee = await _unitOfWork.Employees.Find(e => e.Id == employeePID);
            if (employee == null) return NotFound();

            var allExceptions  = await _unitOfWork.Exceptions.FindAsQuery(e=>e.CreatorPID == employeePID, new[] { "ExceptionStatus", "ExceptionComments", "ExceptionType", "Manager" }  );

            var results = _mapper.Map<IEnumerable<EmployeeExceptionDto>>(allExceptions);

            return Ok(results);
        }

        [HttpGet("GetAllEmpExceptoinsByDate")]
        public async Task<IActionResult> GetAllEmpExceptoinsByDate(string employeePID,DateTime date)
        {
            var employee = await _unitOfWork.Employees.Find(e => e.Id == employeePID);
            if (employee == null) return NotFound();

            var allExceptionsByDate = await _unitOfWork.Exceptions.FindAsQuery(e => e.ApprovedByPID == employeePID && e.ExceptionDate.CompareTo(date) == 0, new[] { "ExceptionStatus", "ExceptionComments", "ExceptionType","User" });

            var results = _mapper.Map<IEnumerable<EmployeeExceptionDto>>(allExceptionsByDate);

            return Ok(results);
        }

        [HttpGet("GetExceptonTypes")]
        public async Task<IActionResult> GetExceptonTypes()
        {
            var allTypes = await _unitOfWork.ExceptionTypes.GetAll();
            if (allTypes == null) return NotFound();
            return Ok(allTypes);
        }


        [HttpGet("GetExcepton")]
        public async Task<IActionResult> GetExcepton(int exceptionId,string empPID)
        {
            var exception = await _unitOfWork.Exceptions.FindAsSingleQuery(e => e.Id == exceptionId && e.CreatorPID == empPID, new[] { "ExceptionStatus", "ExceptionComments", "ExceptionType", "Manager" });

            if (exception == null) return NotFound();

           //var result = _mapper.Map<EmployeeExceptionDto>(exception);

            return Ok(exception);
        }

        [HttpGet("GetExceptonsForTL")]
        public async Task<IActionResult> GetExceptonsForTL(string teamLeaderId)
        {
            var allExceptionForTl = await _unitOfWork.Exceptions.FindAsQuery(c=>c.ApprovedByPID == teamLeaderId, new[] { "ExceptionStatus", "ExceptionType", "Manager" ,"User"});
            if (allExceptionForTl == null) return NotFound();

            var results = _mapper.Map<IEnumerable<EmployeeExceptionDto>>(allExceptionForTl);

            return Ok(results);
        }

    }
}
