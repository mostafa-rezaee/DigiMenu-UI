namespace DigiMenu.Razor.Models.Category
{
    public class CreateCategoryCommand
    {
        public string Title { get; set; }
        public IFormFile Image { get; set; }

        public bool IsVisible { get; set; }
        public SeoData SeoData { get; set; }
    }
}
