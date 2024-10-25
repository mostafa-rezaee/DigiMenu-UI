using DigiMenu.Razor.Infrastructure.CustomValidation;
using DigiMenu.Razor.Infrastructure.RazorPageUtilities;
using DigiMenu.Razor.Models;
using DigiMenu.Razor.Models.Product;
using DigiMenu.Razor.Services.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DigiMenu.Razor.Pages.Admin.Products
{
    [BindProperties]
    public class AddModel : BaseRazorPage
    {
        private readonly IProductService _productService;

        public AddModel(IProductService productService)
        {
            _productService = productService;
        }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Title { get; set; }

        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [Range(1, long.MaxValue, ErrorMessage = "دسته بندی را وارد کنید")]
        public long CategoryId { get; set; }

        [Display(Name = "عکس محصول")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [FileImage(ErrorMessage = "عکس نامعتبر است")]
        public IFormFile Image { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public decimal Price { get; set; }

        [Display(Name = "مخفی نباشد؟")]
        public bool IsVisible { get; set; }

        [Display(Name = "توضیحات")]
        [UIHint("Ckeditor4")]
        public string? Description { get; set; }

        public SeoDataViewModel SeoData { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var result = await _productService.CreateProduct(new CreateProductCommand()
            {
                CategoryId = CategoryId,
                Description = Description,
                Image = Image,
                SeoData = new SeoData() { 
                    Canonicial = SeoData.Canonicial,
                    IsIndexed = SeoData.IsIndexed,
                    MetaDescription = SeoData.MetaDescription,
                    MetaKeywords = SeoData.MetaKeywords,
                    MetaTitle = SeoData.MetaTitle,
                    Schema = SeoData.Schema
                },
                Price = Price,
                IsVisible = IsVisible,
                Title = Title
            });

            return RedirectAndShowAlert(result, RedirectToPage("Index"));
        }
    }
}
