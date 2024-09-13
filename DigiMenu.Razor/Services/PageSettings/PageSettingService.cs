namespace DigiMenu.Razor.Services.PageSettings
{
    public class PageSettingService : IPageSettingService
    {
        private readonly HttpClient _httpClient;

        public PageSettingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
