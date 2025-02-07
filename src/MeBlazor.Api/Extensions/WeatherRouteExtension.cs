using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeBlazor.Api.Extensions
{
    public static class WeatherRouteExtension
    {
        public static WebApplication MapWeatherForecastRoute(this WebApplication app)
        {
            var summaries = new[]{
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
            var group = app.MapGroup("/weatherforecast")
            .WithTags("weatherforecast");
            group.MapGet("/", () =>
            {
                var forecast = Enumerable.Range(1, 20).Select(index =>
                    new WeatherForecast
                    (
                        DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        Random.Shared.Next(-20, 55),
                        summaries[Random.Shared.Next(summaries.Length)]
                    ))
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast");
            return app;
        }
    }
}