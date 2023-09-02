using AutoMapper;
using Hr_management.MVC.Controllers;
using Hr_management.MVC.Models.LeaveType;
using Hr_management.MVC.Services.Base;

namespace Hr_management.MVC
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            #region LeaveRequest Mapping 
            CreateMap<CreateLeaveTypeDto, CreateLeaveTypeVM>().ReverseMap();
            CreateMap<LeaveTypeDto, LeaveTypeVM>().ReverseMap();
            
            #endregion
        }
    }
}
