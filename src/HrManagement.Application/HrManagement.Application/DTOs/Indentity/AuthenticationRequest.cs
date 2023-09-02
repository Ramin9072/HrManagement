using System.Globalization;

namespace HrManagement.Application.DTOs.Indentity
{
    public class AuthenticationRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
