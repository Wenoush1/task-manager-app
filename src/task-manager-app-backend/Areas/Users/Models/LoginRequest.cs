using System.ComponentModel.DataAnnotations;

namespace task_manager_app_backend.Areas.Users.Models
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
