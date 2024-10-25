using DigiMenu.Razor.Services.Authentications;
using DigiMenu.Razor.Services.Categories;
using DigiMenu.Razor.Services.PageSettings;
using DigiMenu.Razor.Services.Products;
using DigiMenu.Razor.Services.Roles;
using DigiMenu.Razor.Services.Users;
using Microsoft.AspNetCore.Identity;

namespace DigiMenu.Razor.Infrastructure
{
    public static class RegisterServices
    {
        public static IServiceCollection RegisterApiServices(this IServiceCollection services)
        {
            var baseAddress = $"{ServerSettings.ServerPath}/api/";

            services.AddHttpContextAccessor();
            services.AddScoped<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IAuthenticationService, AuthenticationService>(httpClient => {
                httpClient.BaseAddress = new Uri(baseAddress);
            }).AddHttpMessageHandler< HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<ICategoryService, CategoryService>(httpClient => {
                httpClient.BaseAddress = new Uri(baseAddress);
            }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IPageSettingService, PageSettingService>(httpClient => {
                httpClient.BaseAddress = new Uri(baseAddress);
            }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IProductService, ProductService>(httpClient => {
                httpClient.BaseAddress = new Uri(baseAddress);
            }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IRoleService, RoleService>(httpClient => {
                httpClient.BaseAddress = new Uri(baseAddress);
            }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IUserService, UserService>(httpClient => {
                httpClient.BaseAddress = new Uri(baseAddress);
            }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            return services;
        }

        public static async Task AssignRolesToUser(this IServiceProvider serviceProvider)
        {

        }



    }
}
