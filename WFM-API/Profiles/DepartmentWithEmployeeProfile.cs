using AutoMapper;
using WFM_API.Models;
using WFM_API.Models.Identity;

namespace WFM_API.Profiles
{
    public class DepartmentWithEmployeeProfile : Profile
    {
        public DepartmentWithEmployeeProfile()
        {
            CreateMap<Department, DTOS.EmployeeWithDepartmentDto>()
            .ForMember(d => d.Id, a => a.MapFrom(s => s.Id));
        }
    }
}
