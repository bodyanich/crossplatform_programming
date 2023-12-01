using IdentityServer4.Models;
using System.ComponentModel.DataAnnotations;

namespace cross_lab5.Models
{
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "User Name")]
        // Ensure uniqueness will be handled at the database level or service logic level
        public string Username { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Full Name")]
        public string FirstName { get; set; } // Assuming FirstName + LastName constitutes the FullName

        public string LastName { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W]).+$", ErrorMessage = "Password must have at least 1 uppercase, 1 lowercase, 1 digit, and 1 special character.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords must be the same.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [RegularExpression(@"^(\+380)[0-9]{9}$", ErrorMessage = "Not a valid Ukraine phone number.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email Address is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
