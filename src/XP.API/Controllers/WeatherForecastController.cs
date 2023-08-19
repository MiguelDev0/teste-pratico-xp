using Microsoft.AspNetCore.Mvc;

namespace XP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public string helloWorld()
        {
            return "Teste de fumaça";
        }
    }
}