using System.IO;
using Newtonsoft.Json;

namespace WeatherConsole
{
    public class WeatherService
    {
        private readonly IForecastProvider _forecastProvider;

        public WeatherService(IForecastProvider forecastProvider)
        {
            _forecastProvider = forecastProvider;
        }

        public Forecast GetForecast(string state, string locality)
        {
            var result = _forecastProvider.Load(state, locality);
            var serializer = JsonSerializer.Create();
            var forecast = serializer
                .Deserialize<Forecast>(new JsonTextReader(new StringReader(result)));
            return forecast;

        }
    }
}