namespace GetWeather.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        static HttpClient client = new HttpClient();
        const string API_KEY = "1faa36d6a3ac4ca0850174030242206";
        const string BaseAddress = ("http://api.weatherapi.com/v1/current.json?key=" + API_KEY);



        //[HttpGet(Name = "GetWeatherForecast")]
        // public IEnumerable<WeatherForecast> Get()
        /// </summary>
        /// <param name="httpClient">http client</param>
        /// <param name="location">string with weather location</param>
        /// <returns>List of weather data</returns>
        [HttpGet(Name = "GetWeatherForecast")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<string> GetWeather([FromQuery] string location)
        {
            var requestUri = BaseAddress + "&q=" + location;
            using HttpResponseMessage response = await client.GetAsync(requestUri);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
