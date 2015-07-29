using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherConsole
{
    public interface IForecastJsonSerializer
    {
        Forecast UnderstandJSON(string json);
    }
}
