using MeBlazor.Web.Components;
using MeBlazor.Web.Extensions;
using MeBlazor.Web.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.FluentUI.AspNetCore.Components;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddAntiforgery();
builder.Services.AddAuthentication(o =>
{
    o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).
AddCookie(o =>
{
    o.LoginPath = "/account/login";
    o.Cookie.HttpOnly = true;
    o.Cookie.SameSite = SameSiteMode.Strict;
});
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddFluentUIComponents();
builder.Services.AddDataGridODataAdapter();


builder.Services.AddHttpClient("weather-api", o =>
{
    var baseAddress = config["API_ENDPOINT"]!;
    o.BaseAddress = new Uri(baseAddress);
});

builder.Services.AddSingleton<AuthService>(new AuthService());
builder.Services.AddScoped<MyStateService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();
app.UseAuthentication()
    .UseAuthorization();

app.MapAuthenticationRoutes();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
