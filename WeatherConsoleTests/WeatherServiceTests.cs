using System.Linq;
using System.Net.Http;

using NUnit.Framework;
using WeatherConsole;

namespace WeatherConsoleTests
{
    [TestFixture]
    public class WeatherServiceTests
    {
        [Test]
        public void Forecast_For_Adelaide_Returns_Result()
        {
            // Arrange
            var mock = new MockForecastProvider();
            var sut = new WeatherService(mock);

            // Act
            var result = sut.GetForecast("SA", "Adelaide");

            // Assert
            Assert.That(result.Items.First().Description
                .StartsWith(@"<b>Wednesday 29</b><br/>Partly cloudy."), "Forecast is incorrect");
        }

        [Test]
        public void Forecast_For_Timbuktu_Returns_Error()
        {
            // Arrange
            var mock = new MockForecastProvider();
            var sut = new WeatherService(mock);

            // Act
            Assert.Throws<HttpRequestException>(() => sut.GetForecast("SA", "Timbuktu"));
        }

        [Test]
        public void Serializer1_Returns_Expected()
        {
            var mock = new MockForecast("", "Adelaide");
            var reader = new JsonTextReaderReader();

            var result = reader.UnderstandJSON(mock.ToJSON());
            Assert.AreEqual(mock.Title, result.Title);

            var reader2 = new JavaScriptSerializerSerializer();
            result = reader.UnderstandJSON(mock.ToJSON());
        }

        [Test]
        public void Serializer2_Returns_Expected()
        {
            var mock = new MockForecast("", "Adelaide");
            var reader = new JavaScriptSerializerSerializer();

            var result = reader.UnderstandJSON(mock.ToJSON());
            Assert.AreEqual(mock.Title, result.Title);
        }
    }
}