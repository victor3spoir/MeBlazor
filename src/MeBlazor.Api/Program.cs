using MeBlazor.Api;
using MeBlazor.Api.Data;
using MeBlazor.Api.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// CORS
var allowedUrls = builder.Configuration["ALLOWED_URLS"] ?? "";
builder.Services.AddCors(options =>
{
    options.AddPolicy("addApi", policy =>
    {
        policy.WithOrigins(allowedUrls!.Split(";"));
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
        policy.AllowCredentials();
    });
});

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite("Data Source=./sqlite.db");

});

builder.Services.AddScoped<IDbStore, DbStore>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (args.ToList().Contains("--RunMigrations"))
{
    using var scope = app.Services.CreateScope();
    await using var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await dbContext.Database.MigrateAsync();
}

// app.UseCors("addApi");
app.UseHttpsRedirection();
app.MapWeatherForecastRoute();
app.MapTasksRoutes();


app.Run();

