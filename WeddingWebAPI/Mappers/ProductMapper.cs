using WeddingWebAPI.DTOs.Product;
using WeddingWebAPI.Models;

namespace WeddingWebAPI.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto ToDto(this tb_Product pro)
        {
            return new ProductDto
            {
                ProductID = pro.ProductID,
                Name = pro.Name,
                Description = pro.Description,
                Price = pro.Price,
                StockQuantity = pro.StockQuantity,
                ImageUrl = pro.ImageUrl,
                CreatedDate = pro.CreatedDate,
                CategoryID = pro.CategoryID,
            };
        }
    }
}
