using Microsoft.EntityFrameworkCore;

namespace MeBlazor.Api.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}