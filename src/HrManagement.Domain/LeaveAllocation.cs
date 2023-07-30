using HrManagement.Domain.Common;

namespace HrManagement.Domain
{
    public sealed class LeaveAllocation : BaseDomainEntity
    {
        public LeaveAllocation(int numberOfDays, LeaveType leaveType, int leaveTypeId, int period)
        {
            NumberOfDays = numberOfDays;
            LeaveType = leaveType;
            LeaveTypeId = leaveTypeId;
            Period = period;
        }

        public int NumberOfDays { get; private set; }
        public LeaveType LeaveType { get; private set; }
        public int LeaveTypeId { get; private set; }
        public int Period { get; private set; }

        public class Builder
        {
            private int _numberOfDays;
            private LeaveType _leaveType;
            private int _leaveTypeId;
            private int _period;

            public Builder Period(int period)
            {
                _period = period;
                return this;
            }

            public Builder LeaveTypeId(int leaveTypeId)
            {
                _leaveTypeId = leaveTypeId;
                return this;
            }

            public Builder LeaveType(LeaveType leaveType)
            {
                _leaveType = leaveType;
                return this;
            }

            public Builder NumberOfDays(int numberOfDays)
            {
                _numberOfDays = numberOfDays;
                return this;
            }

            public LeaveAllocation Create()
            {
                return new LeaveAllocation(_numberOfDays, _leaveType, _leaveTypeId, _period);
            }
        }
    }
}
