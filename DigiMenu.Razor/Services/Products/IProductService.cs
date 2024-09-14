using DigiMenu.Razor.Models;
using DigiMenu.Razor.Models.Product;

namespace DigiMenu.Razor.Services.Products
{
    public interface IProductService
    {
        Task<ProductFilterResult?> GetProductsByFilter(ProductFilterParams filterParams);
        Task<ProductFilterResult?> GetCategoryProducts(int page, int takeCount, long categoryId);
        Task<ProductModel?> GetProductById(long id);

        Task<ApiResult?> CreateProduct(CreateProductCommand command);
        Task<ApiResult?> EditProduct(EditProductCommand command);
        Task<ApiResult?> AddProductImage(AddProductImageCommand command);
        Task<ApiResult?> RemoveProductImage(RemoveProductImageCommand command);
    }
}
