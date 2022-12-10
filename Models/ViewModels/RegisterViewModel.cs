using System.ComponentModel.DataAnnotations;

namespace CSM.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(15)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone")]
        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(20)]
        public string Password { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Confirm Password")]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
