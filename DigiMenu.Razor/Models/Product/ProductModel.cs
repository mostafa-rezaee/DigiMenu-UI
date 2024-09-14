using DigiMenu.Razor.Models.Category;

namespace DigiMenu.Razor.Models.Product
{
    public class ProductModel : BaseModel
    {
        public string Title { get; set; }
        public long CategoryId { get; set; }
        public string ImageName { get; set; }
        public decimal Price { get; set; }
        public int? LikeCount { get; set; }
        public bool? IsVisible { get; set; }
        public string? Description { get; set; }
        public SeoData SeoData { get; set; }
        public CategoryModel Category { get; set; }
        public List<ProductImageModel> ProductImages { get; set; }
    }
}
