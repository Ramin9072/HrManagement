using HrManagement.Domain.Common;

namespace HrManagement.Domain
{
    public sealed class LeaveType : BaseDomainEntity
    {
        public LeaveType(string name, int defaultDay, int id)
        {
            Name = name;
            DefaultDay = defaultDay;
            Id = id;
        }

        public string Name { get; private set; }
        public int DefaultDay { get; private set; }

        public class Builder
        {

            public string _name;
            public int _defaultDay;
            public int _id;

            public Builder Id(int id)
            {
                _id = id;
                return this;
            }

            public Builder Name(string name)
            {
                _name = name;
                return this;
            }

            public Builder DefaultDay(int defaultDay)
            {
                _defaultDay = defaultDay;
                return this;
            }

            public LeaveType Create()
            {
                return new LeaveType(_name, _defaultDay,_id);
            }
        }
    }
}
