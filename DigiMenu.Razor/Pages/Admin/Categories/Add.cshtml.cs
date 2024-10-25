using DigiMenu.Razor.Infrastructure.RazorPageUtilities;
using DigiMenu.Razor.Models;
using DigiMenu.Razor.Models.Category;
using DigiMenu.Razor.Services.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DigiMenu.Razor.Pages.Admin.Categories
{
    [BindProperties]
    public class AddModel : BaseRazorPage
    {
        private readonly ICategoryService _categoryService;

        public AddModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Title { get; set; }

        [Display(Name = "نصویر دسته بندی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [Infrastructure.CustomValidation.FileImage(ErrorMessage = "{0} معتبر نیست")]
        public IFormFile? Image { get; set; }


        [Display(Name = "مخفی نباشد؟")]
        public bool IsVisible { get; set; }

        public SeoDataViewModel SeoData { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var result = await _categoryService.CreateCategory(new CreateCategoryCommand()
            {
                Title = Title,
                Image = Image,
                IsVisible = IsVisible,
                SeoData = new SeoData
                {
                    MetaTitle = SeoData.MetaTitle,
                    Canonicial = SeoData.Canonicial,
                    IsIndexed = SeoData.IsIndexed,
                    MetaDescription = SeoData.MetaDescription,
                    MetaKeywords = SeoData.MetaKeywords,
                    Schema = SeoData.Schema
                }
            });
            return RedirectAndShowAlert(result, RedirectToPage("Index"));

        }

    }
}
