using NUnit.Framework;
using GetWeather.Controllers;

namespace GetWeather.Controllers.Tests
{
    [TestFixture]
    public class WeatherForecastControllerTests
    {
        [Test]
        public void GetWeatherTest_ReturnsDataWithValidLocation()
        {
            var location = "Manchester";
            var controller = new WeatherForecastController();

            var result = controller.GetWeather(location);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Result.Contains(location));
        }

        [Test]
        public void GetWeatherTest_ReturnsErrorWithNoLocation()
        {
            var controller = new WeatherForecastController();

            var result = controller.GetWeather("");

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Result.Contains("Parameter q is missing"));
        }
    }
}