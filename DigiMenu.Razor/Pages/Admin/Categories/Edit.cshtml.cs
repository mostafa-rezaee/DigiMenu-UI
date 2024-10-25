using DigiMenu.Razor.Infrastructure.RazorPageUtilities;
using DigiMenu.Razor.Models;
using DigiMenu.Razor.Models.Category;
using DigiMenu.Razor.Services.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DigiMenu.Razor.Pages.Admin.Categories
{
    [BindProperties]
    public class EditModel : BaseRazorPage
    {
        private readonly ICategoryService _categoryService;

        public EditModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Title { get; set; }

        [Display(Name = "نصویر دسته بندی")]
        [Infrastructure.CustomValidation.FileImage(ErrorMessage = "{0} معتبر نیست")]
        public IFormFile? Image { get; set; }


        [Display(Name = "مخفی نباشد؟")]
        public bool IsVisible { get; set; }

        public SeoDataViewModel SeoData { get; set; }
        public async Task<IActionResult> OnGet(long id)
        {
            var category = await _categoryService.GetCategory(id);
            if (category == null)
                return RedirectToPage("Index");

            Title = category.Title;
            IsVisible = category.IsVisible;
            SeoData = new SeoDataViewModel
            {
                MetaTitle = category.SeoData.MetaTitle,
                MetaDescription = category.SeoData.MetaDescription,
                Canonicial = category.SeoData.Canonicial,
                IsIndexed = category.SeoData.IsIndexed,
                MetaKeywords = category.SeoData.MetaKeywords,
                Schema = category.SeoData.Schema
            };

            return Page();

        }

        public async Task<IActionResult> OnPost(long id)
        {
            var res = await _categoryService.EditCategory(new EditCategoryCommand()
            {
                Id = id,
                Title = Title,
                SeoData = new SeoData
                {
                    MetaTitle = SeoData.MetaTitle,
                    MetaDescription = SeoData.MetaDescription,
                    Canonicial = SeoData.Canonicial,
                    IsIndexed = SeoData.IsIndexed,
                    MetaKeywords = SeoData.MetaKeywords,
                    Schema = SeoData.Schema
                },
                ImageFile = Image,
                IsVisible = IsVisible
            });
            return RedirectAndShowAlert(res, RedirectToPage("Index"));
        }

    }
}
