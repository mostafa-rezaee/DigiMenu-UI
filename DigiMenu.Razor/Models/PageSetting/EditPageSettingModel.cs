namespace DigiMenu.Razor.Models.PageSetting
{
    public class EditPageSettingModel
    {
        public long Id { get; set; }
        public string PageTitle { get; set; }
        public IFormFile BackgroundImageFile { get; set; }
        public IFormFile LogoImageFile { get; set; }
        public string WebsiteAddress { get; set; }
        public string SocialTitle { get; set; }
        public string SocialAddress { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
    }
}
