using DigiMenu.Razor.Infrastructure;
using DigiMenu.Razor.Models;
using DigiMenu.Razor.Models.Product;
using Newtonsoft.Json;
using System.Text;

namespace DigiMenu.Razor.Services.Products
{
    public class ProductService :IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        
        public async Task<ApiResult?> CreateProduct(CreateProductCommand command)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(command.Title), "title");
            formData.Add(new StringContent(command.CategoryId.ToString()), "categoryId");
            formData.Add(new StreamContent(command.Image.OpenReadStream()), "image", command.Image.FileName);
            formData.Add(new StringContent(command.Price.ToString()), "price");
            formData.Add(new StringContent((command.LikeCount??0).ToString()), "likeCount");
            formData.Add(new StringContent((command.IsVisible).ToString()), "isVisible");
            formData.Add(new StringContent(command.Description??""), "description");
            formData.Add(new StringContent(command.SeoData?.MetaDescription ?? ""), "seoData.MetaDescription");
            formData.Add(new StringContent(command.SeoData?.MetaTitle ?? ""), "seoData.MetaTitle");
            formData.Add(new StringContent(command.SeoData?.MetaKeywords ?? ""), "seoData.MetaKeywords");
            formData.Add(new StringContent((command.SeoData?.IsIndexed ?? false).ToString()), "seoData.IsIndexed");
            formData.Add(new StringContent(command.SeoData?.Canonicial ?? ""), "seoData.Canonicial");
            formData.Add(new StringContent(command.SeoData?.Schema ?? ""), "seoData.Schema");

            var result = await _httpClient.PostAsync("product", formData);
            return await result.Content.ReadFromJsonAsync<ApiResult?>();
        }

        public async Task<ApiResult?> EditProduct(EditProductCommand command)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(command.Id.ToString()), "id");
            formData.Add(new StringContent(command.Title), "title");
            formData.Add(new StringContent(command.CategoryId.ToString()), "categoryId");
            if (command.ImageFile != null)
                formData.Add(new StreamContent(command.ImageFile.OpenReadStream()), "image", command.ImageFile.FileName);
            formData.Add(new StringContent(command.Price.ToString()), "price");
            formData.Add(new StringContent((command.LikeCount ?? 0).ToString()), "likeCount");
            formData.Add(new StringContent((command.IsVisible).ToString()), "isVisible");
            formData.Add(new StringContent(command.Description ?? ""), "description");
            formData.Add(new StringContent(command.SeoData?.MetaDescription ?? ""), "seoData.MetaDescription");
            formData.Add(new StringContent(command.SeoData?.MetaTitle ?? ""), "seoData.MetaTitle");
            formData.Add(new StringContent(command.SeoData?.MetaKeywords ?? ""), "seoData.MetaKeywords");
            formData.Add(new StringContent((command.SeoData?.IsIndexed ?? false).ToString()), "seoData.IsIndexed");
            formData.Add(new StringContent(command.SeoData?.Canonicial ?? ""), "seoData.Canonicial");
            formData.Add(new StringContent(command.SeoData?.Schema ?? ""), "seoData.Schema");

            var result = await _httpClient.PutAsync("product", formData);
            return await result.Content.ReadFromJsonAsync<ApiResult?>();
        }

        public async Task<ProductModel?> GetProductById(long id)
        {
            var result = await _httpClient.GetFromJsonAsync<ApiResult<ProductModel>>($"product/{id}");
            return result?.Data;
        }

        public async Task<ProductFilterResult?> GetCategoryProducts(int page, int takeCount, long categoryId)
        {
            var url = $"product/categoryProducts?page={page}&takeCount={takeCount}&categoryId={categoryId}";
            var result = await _httpClient.GetFromJsonAsync<ApiResult<ProductFilterResult>>(url);
            return result?.Data;
        }

        public async Task<ProductFilterResult?> GetProductsByFilter(ProductFilterParams filterParams)
        {
            var url = filterParams.GenerateBaseFilterUrl("product");
            if (filterParams.Id != null)
            {
                url += $"&id={filterParams.Id}";
            }
            if (filterParams.CategoryId != null)
            {
                url += $"&categoryId={filterParams.CategoryId}";
            }
            if (!string.IsNullOrWhiteSpace(filterParams.Title))
            {
                url += $"&title={filterParams.Title}";
            }
            var result = await _httpClient.GetFromJsonAsync<ApiResult<ProductFilterResult>>(url);
            return result?.Data;
        }

        public async Task<ApiResult?> AddProductImage(AddProductImageCommand command)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StreamContent(command.ImageFile.OpenReadStream()), "ImageFile", command.ImageFile.FileName);
            formData.Add(new StringContent(command.ProductId.ToString()), "ProductId");
            formData.Add(new StringContent(command.DisplayOrder.ToString()), "DisplayOrder");
            var result = await _httpClient.PostAsync("product/image", formData);
            return await result.Content.ReadFromJsonAsync<ApiResult?>();
        }


        public async Task<ApiResult?> RemoveProductImage(RemoveProductImageCommand command)
        {
            var json = JsonConvert.SerializeObject(command);
            var message = new HttpRequestMessage(HttpMethod.Delete, "product/image")
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            var result = await _httpClient.SendAsync(message);
            return await result.Content.ReadFromJsonAsync<ApiResult?>();
        }
    }
}
