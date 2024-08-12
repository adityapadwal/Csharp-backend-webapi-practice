// importing namespaces
using Microsoft.EntityFrameworkCore;
using ProductsCategoryApi.Data;
using ProductsCategoryApi.Models;

// current namespace
namespace ProductsCategoryApi.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        // prop for accessing db
        private readonly AppDbContext _context;

        // constructor
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        // getting all categories
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        // getting category by id
        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        // posting a category
        public Task AddCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            return _context.SaveChangesAsync();
        }

        // updating a category
        public async Task UpdateCategoryAsync(Category category)
        {
            var existingCategory = _context.Categories.Local.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory != null)
            {
                _context.Entry(existingCategory).State = EntityState.Detached;
            }
            _context.Categories.Attach(category);
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // deleting a category
        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if(category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        // saving the context changes
        public Task SaveCategoryAsync()
        {
            throw new NotImplementedException();
        }

    }
}