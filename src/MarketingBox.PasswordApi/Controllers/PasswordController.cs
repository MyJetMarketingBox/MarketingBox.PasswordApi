using System.Threading.Tasks;
using MarketingBox.PasswordApi.Models;
using MarketingBox.Sdk.Common.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace MarketingBox.PasswordApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PasswordController : ControllerBase
    {
        public PasswordController()
        {
        }

        [HttpPost("recover")]
        public async Task<IActionResult> SendLinkAsync(
            [FromBody] ForgotPasswordRequestHttp request)
        {
            request.ValidateEntity();
            await Task.CompletedTask;
            return Ok();
        }
        
        [HttpGet("{token}")]
        public async Task<IActionResult> GetRecoverPageAsync([FromRoute] string token)
        {
            await Task.CompletedTask;
            return Ok();
        }
        
        [HttpPost("{token}")]
        public async Task<IActionResult> SendLinkAsync(
            [FromRoute] string token,
            [FromBody] RecoverPasswordRequestHttp request)
        {
            request.ValidateEntity();
            await Task.CompletedTask;
            return Ok();
        }
    }
}