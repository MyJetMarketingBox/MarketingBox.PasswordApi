using System.Runtime.Serialization;

namespace MarketingBox.PasswordApi.Domain.Models
{
    [DataContract]
    public class PasswordRecoveryEmailMessage
    {
        public const string Topic = "";
        [DataMember(Order = 1)] public string Email { get; set; }
        [DataMember(Order = 2)] public string Url { get; set; }
    }
}