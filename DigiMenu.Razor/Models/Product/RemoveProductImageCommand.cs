namespace DigiMenu.Razor.Models.Product
{
    public class RemoveProductImageCommand
    {
        public long ImageId { get; private set; }
        public long ProductId { get; private set; }
        public int DisplayOrder { get; private set; }
    }
}
