using System.ComponentModel.DataAnnotations;

namespace MatcomJam.ViewModels
{
    public class UserRegisterViewModel : UserViewModel
    {
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}
