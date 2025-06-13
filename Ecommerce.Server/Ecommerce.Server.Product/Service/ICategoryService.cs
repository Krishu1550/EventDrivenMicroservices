using Ecommerce.Server.Product.Model;

namespace Ecommerce.Server.Product.Service
{
    public interface ICategoryService
    {

        Task<List<Category>> GetAllCategoriesAsync();

        Task<Category> GetCategoryByIdAsync(int id);

        Task<Category> GetCategoryByNameAsync(
            string name);

        Task<Category> CreateCategoryAsync(Category category);

        Task<Category> UpdateCategoryAsync(
            int id, Category category);


        Task<Category> DeleteCategoryAsync(
            int id);
    }
}
