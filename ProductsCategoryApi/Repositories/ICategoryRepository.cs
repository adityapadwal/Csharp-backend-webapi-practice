// importing namespaces
using ProductsCategoryApi.Controllers;
using ProductsCategoryApi.Models;

// current namespace
namespace ProductsCategoryApi.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync(); // getting all categories
        Task<Category> GetCategoryByIdAsync(int id); // getting category by id
        Task AddCategoryAsync(Category category); // posting a category
        Task UpdateCategoryAsync(Category category); // updating a category
        Task DeleteCategoryAsync(int id); // deleting a category bu id
        Task SaveCategoryAsync(); // saving the context changes?
    }
}
