using System.ComponentModel.DataAnnotations;

namespace CSM.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(20)]
        public string Password { get; set; }
    }
}
