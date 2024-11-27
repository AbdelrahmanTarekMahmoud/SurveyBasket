using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SurveyBasket.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        [HttpPost("")]
        public async Task<IActionResult> LoginAsync(LoginRequest loginRequest , CancellationToken cancellationToken)
        {
            var authResult = await _authService.GetTokenAsync(loginRequest.Email, loginRequest.password, cancellationToken);
            return authResult is null ? BadRequest("invalid email/password") : Ok(authResult);
        }
    }
}
