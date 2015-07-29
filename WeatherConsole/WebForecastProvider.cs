using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WeatherConsole
{
    class WebForecastProvider : IForecastProvider
    {
        private const string Url = @"http://gardiner-weather.azurewebsites.net/api/forecast/"; //SA/Adelaide";
        
        public string Load(string state, string locality)
        {
            string result;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    result = client.GetStringAsync(string.Format(@"{0}/{1}", state, locality)).Result;
                }
                catch (AggregateException e)
                {
                    // We're avoiding using async/await to keep things simple. Unwrap AggregateException and return original exception instead
                    throw e.InnerExceptions.First();
                }
            }
            return result;
        }
    }
}
