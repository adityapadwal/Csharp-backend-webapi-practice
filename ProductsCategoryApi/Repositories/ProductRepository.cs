// importing namespaces
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsCategoryApi.Repositories;
using ProductsCategoryApi.Data;
using ProductsCategoryApi.Models;

// current namespace
namespace ProductCategoryApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        // prop for accessing db
        private readonly AppDbContext _context;

        // constructor
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        // getting all products
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }
        
        // getting product by id
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
        }

        // adding a product
        public async Task AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        // update product
        public async Task UpdateProductAsync(Product product)
        {
            var existingProduct = _context.Products.Local
                .FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                _context.Entry(existingProduct).State = EntityState.Detached;
            }
            _context.Products.Attach(product);
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // delete product
        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        // saving product state???
        public async Task SaveProductAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
