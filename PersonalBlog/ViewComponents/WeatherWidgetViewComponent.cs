using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.ViewComponents
{
    public class WeatherWidgetViewComponent : ViewComponent
    {
        private readonly IWeatherService _weatherService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<WeatherWidgetViewComponent> _logger;
        
        public WeatherWidgetViewComponent(
            IWeatherService weatherService, 
            IConfiguration configuration,
            ILogger<WeatherWidgetViewComponent> logger)
        {
            _weatherService = weatherService;
            _configuration = configuration;
            _logger = logger;
        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                // Check if weather API is configured
                var apiKey = _configuration["Weather:ApiKey"];
                if (string.IsNullOrEmpty(apiKey) || apiKey == "YOUR_OPENWEATHERMAP_API_KEY")
                {
                    _logger.LogWarning("Weather API key is not configured properly.");
                    return View<WeatherResponse>("~/Views/Shared/Components/WeatherWidget/Default.cshtml", null); // Return null to show the fallback UI
                }
                
                // Try to get cached weather first
                var weather = _weatherService.GetCachedWeather();
                
                // If not cached, fetch new weather data
                if (weather == null)
                {
                    var defaultLocation = _weatherService.GetDefaultLocation();
                    weather = await _weatherService.GetCurrentWeatherAsync(defaultLocation);
                }
                
                return View<WeatherResponse>("~/Views/Shared/Components/WeatherWidget/Default.cshtml", weather);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving weather data");
                return View<WeatherResponse>("~/Views/Shared/Components/WeatherWidget/Default.cshtml", null); // Return null to show the fallback UI
            }
        }
    }
}
