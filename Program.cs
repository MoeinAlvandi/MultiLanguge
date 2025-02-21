using Microsoft.AspNetCore.Localization;
using System.Globalization;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddLocalization(option =>
{
    option.ResourcesPath = "Resources";
});
// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddViewLocalization();

builder.Services.Configure<RequestLocalizationOptions>(option =>
{
    

    var cultures = new CultureInfo[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("fa-IR")

    };

    option.SupportedCultures = cultures;
    option.SupportedUICultures = cultures;
    option.DefaultRequestCulture = new RequestCulture("en-US");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseRequestLocalization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
