using AutoMapper;
using WFM_API.Models;

namespace WFM_API.Profiles
{
    public class EmpBreakProfile : Profile
    {
        public EmpBreakProfile()
        {
            CreateMap<EmpBreak, DTOS.EmpBreaksDto>();

        }
    }
}
