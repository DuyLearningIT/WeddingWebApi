using WeddingWebAPI.DTOs.User;

namespace WeddingWebAPI.Repositories
{
    public interface IUserRepository
    {
        Task<object> GetAllUserAsync();
        Task<object> LoginAsync(LoginUser user);
        Task<object> CreateAsync(CreateUser user);
    }
}
