using System.Threading.Tasks;

namespace MarketingBox.PasswordApi.Services.Interfaces
{
    public interface IPasswordRecoveryService
    {
        Task RecoverPassword(string email);
    }
}