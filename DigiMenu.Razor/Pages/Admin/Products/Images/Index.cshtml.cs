using DigiMenu.Razor.Infrastructure.CustomValidation;
using DigiMenu.Razor.Infrastructure.RazorPageUtilities;
using DigiMenu.Razor.Models.Product;
using DigiMenu.Razor.Services.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DigiMenu.Razor.Pages.Admin.Products.Images
{
    public class IndexModel : BaseRazorPage
    {
        private readonly IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public List<ProductImageModel> Images { get; set; }

        [Display(Name = "عکس محصول")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [FileImage(ErrorMessage = "عکس نامعتبر است")]
        [BindProperty]
        public IFormFile ImageFIle { get; set; }

        [Display(Name = "ترتیب نمایش")]
        [BindProperty]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public int Order { get; set; }

        public async Task<IActionResult> OnGet(long productId)
        {
            var product = await _productService.GetProductById(productId);
            if (product == null)
                return RedirectToPage("Index");

            Images = product.ProductImages;
            return Page();
        }

        public async Task<IActionResult> OnPost(long productId)
        {
            return await AjaxTryCatch(() =>
            {
                return _productService.AddProductImage(new AddProductImageCommand()
                {
                    ProductId = productId,
                    ImageFile = ImageFIle,
                    DisplayOrder = Order
                });
            });
        }

        public async Task<IActionResult> OnPostDeleteItem(long productId, long id)
        {
            Order = 1;
            return await AjaxTryCatch(()
                => _productService.RemoveProductImage(new RemoveProductImageCommand()
                { ProductId = productId, ImageId = id, DisplayOrder = Order }), checkModelState: false);
        }

    }
}
