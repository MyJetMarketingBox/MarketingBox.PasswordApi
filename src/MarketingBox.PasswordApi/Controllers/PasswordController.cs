using System.Threading.Tasks;
using MarketingBox.PasswordApi.Models;
using MarketingBox.Sdk.Common.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketingBox.PasswordApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("/api/[controller]")]
    public class PasswordController : ControllerBase
    {
        public PasswordController()
        {
        }

        [HttpPost("users/{userId}")]
        public async Task<IActionResult> SendLinkAsync(
            [FromBody] ForgotPasswordRequestHttp request)
        {
            request.ValidateEntity();
            await Task.CompletedTask;
            return Ok();
        }
        
        [HttpGet("{uniqueId}")]
        public async Task<IActionResult> GetRecoverPageAsync([FromRoute] string uniqueId)
        {
            await Task.CompletedTask;
            return Ok();
        }
        
        [HttpPost("{uniqueId}")]
        public async Task<IActionResult> SendLinkAsync(
            [FromRoute] string uniqueId,
            [FromBody] RecoverPasswordRequestHttp request)
        {
            request.ValidateEntity();
            await Task.CompletedTask;
            return Ok();
        }
    }
}