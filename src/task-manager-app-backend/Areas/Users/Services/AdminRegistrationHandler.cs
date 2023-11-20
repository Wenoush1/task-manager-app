using Microsoft.AspNetCore.Identity;
using task_manager_app_backend.Abstractions;
using task_manager_app_backend.Areas.Users.Models;

namespace task_manager_app_backend.Areas.Users.Services;

public class AdminRegistrationHandler : IHandler
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AdminRegistrationHandler(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<IdentityResult> RegisterAdminAsync(RegisterRequest model)
    {
        var userExists = await _userManager.FindByNameAsync(model.Username);

        var user = new ApplicationUser()
        {
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.Username
        };
        await _userManager.CreateAsync(user, model.Password);

        if (await _roleManager.RoleExistsAsync(UserRoles.Admin) == false)
        {
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        }
        var result = await _userManager.AddToRoleAsync(user, UserRoles.Admin);

        return result;
    }
}
