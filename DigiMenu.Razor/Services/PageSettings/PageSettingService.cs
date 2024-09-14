using DigiMenu.Razor.Models;
using DigiMenu.Razor.Models.PageSetting;

namespace DigiMenu.Razor.Services.PageSettings
{
    public class PageSettingService : IPageSettingService
    {
        private readonly HttpClient _httpClient;

        public PageSettingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResult?> CreatePageSetting(CreatePageSettingModel model)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(model.PageTitle), "pageTitle");
            formData.Add(new StreamContent(model.BackgroundImageFile.OpenReadStream()), "backgroundImage");
            formData.Add(new StreamContent(model.LogoImageFile.OpenReadStream()), "logoImage");
            formData.Add(new StringContent(model.WebsiteAddress), "websiteAddress");
            formData.Add(new StringContent(model.SocialTitle), "socialTitle");
            formData.Add(new StringContent(model.SocialAddress), "socialAddress");
            formData.Add(new StringContent(model.Telephone), "telephone");
            formData.Add(new StringContent(model.Address), "address");

            var result = await _httpClient.PostAsync("pagesetting", formData);
            return await result.Content.ReadFromJsonAsync<ApiResult>();

        }

        public async Task<ApiResult?> EditPageSetting(EditPageSettingModel model)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(model.Id.ToString()), "id");
            formData.Add(new StringContent(model.PageTitle), "pageTitle");
            formData.Add(new StreamContent(model.BackgroundImageFile.OpenReadStream()), "backgroundImage");
            formData.Add(new StreamContent(model.LogoImageFile.OpenReadStream()), "logoImage");
            formData.Add(new StringContent(model.WebsiteAddress), "websiteAddress");
            formData.Add(new StringContent(model.SocialTitle), "socialTitle");
            formData.Add(new StringContent(model.SocialAddress), "socialAddress");
            formData.Add(new StringContent(model.Telephone), "telephone");
            formData.Add(new StringContent(model.Address), "address");

            var result = await _httpClient.PutAsync("pagesetting", formData);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<PageSettingModel?> GetPageSetting()
        {
            var result = await _httpClient.GetFromJsonAsync<ApiResult<PageSettingModel>>("pagesetting");
            return result?.Data;
        }
    }
}
