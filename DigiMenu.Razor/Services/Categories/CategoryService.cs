using DigiMenu.Razor.Models;
using DigiMenu.Razor.Models.Category;

namespace DigiMenu.Razor.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResult?> CreateCategory(CreateCategoryCommand command)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(command.Title), "title");
            formData.Add(new StreamContent(command.ImageFile.OpenReadStream()), "image");
            formData.Add(new StringContent(command.IsVisible.ToString()), "isVisible");
            formData.Add(new StringContent(command.SeoData?.MetaDescription??""), "seoData.MetaDescription");
            formData.Add(new StringContent(command.SeoData?.MetaTitle ?? ""), "seoData.MetaTitle");
            formData.Add(new StringContent(command.SeoData?.MetaKeywords ?? ""), "seoData.MetaKeywords");
            formData.Add(new StringContent((command.SeoData?.IsIndexed??false).ToString()), "seoData.IsIndexed");
            formData.Add(new StringContent(command.SeoData?.Canonicial ?? ""), "seoData.Canonicial");
            formData.Add(new StringContent(command.SeoData?.Schema ?? ""), "seoData.Schema");

            var result = await _httpClient.PostAsync("category", formData);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult?> DeleteCategory(long categoryId)
        {
            var result = await _httpClient.DeleteAsync($"category/{categoryId}");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult?> EditCategory(EditCategoryCommand command)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(command.Id.ToString()), "id");
            formData.Add(new StringContent(command.Title), "title");
            formData.Add(new StreamContent(command.ImageFile.OpenReadStream()), "image");
            formData.Add(new StringContent(command.IsVisible.ToString()), "isVisible");
            formData.Add(new StringContent(command.SeoData?.MetaDescription ?? ""), "seoData.MetaDescription");
            formData.Add(new StringContent(command.SeoData?.MetaTitle ?? ""), "seoData.MetaTitle");
            formData.Add(new StringContent(command.SeoData?.MetaKeywords ?? ""), "seoData.MetaKeywords");
            formData.Add(new StringContent((command.SeoData?.IsIndexed ?? false).ToString()), "seoData.IsIndexed");
            formData.Add(new StringContent(command.SeoData?.Canonicial ?? ""), "seoData.Canonicial");
            formData.Add(new StringContent(command.SeoData?.Schema ?? ""), "seoData.Schema");
            var result = await _httpClient.PutAsync("category", formData);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<List<CategoryModel>> GetCategories()
        {
            var result = await _httpClient.GetFromJsonAsync<ApiResult<List<CategoryModel>>>("category");
            if (result?.Data == null)
            {
                return new List<CategoryModel>();
            }
            return result.Data;
        }

        public async Task<CategoryModel?> GetCategory(long categoryId)
        {
            var result = await _httpClient.GetFromJsonAsync<ApiResult<CategoryModel>>($"category/{categoryId}");
            return result?.Data;
        }
    }
}
