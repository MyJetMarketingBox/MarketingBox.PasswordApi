using System;
using System.Threading.Tasks;
using MarketingBox.PasswordApi.Models;
using MarketingBox.PasswordApi.Services.Interfaces;
using MarketingBox.Sdk.Common.Exceptions;
using MarketingBox.Sdk.Common.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MarketingBox.PasswordApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PasswordRecoveryController : ControllerBase
    {
        private readonly IPasswordResetService _passwordResetService;
        private readonly IPasswordRecoveryService _recoveryService;
        private readonly IPasswordRecoveryNoSqlService _recoveryNoSql;
        private readonly ILogger<PasswordRecoveryController> _logger;

        public PasswordRecoveryController(
            IPasswordResetService passwordResetService,
            IPasswordRecoveryNoSqlService recoveryNoSql,
            ILogger<PasswordRecoveryController> logger,
            IPasswordRecoveryService recoveryService)
        {
            _passwordResetService = passwordResetService;
            _recoveryNoSql = recoveryNoSql;
            _logger = logger;
            _recoveryService = recoveryService;
        }

        [HttpPost]
        public async Task<IActionResult> RecoverPassword(
            [FromBody] ForgotPasswordRequestHttp request)
        {
            try
            {
                request.ValidateEntity();
            }
            catch (Exception e)
            {
                return e.Failed();
            }

            try
            {
                await _recoveryService.RecoverPassword(request.Email);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception occured while recovering password.");
                return Ok();
            }
        }

        [HttpGet("{token}")]
        public IActionResult GetRecoverPageAsync([FromRoute] string token)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(token))
                {
                    throw new BadRequestException("Cannot process empty token.");
                }

                _recoveryNoSql.GetEntity(token);

                return RedirectPermanent(Program.Settings.RecoveryPasswordPageUrl);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occured while getting recovering page.");
                return ex.Failed();
            }
        }

        [HttpPost("{token}")]
        public async Task<IActionResult> ResetPassword(
            [FromRoute] string token,
            [FromBody] ResetPasswordRequestHttp request)
        {
            try
            {
                request.ValidateEntity();

                var entity = _recoveryNoSql.GetEntity(token);

                await _passwordResetService.ResetPasswordMessageAsync(
                    entity.UserId,
                    request.NewPassword,
                    entity.TenantId);

                await _recoveryNoSql.DeleteEntityAsync(entity.UserId);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occured while sending new password message.");
                return ex.Failed();
            }
        }
    }
}