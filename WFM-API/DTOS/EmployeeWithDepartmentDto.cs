namespace WFM_API.DTOS
{
    public class EmployeeWithDepartmentDto
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        public ICollection<EmployeeDto>? Employees { get; set; }
    }
}
