using DigiMenu.Razor.Services.Authentications;
using DigiMenu.Razor.Services.Categories;
using DigiMenu.Razor.Services.PageSettings;
using DigiMenu.Razor.Services.Products;
using DigiMenu.Razor.Services.Roles;
using DigiMenu.Razor.Services.Users;

namespace DigiMenu.Razor.Infrastructure
{
    public static class RegisterServices
    {
        public static IServiceCollection RegisterApiServices(this IServiceCollection services)
        {
            var baseAddress = "https://localhost:44357/api/";
            services.AddHttpClient<IAuthenticationService, AuthenticationService>(httpClient => {
                httpClient.BaseAddress = new Uri(baseAddress);
            });

            services.AddHttpClient<ICategoryService, CategoryService>(httpClient => {
                httpClient.BaseAddress = new Uri(baseAddress);
            });

            services.AddHttpClient<IPageSettingService, PageSettingService>(httpClient => {
                httpClient.BaseAddress = new Uri(baseAddress);
            });

            services.AddHttpClient<IProductService, ProductService>(httpClient => {
                httpClient.BaseAddress = new Uri(baseAddress);
            });

            services.AddHttpClient<IRoleService, RoleService>(httpClient => {
                httpClient.BaseAddress = new Uri(baseAddress);
            });

            services.AddHttpClient<IUserService, UserService>(httpClient => {
                httpClient.BaseAddress = new Uri(baseAddress);
            });

            return services;
        }
    }
}
