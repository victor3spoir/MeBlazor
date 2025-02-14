using Bogus;
using MeBlazor.Api.Data;
using MeBlazor.Api.Extensions;
using MeBlazor.Api.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;


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
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

}

var connectionString = config["DB_CONNECTION_STRING"]
?? throw new OperationException("Provided db connectionString");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(connectionString);

    if (builder.Environment.IsDevelopment())
    {
        options.UseSeeding((ctx, _) =>
        {
            var weatherSet = ctx.Set<WeatherForecast>();
            if (weatherSet.Count() <= 0)
            {
                var summaries = new[]{
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
                var faker = new Faker<WeatherForecast>()
                .RuleFor(o => o.Summary, f => f.PickRandom(summaries))
                .RuleFor(o => o.TemperatureC, f => new Random().Next(0, 60))
                .RuleFor(o => o.TemperatureF, f => new Random().Next(0, 60))
                // .RuleFor(o => o.TemperatureF, (f, e) => 32 + (e.TemperatureC / 0.5556))
                .RuleFor(o => o.Date, f => f.Date.FutureDateOnly());

                ctx.AddRange(faker.Generate(20));
                ctx.SaveChanges();
            }
        });
    }

});

builder.Services.AddScoped<ICommonRepo<TaskItem>, CommonRepo<TaskItem>>();
builder.Services.AddScoped<ICommonRepo<WeatherForecast>, CommonRepo<WeatherForecast>>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();

    // try
    // {
    //     using var scope = app.Services.CreateScope();
    //     await using var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    //     dbContext.Database.EnsureCreated();
    //     dbContext.Database.Migrate();
    // }
    // catch (PostgresException ex) { app.Logger.LogWarning("already migrated {ex}", ex); }
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

