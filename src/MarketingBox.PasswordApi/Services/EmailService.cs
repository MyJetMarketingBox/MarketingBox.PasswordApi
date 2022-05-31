using System;
using System.Threading.Tasks;
using MarketingBox.PasswordApi.Domain.Models;
using MarketingBox.PasswordApi.Services.Interfaces;
using Microsoft.Extensions.Logging;
using MyJetWallet.Sdk.ServiceBus;

namespace MarketingBox.PasswordApi.Services
{
    public class EmailService : IEmailService
    {
        private readonly IServiceBusPublisher<PasswordRecoveryEmailMessage> _publisherPasswordRecovery;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IServiceBusPublisher<PasswordRecoveryEmailMessage> publisherPasswordRecovery, ILogger<EmailService> logger)
        {
            _publisherPasswordRecovery = publisherPasswordRecovery;
            _logger = logger;
        }

        private static string GetUrl(string token) =>
            $"{Program.Settings.PasswordApiUrl}/api/passwordrecovery/{token}";

        public async Task SendEmail(string email, string token, string userName)
        {
            try
            {
                _logger.LogInformation($"Send email {email} with token {token} for {userName}");
                await _publisherPasswordRecovery.PublishAsync(new PasswordRecoveryEmailMessage
                {
                    Email = email,
                    UserName = userName,
                    Url = GetUrl(token)
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Could not send email to {email}");
            }
        }
    }
}