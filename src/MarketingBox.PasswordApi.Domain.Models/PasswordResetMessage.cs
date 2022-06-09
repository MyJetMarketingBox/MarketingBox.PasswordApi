using System.Runtime.Serialization;

namespace MarketingBox.PasswordApi.Domain.Models
{
    [DataContract]
    public class PasswordResetMessage
    {
        public const string Topic = "marketing-box-password-api-password-reset";
        [DataMember(Order = 1)] public string UserId { get; set; }
        [DataMember(Order = 2)] public string TenantId { get; set; }
        [DataMember(Order = 3)] public string NewPassword { get; set; }
    }
}