using Autofac;
using MarketingBox.Auth.Service.Client;
using Microsoft.Extensions.Logging;
using MyJetWallet.Sdk.NoSql;

namespace MarketingBox.PasswordApi.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAuthServiceClient(Program.Settings.AuthServiceUrl);
            var noSqlClient = builder.CreateNoSqlClient(
                Program.ReloadedSettings(e => e.MyNoSqlReaderHostPort).Invoke(),
                new LoggerFactory());
        }
    }
}