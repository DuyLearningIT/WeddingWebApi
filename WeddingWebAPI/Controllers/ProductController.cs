using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeddingWebAPI.Data;
using WeddingWebAPI.Repositories;

namespace WeddingWebAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly dbContext _dbContext;
        private readonly IProductRepository _productRepository;
        public ProductController(dbContext dbcontext, IProductRepository productRepository)
        {
            _dbContext = dbcontext;
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAllProduct()
        {
            var result = await _productRepository.GetAllProductsAsync();
            return Ok(result);
        }
    }
}
