using DigiMenu.Razor.Infrastructure.RazorPageUtilities;
using DigiMenu.Razor.Models.Product;
using DigiMenu.Razor.Services.Categories;
using DigiMenu.Razor.Services.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigiMenu.Razor.Pages.Admin.Products
{
    public class IndexModel : BaseRazorFilter<ProductFilterParams>
    {
        private readonly IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }
        public ProductFilterResult FilterResult { get; set; }
        public async Task OnGet()
        {
            FilterResult = await _productService.GetProductsByFilter(FilterParams);
        }
    }
}
