using System.Threading.Tasks;
using MarketingBox.PasswordApi.Domain.Models;
using MarketingBox.PasswordApi.Services.Interfaces;
using MyJetWallet.Sdk.ServiceBus;

namespace MarketingBox.PasswordApi.Services
{
    public class PasswordResetService : IPasswordResetService
    {
        private readonly IServiceBusPublisher<PasswordResetMessage> _publisherPasswordReset;

        public PasswordResetService(IServiceBusPublisher<PasswordResetMessage> publisherPasswordReset)
        {
            _publisherPasswordReset = publisherPasswordReset;
        }

        public async Task ResetPasswordMessageAsync(string userId, string newPassword, string token)
        {
            await _publisherPasswordReset.PublishAsync(new PasswordResetMessage
            {
                UserId = userId,
                NewPassword = newPassword,
                Token = token,
            });
        }
    }
}