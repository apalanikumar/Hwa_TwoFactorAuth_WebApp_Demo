using System.Threading.Tasks;

namespace TwoFactorAuthWebApp.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
