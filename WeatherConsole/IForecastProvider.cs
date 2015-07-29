namespace WeatherConsole
{
    public interface IForecastProvider
    {
        string Load(string state, string locality);
    }
}
