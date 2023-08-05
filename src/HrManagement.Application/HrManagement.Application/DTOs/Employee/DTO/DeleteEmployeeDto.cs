using HrManagement.Application.DTOs.Employee.DTO.AbstractionDto;

namespace HrManagement.Application.DTOs.Employee.DTO
{
    public class DeleteEmployeeDto : IDeleteEmployeeDTO
    {
        public int Id { get; set; }
    }
}
