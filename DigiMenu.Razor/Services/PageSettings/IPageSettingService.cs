using DigiMenu.Razor.Models;
using DigiMenu.Razor.Models.PageSetting;

namespace DigiMenu.Razor.Services.PageSettings
{
    public interface IPageSettingService
    {
        Task<ApiResult?> CreatePageSetting(CreatePageSettingModel model);
        Task<ApiResult?> EditPageSetting(EditPageSettingModel model);
        Task<PageSettingModel?> GetPageSetting();
    }
}
