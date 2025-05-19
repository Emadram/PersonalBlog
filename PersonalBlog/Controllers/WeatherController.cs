using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        
        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        
        [HttpGet("coordinates")]
        public async Task<IActionResult> GetWeatherByCoordinates([FromQuery] double lat, [FromQuery] double lon)
        {
            try
            {
                var weather = await _weatherService.GetCurrentWeatherByCoordinatesAsync(lat, lon);
                
                if (weather == null)
                {
                    return NotFound(new { success = false, message = "Weather data not found for these coordinates" });
                }
                
                return Ok(new { success = true, data = weather });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }
        
        [HttpGet("refresh")]
        public async Task<IActionResult> RefreshWeather()
        {
            try
            {
                var location = _weatherService.GetDefaultLocation();
                var weather = await _weatherService.GetCurrentWeatherAsync(location);
                
                if (weather == null)
                {
                    return NotFound(new { success = false, message = "Weather data could not be refreshed" });
                }
                
                return Ok(new { success = true, data = weather });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }
        
        [HttpGet("location/{city}")]
        public async Task<IActionResult> GetWeatherByCity(string city)
        {
            try
            {
                var weather = await _weatherService.GetCurrentWeatherAsync(city);
                
                if (weather == null)
                {
                    return NotFound(new { success = false, message = $"Weather data not found for {city}" });
                }
                
                return Ok(new { success = true, data = weather });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }
        
        [HttpPost("setDefaultLocation")]
        public IActionResult SetDefaultLocation([FromBody] DefaultLocationRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Location))
                {
                    return BadRequest(new { success = false, message = "Location cannot be empty" });
                }
                
                _weatherService.SetDefaultLocation(request.Location);
                return Ok(new { success = true, message = $"Default location set to {request.Location}" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }
    }
    
    public class DefaultLocationRequest
    {
        public string Location { get; set; } = string.Empty;
    }
}
