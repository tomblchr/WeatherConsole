using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherConsole
{
    public class JavaScriptSerializerSerializer : IForecastJsonSerializer
    {
        public Forecast UnderstandJSON(string json)
        {
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Deserialize<Forecast>(json);
        }
    }
}
