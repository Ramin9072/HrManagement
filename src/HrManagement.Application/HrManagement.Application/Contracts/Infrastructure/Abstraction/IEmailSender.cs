using HrManagement.Application.DTOs.Email;
using System.Threading.Tasks;

namespace HrManagement.Application.Contracts.Infrastructure.Abstraction
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(EmailDTO email);
    }
}
