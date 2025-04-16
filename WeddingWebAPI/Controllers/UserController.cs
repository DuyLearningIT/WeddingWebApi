using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeddingWebAPI.Data;
using WeddingWebAPI.DTOs.User;
using WeddingWebAPI.Repositories;

namespace WeddingWebAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly dbContext _dbContext;
        private readonly IUserRepository _userRepository;

        public UserController(dbContext dbcontext, IUserRepository userRepository)
        {
            _dbContext = dbcontext;
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userRepository.GetAllUserAsync();
            return Ok(result);
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(LoginUser user)
        {
            var result = await _userRepository.LoginAsync(user);
            return Ok(result);
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync(CreateUser user)
        {
            var result = await _userRepository.CreateAsync(user);
            return Ok(result);
        }
    }
}
