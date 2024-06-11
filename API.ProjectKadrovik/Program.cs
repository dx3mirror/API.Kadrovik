using API.ProjectKadrovik.ClaimRule;
using API.ProjectKadrovik.ClaimRule.Interface;
using Infrastructure.Mapper;
using Infrastructure.Repository;
using Infrastructure.Repository.Interface;
using Infrastructure.Service;
using Infrastructure.Service.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<UserMappingProfile>());
builder.Services.AddScoped<IAutorizationUser, AutorizationUsers>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IFailedLoginAttempt, FailedLoginAttempt>();
builder.Services.AddScoped<ISignInDefault, SignInDefault>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "YourAppAuthCookie";
        options.LoginPath = "/Login/Index"; // Путь к странице логина
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
app.UseSession();

// Настройка авторизации и аутентификации
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
