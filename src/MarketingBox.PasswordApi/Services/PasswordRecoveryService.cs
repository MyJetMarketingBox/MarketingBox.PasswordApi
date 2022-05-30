using System;
using System.Threading.Tasks;
using MarketingBox.Auth.Service.Client.Interfaces;
using MarketingBox.PasswordApi.Services.Interfaces;
using MarketingBox.Sdk.Crypto;

namespace MarketingBox.PasswordApi.Services
{
    public class PasswordRecoveryService : IPasswordRecoveryService
    {
        private readonly IUserClient _userClient;
        private readonly ICryptoService _cryptoService;
        private readonly IEmailService _emailService;
        private readonly IPasswordRecoveryNoSqlService _recoveryNoSql;

        public PasswordRecoveryService(
            IUserClient userClient,
            ICryptoService cryptoService,
            IEmailService emailService,
            IPasswordRecoveryNoSqlService recoveryNoSql)
        {
            _userClient = userClient;
            _cryptoService = cryptoService;
            _emailService = emailService;
            _recoveryNoSql = recoveryNoSql;
        }

        public async Task RecoverPassword(string email)
        {
            var encryptedEmail = _cryptoService.Encrypt(
                email,
                Program.Settings.EncryptionSalt,
                Program.Settings.EncryptionSecret);
            var user = _userClient.GetUser(encryptedEmail);

            if (user is null)
                return;

            var token = Guid.NewGuid().ToString("N");

            await _recoveryNoSql.UpsertEntityAsync(user.ExternalUserId, token, user.TenantId);
            await _emailService.SendEmail(email, token);
        }
    }
}