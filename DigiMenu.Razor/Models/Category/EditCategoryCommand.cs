namespace DigiMenu.Razor.Models.Category
{
    public class EditCategoryCommand
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public IFormFile ImageFile { get; set; }

        public bool IsVisible { get; set; }
        public SeoData SeoData { get; set; }
    }
}
