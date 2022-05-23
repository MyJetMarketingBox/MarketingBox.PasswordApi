using System.ComponentModel.DataAnnotations;
using MarketingBox.Sdk.Common.Attributes;
using MarketingBox.Sdk.Common.Models;

namespace MarketingBox.PasswordApi.Models
{
    public class RecoverPasswordRequestHttp: ValidatableEntity
    {
        [Required, IsValidPassword, StringLength(128, MinimumLength = 1)]
        public string NewPassword { get; set; }
    }
}