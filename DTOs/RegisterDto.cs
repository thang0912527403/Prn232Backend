using System.ComponentModel.DataAnnotations;

namespace Prn232Project.DTOs
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "UserName is required")]
        [MinLength(6, ErrorMessage = "UserName must be at least 6 characters")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).+$",
        ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        public string? AvatarUrl { get; set; }  
    }
}
