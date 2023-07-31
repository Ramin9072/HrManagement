using System;

namespace HrManagement.Application.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string message):base(message) 
        {
            
        }
    }
}
