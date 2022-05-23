using System.ComponentModel.DataAnnotations;
using MarketingBox.Sdk.Common.Attributes;
using MarketingBox.Sdk.Common.Models;

namespace MarketingBox.PasswordApi.Models
{
    public class ForgotPasswordRequestHttp : ValidatableEntity
    {
        [Required, IsValidEmail]
        public string Email { get; set; }
    }
}