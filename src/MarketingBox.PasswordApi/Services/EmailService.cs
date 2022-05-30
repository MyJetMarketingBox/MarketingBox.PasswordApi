using System.Threading.Tasks;
using MarketingBox.PasswordApi.Domain.Models;
using MarketingBox.PasswordApi.Services.Interfaces;
using MyJetWallet.Sdk.ServiceBus;

namespace MarketingBox.PasswordApi.Services
{
    public class EmailService : IEmailService
    {
        private readonly IServiceBusPublisher<PasswordRecoveryEmailMessage> _publisherPasswordRecovery;

        public EmailService(IServiceBusPublisher<PasswordRecoveryEmailMessage> publisherPasswordRecovery)
        {
            _publisherPasswordRecovery = publisherPasswordRecovery;
        }

        private static string GetUrl(string token) => $"{Program.Settings.RecoverPasswordPageUrl}/api/passwordrecovery/{token}";

        public async Task SendEmail(string email, string token)
        {
            await _publisherPasswordRecovery.PublishAsync(new PasswordRecoveryEmailMessage
            {
                Email = email,
                Url = GetUrl(token)
            });
        }
    }
}