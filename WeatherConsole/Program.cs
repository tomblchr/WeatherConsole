using System;
using System.Linq;

namespace WeatherConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new WeatherService();

            var forecast = service.GetForecast("SA", "Adelaide");

            Console.WriteLine(forecast.Items.First().Description);
            Console.ReadLine();
        }
    }
}
