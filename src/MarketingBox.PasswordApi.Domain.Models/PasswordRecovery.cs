using System;
using System.Runtime.Serialization;

namespace MarketingBox.PasswordApi.Domain.Models
{
    [DataContract]
    public class PasswordRecovery
    {
        [DataMember(Order = 1)] public DateTime ExpiredDate { get; set; }
        [DataMember(Order = 2)] public string UserId { get; set; }
        [DataMember(Order = 3)] public string Token { get; set; }
        [DataMember(Order = 4)] public string TenantId { get; set; }
    }
}