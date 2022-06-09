using MyJetWallet.Sdk.Service;
using MyYamlParser;

namespace MarketingBox.PasswordApi.Settings
{
    public class SettingsModel
    {
        [YamlProperty("MarketingBoxPasswordApi.SeqServiceUrl")]
        public string SeqServiceUrl { get; set; }

        [YamlProperty("MarketingBoxPasswordApi.ZipkinUrl")]
        public string ZipkinUrl { get; set; }

        [YamlProperty("MarketingBoxPasswordApi.ElkLogs")]
        public LogElkSettings ElkLogs { get; set; }

        [YamlProperty("MarketingBoxPasswordApi.MyNoSqlWriterUrl")]
        public string MyNoSqlWriterUrl { get; set; }

        [YamlProperty("MarketingBoxPasswordApi.MyNoSqlReaderHostPort")]
        public string MyNoSqlReaderHostPort { get; set; }

        [YamlProperty("MarketingBoxPasswordApi.MarketingBoxServiceBusHostPort")]
        public string MarketingBoxServiceBusHostPort { get; set; }

        [YamlProperty("MarketingBoxPasswordApi.AuthServiceUrl")]
        public string AuthServiceUrl { get; set; }
        
        [YamlProperty("MarketingBoxPasswordApi.EncryptionSalt")]
        public string EncryptionSalt { get; set; }

        [YamlProperty("MarketingBoxPasswordApi.EncryptionSecret")]
        public string EncryptionSecret { get; set; }

        [YamlProperty("MarketingBoxPasswordApi.RecoveryPasswordPageUrl")]
        public string RecoveryPasswordPageUrl { get; set; }

        [YamlProperty("MarketingBoxPasswordApi.PasswordApiUrl")]
        public string PasswordApiUrl { get; set; }

        [YamlProperty("MarketingBoxPasswordApi.RecoveryTokenLifetimeInHours")]
        public int RecoveryTokenLifetimeInHours { get; set; }
        
        [YamlProperty("MarketingBoxPasswordApi.RecoveryCacheLength")]
        public int RecoveryCacheLength { get; set; }
    }
}
