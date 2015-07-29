using System.Net.Http;
using WeatherConsole;

namespace WeatherConsoleTests
{
    public class MockForecastProvider : IForecastProvider
    {
        public string Load(string state, string locality)
        {
            if (locality != "Adelaide")
            {
                throw new HttpRequestException();            
            }
            return 
@"{
  ""title"": ""Adelaide"",
  ""lastUpdated"": ""2015-07-28T19:45:15+00:00"",
  ""items"": [
    {
      ""urlId"": 0,
      ""address"": null,
      ""title"": null,
      ""description"": ""<b>Wednesday 29</b><br/>Partly cloudy.\nMax 14<br/><br/><b>Thursday 30</b><br/>Shower or two.\n8-15<br/><br/><b>Friday 31</b><br/>Possible late shower.\n5-14<br/><br/><b>Saturday 1</b><br/>Possible shower.\n7-14<br/><br/><b>Sunday 2</b><br/>Possible shower.\n7-13<br/><br/><b>Monday 3</b><br/>Possible shower.\n6-13<br/><br/><b>Tuesday 4</b><br/>Possible shower.\n6-14<br/><br/>"",
      ""createdAt"": null
    }
  ],
  ""validUntil"": ""2015-07-29T06:30:00+00:00""
}";
        }
    }
}
