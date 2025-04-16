using System.Net;
using Microsoft.EntityFrameworkCore;
using WeddingWebAPI.Data;
using WeddingWebAPI.Mappers;
using WeddingWebAPI.Repositories;

namespace WeddingWebAPI.Services
{
    public class ProductService : IProductRepository
    {
        private readonly dbContext _dbContext;
        public ProductService(dbContext dbcontext)
        {
            _dbContext = dbcontext;
        }
        public async Task<object> GetAllProductsAsync()
        {
            try
            {
                var pros = await _dbContext.tb_Products.ToListAsync();
                var data = pros.Select(_ => _.ToDto());
                return new {httpStatusCode = HttpStatusCode.OK, data= data , mess = "Lấy sản phẩm thành công !"};
            }
            catch (Exception ex)
            {
                return new {httpStatusCode = HttpStatusCode.InternalServerError, mess = ex.Message};
            }
        }
    }
}
