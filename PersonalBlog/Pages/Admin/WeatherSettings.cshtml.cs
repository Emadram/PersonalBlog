using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Services;

namespace PersonalBlog.Pages.Admin
{
    [Authorize(Policy = "AdminOnly")]
    public class WeatherSettingsModel : PageModel
    {
        private readonly IWeatherService _weatherService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<WeatherSettingsModel> _logger;
        
        [BindProperty]
        public string DefaultLocation { get; set; }
        
        [BindProperty] 
        public string ApiKey { get; set; }
        
        [TempData]
        public string? SuccessMessage { get; set; }
        
        [TempData]
        public string? ErrorMessage { get; set; }
        
        public WeatherSettingsModel(
            IWeatherService weatherService, 
            IConfiguration configuration, 
            ILogger<WeatherSettingsModel> logger)
        {
            _weatherService = weatherService;
            _configuration = configuration;
            _logger = logger;
            
            // Get current values
            DefaultLocation = _weatherService.GetDefaultLocation();
            ApiKey = _configuration["Weather:ApiKey"] ?? string.Empty;
        }
        
        public void OnGet()
        {
            // Values already set in constructor
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Please check your inputs and try again.";
                return Page();
            }
            
            try
            {
                // For demonstration purposes only
                // In a real-world scenario, you would:
                // 1. Update configuration in database or settings file
                // 2. Update appsettings.json file on disk (not recommended in production)
                // 3. Use a proper settings management system
                
                // Here we just set the default location in the weather service
                _weatherService.SetDefaultLocation(DefaultLocation);
                
                // Test the location to make sure it works
                var weather = await _weatherService.GetCurrentWeatherAsync(DefaultLocation);
                
                if (weather == null)
                {
                    ModelState.AddModelError("DefaultLocation", "Could not retrieve weather data for this location.");
                    ErrorMessage = "Invalid location. Please enter a valid city name.";
                    return Page();
                }
                
                SuccessMessage = "Weather settings updated successfully!";
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating weather settings");
                ErrorMessage = "An error occurred while updating weather settings.";
                return Page();
            }
        }
    }
}
