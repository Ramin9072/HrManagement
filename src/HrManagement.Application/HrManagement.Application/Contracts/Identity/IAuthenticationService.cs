using HrManagement.Application.DTOs.Indentity;
using System.Threading.Tasks;

namespace HrManagement.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> Login(AuthenticationRequest request);
        Task<RegistrationResponse> RegistrationRequest(RegistrationRequest request);
    }
}
