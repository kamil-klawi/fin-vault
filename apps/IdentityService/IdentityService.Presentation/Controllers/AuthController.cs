using IdentityService.Application.Commands.CreateUser;
using IdentityService.Application.Dtos;
using IdentityService.Application.Services.AuthService;
using IdentityService.Application.Services.EmailSender;
using IdentityService.Application.Services.ResetPassword;
using IdentityService.Application.Services.VerificationCode;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController(
        IMediator mediator,
        IAuthService authService,
        IVerificationCode verificationCode,
        IResetPassword resetPassword
        ) : ControllerBase
    {
        [HttpPost("register")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<UserDto>> Register([FromBody] CreateUserCommand command, CancellationToken cancellationToken)
        {
            UserDto userDto = await mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(Register), new { email = userDto.Email }, userDto);
        }

        [HttpPost("email/verify")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        public async Task<ActionResult> VerificationEmail([FromQuery] string toEmail)
        {
            EmailSender emailSender = new EmailSender();
            string plainTextMessage = $"""
                                       Hello {toEmail},

                                       Please confirm your email using the following link:
                                       {verificationCode.GenerateOtp()}

                                       Thank you!
                                       """;

            await emailSender.SendEmailAsync(
                toEmail: toEmail,
                subject: "Confirm your email",
                plainTextMessage
            );

            return Ok("Email sent successfully!");
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        public async Task<ActionResult> Login([FromBody] LoginDto loginDto)
        {
            string? token = await authService.LoginAsync(loginDto.Email, loginDto.Password);
            if (token is null)
                return Unauthorized(new { message = "Invalid email or password" });

            return Ok(new
            {
                access_token = token,
                token_type = "Bearer",
                expires_in = 3600
            });
        }

        [HttpPost("logout")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Logout()
        {
            return Ok("Logged out successfully!");
        }

        [HttpPost("password/forgot")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        public async Task<ActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            var token = await resetPassword.GeneratePasswordResetTokenAsync(request.Email);
            return Ok(new { Message = "Password reset token generated.", Token = token });
        }

        [HttpPost("password/reset")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            await resetPassword.ResetPasswordAsync(request.Email, request.Token, request.Password);
            return Ok("Password reset successfully.");
        }
    }
}
