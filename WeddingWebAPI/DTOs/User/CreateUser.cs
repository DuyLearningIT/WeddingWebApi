using System.ComponentModel.DataAnnotations;

namespace WeddingWebAPI.DTOs.User
{
    public class CreateUser
    {
        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
