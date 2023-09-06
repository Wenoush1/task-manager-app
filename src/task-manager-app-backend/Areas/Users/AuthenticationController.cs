using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using task_manager_app_backend.Authentication;

namespace task_manager_app_backend.Areas.Users;

public class AuthenticationController : ControllerBase
{
  [HttpPost]
  [Route("login")]
  public async Task<IActionResult> Login([FromBody] LoginModel model, [FromServices] LoginHandler loginHandler)
  {
    var token = await loginHandler.LoginUserAsync(model);

    return Ok(new
    {
      token = new JwtSecurityTokenHandler().WriteToken(token),
      expiration = token.ValidTo
    });
  }

  [HttpPost]
  [Route("register")]
  public async Task<IActionResult> Register([FromBody] RegisterModel model, [FromServices] RegistrationHandler registrationHandler)
  {
    return Ok(await registrationHandler.RegisterUserAsync(model));
  }

  [HttpPost]
  [Route("register-admin")]
  public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model, [FromServices] AdminRegistrationHandler adminRegistrationHandler)
  {
    return Ok(await adminRegistrationHandler.RegisterAdminAsync(model));
  }
}
