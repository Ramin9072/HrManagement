using HrManagement.Domain.Common;
using System;

namespace HrManagement.Domain
{
    public class LeaveRequest : BaseDomainEntity
    {

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveType LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime DateRequested { get; set; }
        public string Comment { get; set; }
        public DateTime DateActioned { get; set; }
        public bool? Approved { get; set; }
        public bool Canceled { get; set; }
    }
}
