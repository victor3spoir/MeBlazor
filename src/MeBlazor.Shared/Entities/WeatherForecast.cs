using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeBlazor.Shared.Entities
{
    public class WeatherForecast : Entity
    {
        public float TemperatureC { get; set; }
        public float TemperatureF { get; set; }
        public DateOnly Date { get; set; }

        public string Summary { get; set; }
        public static float fromCtoF(float tempC) => 32 + (int)(tempC / 0.5556);


    }
}