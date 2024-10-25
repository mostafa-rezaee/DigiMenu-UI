using DigiMenu.Razor.Infrastructure.CustomValidation;
using DigiMenu.Razor.Infrastructure.RazorPageUtilities;
using DigiMenu.Razor.Services.PageSettings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DigiMenu.Razor.Pages.Admin.PageSettings
{
    [BindProperties]
    public class IndexModel : BaseRazorPage
    {
        private readonly IPageSettingService _pageSettingService;

        public IndexModel(IPageSettingService pageSettingService)
        {
            _pageSettingService = pageSettingService;
        }

        [Display(Name = "عنوان صفحه")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string PageTitle { get; set; }

        [Display(Name = "عکس پس زمینه")]
        [FileImage(ErrorMessage = "عکس نامعتبر است")]
        public IFormFile? BackgroundImageFile { get; set; }

        [Display(Name = "عکس لوگو")]
        [FileImage(ErrorMessage = "عکس نامعتبر است")]
        public IFormFile? LogoImageFile { get; set; }

        [Display(Name = "آدرس وب سایت")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string WebsiteAddress { get; set; }

        [Display(Name = "عنوان شبکه اجتماعی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string SocialTitle { get; set; }

        [Display(Name = "آدرس شبکه اجتماعی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string SocialAddress { get; set; }

        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Telephone { get; set; }

        [Display(Name = "آدرس")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Address { get; set; }

        [TempData]
        public string? PageId { get; set; } = null;

        public async Task OnGet()
        {
            var result = await _pageSettingService.GetPageSetting();
            if (result != null)
            {
                if (!TempData.Any(x => x.Key == "PageId"))
                    TempData.Add("PageId", result.Id.ToString());
                else
                    TempData["PageId"] = result.Id.ToString();
                PageTitle = result.PageTitle;
                WebsiteAddress = result.WebsiteAddress;
                SocialTitle = result.SocialTitle;
                SocialAddress = result.SocialAddress;
                Telephone = result.Telephone;
                Address = result.Address;
            }
        }

        public async Task<IActionResult> OnPost()
        {
            var result = new Models.ApiResult();
            var p = TempData.Peek("PageId");
            if (p == null)
            {
                result = await _pageSettingService.CreatePageSetting(new Models.PageSetting.CreatePageSettingModel
                {
                    PageTitle = PageTitle,
                    WebsiteAddress = WebsiteAddress,
                    SocialTitle = SocialTitle,
                    SocialAddress = SocialAddress,
                    Telephone = Telephone,
                    Address = Address,
                    BackgroundImageFile = BackgroundImageFile,
                    LogoImageFile = LogoImageFile

                });
            }
            else
            {
                result = await _pageSettingService.EditPageSetting(new Models.PageSetting.EditPageSettingModel
                {
                    Id = Convert.ToInt64(PageId),
                    PageTitle = PageTitle,
                    WebsiteAddress = WebsiteAddress,
                    SocialTitle = SocialTitle,
                    SocialAddress = SocialAddress,
                    Telephone = Telephone,
                    Address = Address,
                    BackgroundImageFile = BackgroundImageFile,
                    LogoImageFile = LogoImageFile

                });
            }

            return RedirectAndShowAlert(result, RedirectToPage("/Admin/Index"));
        }
    }
}
