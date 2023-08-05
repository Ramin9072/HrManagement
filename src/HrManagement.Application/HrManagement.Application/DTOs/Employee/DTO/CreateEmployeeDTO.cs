using HrManagement.Application.DTOs.Employee.DTO.AbstractionDto;

namespace HrManagement.Application.DTOs.Employee.DTO
{
    public class CreateEmployeeDto : ICreateEmployeeDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class UpdateEmployeeDto : IUpdateEmployeeDTO
    {

    }

    public class DeleteEmployeeDto : IDeleteEmployeeDTO
    {
        public int Id { get; set; }
    }
}
