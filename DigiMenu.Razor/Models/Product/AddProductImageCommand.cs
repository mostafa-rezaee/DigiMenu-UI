namespace DigiMenu.Razor.Models.Product
{
    public class AddProductImageCommand
    {
        public IFormFile ImageFile { get; set; }
        public long ProductId { get; set; }
        public int DisplayOrder { get; set; }
    }
}
