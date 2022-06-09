using System.Threading.Tasks;

namespace MarketingBox.PasswordApi.Services.Interfaces
{
    public interface IPasswordResetService
    {
        Task ResetPasswordMessageAsync(string userId, string newPassword, string tenantId);
    }
}