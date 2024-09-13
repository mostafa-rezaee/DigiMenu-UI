namespace DigiMenu.Razor.Services.Products
{
    public class ProductService :IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
