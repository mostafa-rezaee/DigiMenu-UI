namespace DigiMenu.Razor.Models.Product
{
    public class RemoveProductImageCommand
    {
        public long ImageId { get; set; }
        public long ProductId { get; set; }
        public int DisplayOrder { get; set; }
    }
}
