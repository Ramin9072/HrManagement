
using AutoMapper;
using HrManagement.Application.DTOs.LeaveAllocation.DTO;
using HrManagement.Application.DTOs.LeaveRequest.DTO;
using HrManagement.Application.DTOs.LeaveType.DTO;
using HrManagement.Domain;

namespace HrManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //        Source         Destination   leave=> dto , dto => leave
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestList>().ReverseMap();
        }
    }
}
