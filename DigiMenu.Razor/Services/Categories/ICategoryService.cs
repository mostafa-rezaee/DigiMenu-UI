using DigiMenu.Razor.Models;
using DigiMenu.Razor.Models.Category;

namespace DigiMenu.Razor.Services.Categories
{
    public interface ICategoryService
    {
        Task<ApiResult?> CreateCategory(CreateCategoryCommand command);
        Task<ApiResult?> EditCategory(EditCategoryCommand command);
        Task<ApiResult?> DeleteCategory(long categoryId);

        Task<CategoryModel?> GetCategory(long categoryId);
        Task<List<CategoryModel>> GetCategories();
    }
}
