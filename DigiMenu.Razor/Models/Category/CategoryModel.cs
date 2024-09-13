namespace DigiMenu.Razor.Models.Category
{
    public class CategoryModel : BaseModel
    {
        public string Title { get; set; }
        public string ImageName { get; set; }

        public bool IsVisible { get; }
        public SeoData SeoData { get; set; }
    }
}
