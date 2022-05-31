using Autofac;
using MarketingBox.Auth.Service.Client;
using MarketingBox.PasswordApi.Domain.Models;
using MyJetWallet.Sdk.NoSql;
using MyJetWallet.Sdk.ServiceBus;

namespace MarketingBox.PasswordApi.Modules
{
    public class ClientModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var serviceBusClient = builder
                .RegisterMyServiceBusTcpClient(
                    Program.ReloadedSettings(e => e.MarketingBoxServiceBusHostPort),
                    Program.LogFactory);
            
            builder.RegisterMyServiceBusPublisher<PasswordRecoveryEmailMessage>(
                serviceBusClient, 
                PasswordRecoveryEmailMessage.Topic,
                false);
            builder.RegisterMyServiceBusPublisher<PasswordResetMessage>(
                serviceBusClient, 
                PasswordResetMessage.Topic,
                false);
            
            var noSqlClient = builder.CreateNoSqlClient(
                Program.ReloadedSettings(e => e.MyNoSqlReaderHostPort).Invoke(),
                Program.LogFactory);
            
            builder.RegisterUserClient(Program.Settings.AuthServiceUrl, noSqlClient);

            builder.RegisterMyNoSqlWriter<PasswordRecoveryNoSql>(
                Program.ReloadedSettings(e => e.MyNoSqlWriterUrl),
                PasswordRecoveryNoSql.TableName);
            builder.RegisterMyNoSqlReader<PasswordRecoveryNoSql>(noSqlClient, PasswordRecoveryNoSql.TableName);
        }
    }
}