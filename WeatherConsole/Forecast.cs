using System;
using System.Collections.Generic;

namespace WeatherConsole
{
    public class Forecast
    {
        public string Title { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
        public DateTimeOffset ValidUntil { get; set; }
        public IList<ForecastItem> Items { get; set; }
    }
}