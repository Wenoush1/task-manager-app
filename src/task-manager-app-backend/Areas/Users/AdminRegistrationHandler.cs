using Microsoft.AspNetCore.Identity;
using task_manager_app_backend.Authentication;
using task_manager_app_backend.Services.Abstractions;

namespace task_manager_app_backend.Areas.Users;

public class AdminRegistrationHandler : IHandler
{
  private readonly UserManager<ApplicationUser> _userManager;
  private readonly RoleManager<IdentityRole> _roleManager;

  public AdminRegistrationHandler(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
  {
    _userManager = userManager;
    _roleManager = roleManager;
  }

  public async Task<IdentityResult> RegisterAdminAsync(RegisterModel model)
  {
    var userExists = await _userManager.FindByNameAsync(model.Username);

    var user = new ApplicationUser()
    {
      Email = model.Email,
      SecurityStamp = Guid.NewGuid().ToString(),
      UserName = model.Username
    };
    var result = await _userManager.CreateAsync(user, model.Password);


    if (await _roleManager.RoleExistsAsync(UserRoles.Admin) == false)
    {
      await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
    }
    result = await _userManager.AddToRoleAsync(user, UserRoles.Admin);

    return result;
  }
}
