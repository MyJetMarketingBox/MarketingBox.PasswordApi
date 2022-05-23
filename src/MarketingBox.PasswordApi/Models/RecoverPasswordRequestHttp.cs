using System.ComponentModel.DataAnnotations;
using MarketingBox.Sdk.Common.Attributes;
using MarketingBox.Sdk.Common.Models;

namespace MarketingBox.PasswordApi.Models
{
    public class RecoverPasswordRequestHttp: ValidatableEntity
    {
        [Required, IsValidPassword]
        public string NewPassword { get; set; }
    }
}