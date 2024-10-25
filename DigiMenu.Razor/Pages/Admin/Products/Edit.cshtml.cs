using DigiMenu.Razor.Infrastructure.CustomValidation;
using DigiMenu.Razor.Infrastructure.RazorPageUtilities;
using DigiMenu.Razor.Models;
using DigiMenu.Razor.Models.Category;
using DigiMenu.Razor.Services.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DigiMenu.Razor.Pages.Admin.Products
{
    [BindProperties]
    public class EditModel : BaseRazorPage
    {
        private readonly IProductService _productService;

        public EditModel(IProductService productService)
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
        [FileImage(ErrorMessage = "عکس نامعتبر است")]
        public IFormFile? Image { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public decimal Price { get; set; }

        [Display(Name = "مخفی نباشد؟")]
        public bool IsVisible { get; set; }

        [Display(Name = "توضیحات")]
        [UIHint("Ckeditor4")]
        public string? Description { get; set; }

        public SeoDataViewModel SeoData { get; set; }
        public async Task<IActionResult> OnGet(long productId)
        {
            var product = await _productService.GetProductById(productId);
            if (product == null) return RedirectToPage("Index");

            Title = product.Title;
            CategoryId = product.CategoryId;
            Price = product.Price;
            IsVisible = product.IsVisible ?? true;
            Description = product.Description;
            SeoData = new SeoDataViewModel
            {
                MetaTitle = product.SeoData.MetaTitle,
                MetaDescription = product.SeoData.MetaDescription,
                Canonicial = product.SeoData.Canonicial,
                IsIndexed = product.SeoData.IsIndexed,
                MetaKeywords = product.SeoData.MetaKeywords,
                Schema = product.SeoData.Schema
            };

            return Page();

        }

        public async Task<IActionResult> OnPost(long productId)
        {
            var result = await _productService.EditProduct(new Models.Product.EditProductCommand()
            {
                Id = productId,
                Title = Title,
                CategoryId = CategoryId,
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
                IsVisible = IsVisible,
                Price = Price,
                Description = Description
            });
            return RedirectAndShowAlert(result, RedirectToPage("Index"));
        }
    }
}
