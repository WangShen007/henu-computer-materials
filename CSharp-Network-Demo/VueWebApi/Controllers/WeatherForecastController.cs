using Microsoft.AspNetCore.Mvc;

namespace VueWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing(极冷)",
            "Bracing(清爽)",
            "Chilly(寒冷)",
            "Cool(凉爽)",
            "Mild(温暖)",
            "Warm(有点热)",
            "Balmy(温暖惬意)",
            "Hot(热)",
            "Sweltering(闷热)",
            "Scorching(灼热)"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}