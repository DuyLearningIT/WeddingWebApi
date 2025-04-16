using System.ComponentModel.DataAnnotations;

namespace WeddingWebAPI.DTOs.User
{
    public class UserDto
    {
        public int UserID { get; set; }

        public string FullName { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public string? NumberPhone { get; set; }

        public string? Address { get; set; }

        public string? Role { get; set; } = "User";

        public DateOnly? CreatedDate { get; set; }
    }
}
