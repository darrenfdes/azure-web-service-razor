using product.Models;

namespace product.Services
{
    public interface IProductService
    {
        public List<Product> GetProducts();
        public Task<bool> IsBeta();
    }
}