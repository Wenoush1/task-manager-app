using Microsoft.AspNetCore.Identity;
using task_manager_app_backend.Authentication;
using task_manager_app_backend.Services.Abstractions;

namespace task_manager_app_backend.Areas.Users;

public class RegistrationHandler : IHandler
{
  private readonly UserManager<ApplicationUser> _userManager;

  public RegistrationHandler(UserManager<ApplicationUser> userManager)
  {
    _userManager = userManager;
  }

  public async Task<IdentityResult> RegisterUserAsync(RegisterModel model)
  {
    var userExists = await _userManager.FindByNameAsync(model.Username);
    if (userExists != null)
    {
      throw new Exception();
    }

    var user = new ApplicationUser()
    {
      Email = model.Email,
      SecurityStamp = Guid.NewGuid().ToString(),
      UserName = model.Username
    };
    var result = await _userManager.CreateAsync(user, model.Password);
    if (result.Succeeded == false)
    {
      throw new Exception();
    }
    return result;
  }
}
