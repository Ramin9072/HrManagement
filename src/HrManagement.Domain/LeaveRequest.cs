using HrManagement.Domain.Common;
using System;

namespace HrManagement.Domain
{
    public sealed class LeaveRequest : BaseDomainEntity
    {
        protected LeaveRequest()
        {
                
        }
        public LeaveRequest(DateTime startDate, DateTime endDate, LeaveType leaveType,
            int leaveTypeId, DateTime dateRequested,
            string comment, DateTime? dateActioned, bool? approved, bool canceled)
        {
            StartDate = startDate;
            EndDate = endDate;
            LeaveType = leaveType;
            LeaveTypeId = leaveTypeId;
            DateRequested = dateRequested;
            Comment = comment;
            DateActioned = dateActioned;
            Approved = approved;
            Canceled = canceled;
        }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public LeaveType LeaveType { get; private set; }
        public int LeaveTypeId { get; private set; }
        public DateTime DateRequested { get; private set; }
        public string Comment { get; private set; }
        public DateTime? DateActioned { get; private set; }
        public bool? Approved { get; private set; }
        public bool Canceled { get; private set; }

        public class Builder
        {
            private DateTime _startDate;
            private DateTime _endDate;
            private LeaveType _leaveType;
            private int _leaveTypeId;
            private DateTime _dateRequested;
            private string _comment;
            private DateTime? _dateActioned;
            private bool? _approved;
            private bool _canceled;

            public Builder DateRequested(DateTime dateRequested)
            {
                _dateRequested = dateRequested;
                return this;
            }

            public Builder EndDate(DateTime endDate)
            {
                _endDate = endDate;
                return this;
            }

            public Builder LeaveType(LeaveType leaveType)
            {
                _leaveType = leaveType;
                return this;
            }

            public Builder LeaveTypeId(int leaveTypeId)
            {
                _leaveTypeId = leaveTypeId;
                return this;
            }

            public Builder Comment(string comment)
            {
                _comment = comment;
                return this;

            }

            public Builder DateActioned(DateTime? dateActioned)
            {
                _dateActioned = dateActioned;
                return this;
            }

            public Builder Approved(bool? approved)
            {
                _approved = approved;
                return this;
            }

            public Builder Canceled(bool canceled)
            {
                _canceled = canceled;
                return this;
            }

            public Builder StartDate(DateTime startDate)
            {
                _startDate = startDate;
                return this;
            }

            public LeaveRequest Create()
            {
                return new LeaveRequest(_startDate, _endDate, _leaveType, _leaveTypeId, _dateRequested, _comment, _dateActioned, _approved, _canceled);
            }
        }
    }
}
