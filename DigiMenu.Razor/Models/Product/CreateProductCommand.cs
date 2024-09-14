namespace DigiMenu.Razor.Models.Product
{
    public class CreateProductCommand
    {
        public string Title { get; set; }
        public long CategoryId { get; set; }
        public IFormFile ImageFile { get; set; }
        public decimal Price { get; set; }
        public int? LikeCount { get; set; }
        public bool? IsVisible { get; set; }
        public string? Description { get; set; }
        public SeoData SeoData { get; set; }
    }
}
