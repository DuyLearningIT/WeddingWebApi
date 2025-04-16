using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WeddingWebAPI.Data;
using WeddingWebAPI.DTOs.User;
using WeddingWebAPI.Mappers;
using WeddingWebAPI.Models;
using WeddingWebAPI.Repositories;

namespace WeddingWebAPI.Services
{
    public class UserService : IUserRepository
    {
        private readonly dbContext _dbContext;
        private readonly IConfiguration _configuration;
        public UserService(dbContext dbContext, IConfiguration configuration)
        {
            _dbContext  = dbContext;
            _configuration = configuration;
        }
        public async Task<object> GetAllUserAsync()
        {
            try
            {
                var users = await _dbContext.tb_Users.ToListAsync();
                var data = users.Select(_ => _.ToDto());
                return new { httpStatusCode = HttpStatusCode.OK, data = data, mess = "Lấy người dùng thành công !" };
            }catch(Exception ex)
            {
                return new { httpStatusCode = HttpStatusCode.InternalServerError, mess = ex.Message};
            }
        }

        public async Task<object> LoginAsync(LoginUser user)
        {
            try
            {
                var check = await _dbContext.tb_Users.FirstOrDefaultAsync(_ => _.Email ==  user.Email);
                if (check == null)
                    return new { httpStatusCode = HttpStatusCode.NotFound, mess = "Tài khoản này chưa được đăng ký !" };
                if(!BCrypt.Net.BCrypt.Verify(user.Password, check.PasswordHash.Trim()))
                    return new { httpStatusCode = HttpStatusCode.BadRequest, mess = "Tên đăng nhập hoặc mật khẩu không chính xác !" };

                return new {
                    HttpStatusCode =  HttpStatusCode.OK, 
                    token = GenerateToken(check),
                    mess = "Đăng nhập thành công !"
                };
            }catch(Exception ex)
            {
                return new { httpStatusCode = HttpStatusCode.InternalServerError, mess = ex.Message };
            }
        }
        public async Task<object> CreateAsync(CreateUser user)
        {
            try
            {
                var check = await _dbContext.tb_Users.FirstOrDefaultAsync(_ => _.Email == user.Email);
                if (check != null)
                    return new { httpStatusCode = HttpStatusCode.BadRequest, mess = "Email đã tồn tại !" };
                await _dbContext.tb_Users.AddAsync(user.FromCreateToUser());
                await _dbContext.SaveChangesAsync();
                return new
                {
                    httpStatusCode = HttpStatusCode.Created,
                    mess = "Tạo thành công tài khoản !",
                    data = user
                };
            }catch(Exception ex)
            {
                return new { httpStatusCode = HttpStatusCode.InternalServerError, mess = ex.Message };
            }
        }

        private string GenerateToken(tb_User user)
        {
            string? secretKey = _configuration["AppSettings:SecretKey"];
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var tokenDes = new SecurityTokenDescriptor
            {
                Subject  = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("Role", user.Role ?? "User")
                }), 
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey??string.Empty)), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = jwtTokenHandler.CreateToken(tokenDes);

            return jwtTokenHandler.WriteToken(token);
        }
    }
}
