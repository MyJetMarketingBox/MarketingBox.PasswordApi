using System.Runtime.Serialization;

namespace MarketingBox.PasswordApi.Domain.Models
{
    [DataContract]
    public class PasswordRecoveryEmailMessage
    {
        public const string Topic = "marketing-box-password-api-password-recovery-email";
        [DataMember(Order = 1)] public string Email { get; set; }
        [DataMember(Order = 2)] public string Url { get; set; }
        [DataMember(Order = 3)] public string UserName { get; set; }
    }
}