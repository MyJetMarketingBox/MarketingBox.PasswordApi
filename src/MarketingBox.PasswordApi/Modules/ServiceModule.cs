using Autofac;
using MarketingBox.PasswordApi.Domain.Models;
using MarketingBox.PasswordApi.Services;
using MarketingBox.PasswordApi.Services.Interfaces;

namespace MarketingBox.PasswordApi.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmailService>()
                .As<IEmailService>()
                .SingleInstance();
            builder.RegisterType<PasswordRecoveryNoSqlService>()
                .As<IPasswordRecoveryNoSqlService>()
                .SingleInstance();
            builder.RegisterType<PasswordRecoveryService>()
                .As<IPasswordRecoveryService>()
                .SingleInstance();
            builder.RegisterType<PasswordResetService>()
                .As<IPasswordResetService>()
                .SingleInstance();
        }
    }
}