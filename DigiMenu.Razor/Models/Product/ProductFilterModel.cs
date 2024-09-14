namespace DigiMenu.Razor.Models.Product
{
    public class ProductFilterModel : BaseModel
    {
        public string Title { get; set; }
        public string ImageName { get; set; }
        public decimal Price { get; set; }
        public int? LikeCount { get; set; }
        public string? Description { get; set; }
    }

    public class ProductFilterParams : BaseFilterParam
    {
        public string? Title { get; set; }
        public long? CategoryId { get; set; }
    }

    public class ProductFilterResult : BaseFilter<ProductFilterModel, ProductFilterParams>
    {

    }
}
