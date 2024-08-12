// current namespace
using ProductsCategoryApi.Models;

namespace ProductsCategoryApi.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(); // getting all products
        Task<Product> GetProductByIdAsync(int id); // getting product by id
        Task AddProductAsync(Product product); // posting a product
        Task UpdateProductAsync(Product product); // updating a product
        Task DeleteProductAsync(int id); // deleting a product
        Task SaveProductAsync(); // saving context changes
    }
}
