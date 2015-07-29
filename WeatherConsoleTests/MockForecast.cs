using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherConsole;

namespace WeatherConsoleTests
{
    class MockForecast : Forecast
    {
        public MockForecast(string state, string locality)
        {
            this.Title = locality;
        }

        public string ToJSON()
        {
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(this);
        }
    }
}
