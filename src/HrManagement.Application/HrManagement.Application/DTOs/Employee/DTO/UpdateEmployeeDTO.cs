using HrManagement.Application.DTOs.Employee.DTO.AbstractionDto;

namespace HrManagement.Application.DTOs.Employee.DTO
{
    class UpdateEmployeeDTO : IUpdateEmployeeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
