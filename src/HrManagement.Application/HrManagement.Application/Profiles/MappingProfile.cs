
using AutoMapper;
using HrManagement.Application.DTOs.LeaveAllocation;
using HrManagement.Application.DTOs.LeaveRequest;
using HrManagement.Application.DTOs.LeaveType;
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
