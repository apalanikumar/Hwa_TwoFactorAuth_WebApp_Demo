using System.ComponentModel.DataAnnotations;

namespace TwoFactorAuthWebApp.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
