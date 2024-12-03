using Microsoft.AspNetCore.Authentication.Cookies;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);

// Thiết lập văn hóa là Việt Nam (VND)
var vietnamCulture = new CultureInfo("vi-VN"); // Việt Nam
CultureInfo.DefaultThreadCurrentCulture = vietnamCulture;
CultureInfo.DefaultThreadCurrentUICulture = vietnamCulture;

// Cấu hình tiền tệ (VND)
var currencyCulture = new CultureInfo("vi-VN");
var region = new RegionInfo(currencyCulture.Name);
var currencySymbol = region.CurrencySymbol; // Đơn vị tiền tệ: VND

// Add services to the container.
builder.Services.AddControllersWithViews();

// Cấu hình Authentication với Cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    option.LoginPath = "/Customer/SignIn";
    option.AccessDeniedPath = "/AccessDenied";
});

// Cấu hình Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Thiết lập bộ lọc văn hóa cho ứng dụng
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(vietnamCulture),
    SupportedCultures = new[] { vietnamCulture },
    SupportedUICultures = new[] { vietnamCulture }
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "admin",
    pattern: "{area:exists}/{controller=ProductAdmin}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
