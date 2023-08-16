using AutoMapper;
using Hr_management.MVC.Controllers;
using Hr_management.MVC.Models;

namespace Hr_management.MVC
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            #region LeaveRequest Mapping 
            CreateMap<CreateLeaveTypeDto, CreateLeaveTypeVM>().ReverseMap();
            
            #endregion
        }
    }
}
