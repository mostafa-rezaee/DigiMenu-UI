using DigiMenu.Razor.Infrastructure;
using DigiMenu.Razor.Services.Authentications;
using DigiMenu.Razor.Services.Categories;
using DigiMenu.Razor.Services.PageSettings;
using DigiMenu.Razor.Services.Products;
using DigiMenu.Razor.Services.Roles;
using DigiMenu.Razor.Services.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.RegisterApiServices();
builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("Account", builder =>
    {
        builder.RequireAuthenticatedUser();
    });
});

builder.Services.AddRazorPages().AddRazorRuntimeCompilation().AddRazorPagesOptions(options =>
{
    options.Conventions.AuthorizeFolder("/Profile", "Account");
});

builder.Services.AddAuthentication(b => {
    b.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    b.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    b.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(jwt => {
    jwt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters {
        IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:SignInKey"] ?? "")),
        ValidIssuer = builder.Configuration["JwtConfig:Issuer"],
        ValidAudience = builder.Configuration["JwtConfig:Audience"],
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.Use(async (context, next) =>
{
    var token = context.Request.Cookies["token"]?.ToString();
    if (!string.IsNullOrWhiteSpace(token))
    {
        context.Request.Headers.Append("Authorization", $"Bearer {token}");
    }
    await next();
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.Use(async (context, next) => {
    await next();
    var status = context.Response.StatusCode;
    if (status == 401)
    {
        var requestPath = context.Request.Path;
        context.Response.Redirect($"/account/login?redirectTo={requestPath}");
    }
});

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
