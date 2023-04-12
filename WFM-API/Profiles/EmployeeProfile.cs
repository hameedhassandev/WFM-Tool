using AutoMapper;
using WFM_API.Models.Identity;

namespace WFM_API.Profiles
{
    public class EmployeeProfile: Profile
    {
        public EmployeeProfile()
        {
            CreateMap<AppUser, DTOS.EmployeeDto>()
            .ForMember(d => d.EmployeePid, a => a.MapFrom(s => s.Id))
            .ForMember(d=>d.DepartmentName, e=>e.MapFrom(d=>d.Department.Name));
        }
    }
}
