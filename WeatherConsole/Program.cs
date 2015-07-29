using System;
using System.Linq;

namespace WeatherConsole
{
    class Program
    {
        static void Main()
        {
            var provider = new WebForecastProvider();
            var service = new WeatherService(provider);

            var forecast = service.GetForecast("SA", "Adelaide");

            Console.WriteLine(forecast.Items.First().Description);
            Console.ReadLine();
        }
    }
}
