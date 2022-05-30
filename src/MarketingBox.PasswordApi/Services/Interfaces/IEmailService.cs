using System.Threading.Tasks;

namespace MarketingBox.PasswordApi.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmail(string email, string token);
    }
}