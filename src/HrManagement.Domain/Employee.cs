using HrManagement.Domain.Common;

namespace HrManagement.Domain
{
    public sealed class Employee : BaseDomainEntity
    {
        public Employee(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public class Builder
        {
            private int _id;
            private string _firstName;
            private string _lastName;

            public Builder LastName(string lastName)
            {
                _lastName = lastName;
                return this;
            }

            public Builder Id(int id)
            {
                _id = id;
                return this;
            }

            public Builder FirstName(string firstName)
            {
                _firstName = firstName;
                return this;
            }
            public Employee Create()
            {
                return new Employee(_id, _firstName, _lastName);
            }
        }
    }
}
