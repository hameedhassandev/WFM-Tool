using System.ComponentModel.DataAnnotations;

namespace WFM_API.DTOS.CreateDtos
{
    public class EmpBreakDto
    {
        
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
    }
}
