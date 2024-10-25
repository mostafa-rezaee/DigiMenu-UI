using DigiMenu.Razor.Infrastructure.RazorPageUtilities;
using DigiMenu.Razor.Models.Category;
using DigiMenu.Razor.Services.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigiMenu.Razor.Pages.Admin.Categories
{
    public class IndexModel : BaseRazorPage
    {
        private readonly ICategoryService _categoryService;

        public IndexModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public List<CategoryModel> Categories { get; set; }
        public async Task OnGet()
        {
            Categories = await _categoryService.GetCategories();
        }

        public async Task<IActionResult> OnPostDelete(long id)
        {
            return await AjaxTryCatch(() => _categoryService.DeleteCategory(id));
        }

    }
}
