using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherConsole
{
    public class JsonTextReaderReader : IForecastJsonSerializer
    {
        public Forecast UnderstandJSON(string json)
        {
            var serializer = JsonSerializer.Create();
            return serializer.Deserialize<Forecast>(new JsonTextReader(new StringReader(json)));
        }
    }
}
