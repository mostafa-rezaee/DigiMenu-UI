using DigiMenu.Razor.Infrastructure;
using DigiMenu.Razor.Services.Authentications;
using DigiMenu.Razor.Services.Categories;
using DigiMenu.Razor.Services.PageSettings;
using DigiMenu.Razor.Services.Products;
using DigiMenu.Razor.Services.Roles;
using DigiMenu.Razor.Services.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.RegisterApiServices();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
