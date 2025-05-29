using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApplication1.Classes;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
         
        private readonly AppSettings _appSettings1;
        private readonly AppSettings _appSettings2;
        private readonly AppSettings _appSettings3;
        public WeatherForecastController(ILogger<WeatherForecastController> logger,
           
            IOptions<AppSettings> appSettings1,
            IOptionsSnapshot<AppSettings> appSettings2,
            IOptionsMonitor<AppSettings> appSettings3

            )
        {
            _logger = logger;
            
            _appSettings1 = appSettings1.Value;
            _appSettings2 = appSettings2.Value;
            _appSettings3 = appSettings3.CurrentValue;
        }
        [HttpGet("settings11")]
        public IActionResult GetSettings()
        {
            return Ok(new
            {
                MySetting1 = _appSettings1.MySetting1,
                MySetting2 = _appSettings1.MySetting2,
                MySetting3 = _appSettings1.MySetting3,
                MySetting4 = _appSettings2.MySetting1,
                MySetting5 = _appSettings2.MySetting2,
                MySetting6 = _appSettings2.MySetting3,
                MySetting7 = _appSettings3.MySetting1,
                MySetting8 = _appSettings3.MySetting2,
                MySetting9 = _appSettings3.MySetting3,

            }
            );
        }
        
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

     
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
