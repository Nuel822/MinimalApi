using AndelaTest.Models;

namespace AndelaTest.Core
{
    public interface IProductRepository
    {
       Task<IEnumerable<Product>> GetAllProduct();

       Task CreateProduct(Product product);
       Task SaveAsync();
       Task <Product?> GetProductById(int id);
        
    }
}