namespace WeddingWebAPI.DTOs.Product
{
    public class ProductDto
    {
        public int ProductID { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public decimal? Price { get; set; }

        public int? StockQuantity { get; set; }

        public string? ImageUrl { get; set; }

        public DateOnly? CreatedDate { get; set; }

        public int? CategoryID { get; set; }
    }
}
