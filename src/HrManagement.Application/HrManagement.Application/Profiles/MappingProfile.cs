
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
            //        Source       Destination   leave=> dto , dto => leave
            #region LeaveRequest Mapping 
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestList>().ReverseMap();
            CreateMap<LeaveRequest, CreateLeaveRequestDTO>().ReverseMap();
            CreateMap<LeaveRequest, UpdateLeaveRequestDto>().ReverseMap();
            #endregion

            #region LeaveAllocation Mapping
            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation, CreateLeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation, UpdateLeaveAllocationDto>().ReverseMap();

            #endregion

            #region LeaveType Mapping
            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveTypeDto>().ReverseMap();
            CreateMap<LeaveType, UpdateLeaveRequestDto>().ReverseMap();
            #endregion
        }
    }
}
