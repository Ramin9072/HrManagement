using HrManagement.Application.DTOs.Indentity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HrManagement.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> Login(AuthenticationRequest request);
        Task<RegistrationResponse> RegistrationRequest(RegistrationRequest request);
    }
}
