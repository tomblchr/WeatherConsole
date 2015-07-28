using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

using Newtonsoft.Json;

namespace WeatherConsole
{
    public class WeatherService
    {
        private const string url = @"http://gardiner-weather.azurewebsites.net/api/forecast/"; //SA/Adelaide";

        public Forecast GetForecast(string state, string locality)
        {
            string s;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    s = client.GetStringAsync(string.Format(@"{0}/{1}", state, locality)).Result;
                }
                catch (AggregateException e)
                {
                    // We're avoiding using async/await to keep things simple. Unwrap AggregateException and return original exception instead
                    throw e.InnerExceptions.First();
                }
            }

            var serializer = JsonSerializer.Create();
            var forecast = serializer.Deserialize<Forecast>(new JsonTextReader(new StringReader(s)));

            return forecast;
        }


    }
}