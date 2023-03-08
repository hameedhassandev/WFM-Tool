using AutoMapper;
using WFM_API.Models;

namespace WFM_API.Profiles
{
    public class EmployeeAppointmentsProfile : Profile
    {
        public EmployeeAppointmentsProfile()
        {
            CreateMap<EmployeeAppointment, DTOS.EmployeeAppointmentDto>();
        }
        
    }
}
