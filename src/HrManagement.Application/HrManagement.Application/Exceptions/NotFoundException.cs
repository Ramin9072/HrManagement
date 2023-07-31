using System;

namespace HrManagement.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key) : base($"{name} ({key}) wan not found")
        {

        }
    }
}
