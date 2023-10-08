using product.Models;

namespace product.Services
{
    public interface IProductService
    {
        public Task<List<Product>> GetProducts();
        public Task<bool> IsBeta();
    }
}