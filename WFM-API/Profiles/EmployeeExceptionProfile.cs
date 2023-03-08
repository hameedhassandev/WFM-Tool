using AutoMapper;
using WFM_API.DTOS;
using WFM_API.Models;

namespace WFM_API.Profiles
{
    public class EmployeeExceptionProfile : Profile
    {
        public EmployeeExceptionProfile()
        {
            CreateMap<EmpException, EmployeeExceptionDto>();
        }
    }
}
