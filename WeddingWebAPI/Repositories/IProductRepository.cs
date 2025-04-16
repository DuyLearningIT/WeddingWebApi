namespace WeddingWebAPI.Repositories
{
    public interface IProductRepository
    {
        Task<object> GetAllProductsAsync();
    }
}
