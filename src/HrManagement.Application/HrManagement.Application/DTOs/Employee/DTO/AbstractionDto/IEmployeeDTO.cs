namespace HrManagement.Application.DTOs.Employee.DTO.AbstractionDto
{
    public interface IEmployeeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
