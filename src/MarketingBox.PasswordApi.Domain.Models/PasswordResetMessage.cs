using System.Runtime.Serialization;

namespace MarketingBox.PasswordApi.Domain.Models
{
    [DataContract]
    public class PasswordResetMessage
    {
        public const string Topic = "";
        [DataMember(Order = 1)] public string UserId { get; set; }
        [DataMember(Order = 2)] public string Token { get; set; }
        [DataMember(Order = 3)] public string NewPassword { get; set; }
    }
}