using System.ComponentModel.DataAnnotations;

namespace GameWatchAPI.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Emri { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$", ErrorMessage = "Password must be complex.")]
        public string Password { get; set; }
        public string Username { get; set; }
        [Required]
        public string Qyteti { get; set; }
        [Required]
        public int BiznesiId { get; set; }
    }
}
