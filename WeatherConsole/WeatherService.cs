using System;
using System.IO;
using Newtonsoft.Json;

namespace WeatherConsole
{
    public class WeatherService
    {
        private readonly IForecastProvider _forecastProvider;
        private readonly IForecastJsonSerializer _jsonSerializer;

        public WeatherService() 
            : this(new WebForecastProvider(), new JsonTextReaderReader())
        {

        }

        public WeatherService(IForecastProvider forecastProvider) 
            : this(forecastProvider, new JsonTextReaderReader())
        {

        }

        public WeatherService(IForecastProvider forecastProvider, IForecastJsonSerializer serializer)
        {
            _forecastProvider = forecastProvider;
            _jsonSerializer = serializer;
        }

        public Forecast GetForecast(string state, string locality)
        {
            return _jsonSerializer.UnderstandJSON(_forecastProvider.Load(state, locality));
        }
    }
}