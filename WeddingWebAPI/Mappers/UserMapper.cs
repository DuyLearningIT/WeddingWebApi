using WeddingWebAPI.DTOs.User;
using WeddingWebAPI.Models;

namespace WeddingWebAPI.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToDto(this tb_User user)
        {
            return new UserDto
            {
              UserID = user.UserID,
              FullName = user.FullName,
              Email = user.Email,
              PasswordHash = user.PasswordHash,
              NumberPhone = user.NumberPhone,
              Address = user.Address,
              Role = user.Role,
              CreatedDate = user.CreatedDate,
            };
        }

        public static tb_User FromCreateToUser(this CreateUser user)
        {
            return new tb_User
            {
                FullName = user.FullName,
                Email = user.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password)
            };
        }
    }
}
