using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuickApp.ViewModels
{
    public class UserRegisterViewModel : UserViewModel
    {
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}
