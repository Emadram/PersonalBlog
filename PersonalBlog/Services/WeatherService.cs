using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PersonalBlog.Models;

namespace PersonalBlog.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _configuration;
        private readonly ILogger<WeatherService> _logger;
        private readonly string _apiKey;
        private readonly TimeSpan _cacheDuration = TimeSpan.FromMinutes(30); // Cache weather for 30 minutes
        
        private const string CacheKey = "CurrentWeather";
        
        public WeatherService(HttpClient httpClient, IMemoryCache cache, IConfiguration configuration, ILogger<WeatherService> logger)
        {
            _httpClient = httpClient;
            _cache = cache;
            _configuration = configuration;
            _logger = logger;
            
            // Get API key from configuration
            _apiKey = _configuration["Weather:ApiKey"] ?? string.Empty;
            
            // Configure the base URL for Weatherbit.io
            _httpClient.BaseAddress = new Uri("https://api.weatherbit.io/v2.0/");
        }
        
        public async Task<WeatherResponse?> GetCurrentWeatherAsync(string city)
        {
            try
            {
                // Check if weather is already cached
                if (_cache.TryGetValue(CacheKey, out WeatherResponse? cachedWeather))
                {
                    return cachedWeather;
                }
                
                // If API key is not configured, return null
                if (string.IsNullOrEmpty(_apiKey))
                {
                    return null;
                }
                
                // Make API request to Weatherbit.io
                var response = await _httpClient.GetAsync(
                    $"current?city={city}&key={_apiKey}&units=M");
                
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var weatherResponse = JsonSerializer.Deserialize<WeatherResponse>(content);
                    
                    // Cache the weather data
                    if (weatherResponse != null)
                    {
                        _cache.Set(CacheKey, weatherResponse, _cacheDuration);
                    }
                    
                    return weatherResponse;
                }
                
                return null;
            }
            catch (Exception)
            {
                // In case of any error, return null
                return null;
            }
        }
        
        public async Task<WeatherResponse?> GetCurrentWeatherByCoordinatesAsync(double lat, double lon)
        {
            // If both coordinates are 0, use the default location instead
            // This is a fallback for when coordinates aren't available or valid
            if (lat == 0 && lon == 0)
            {
                var defaultLocation = GetDefaultLocation();
                return await GetCurrentWeatherAsync(defaultLocation);
            }
            
            var cacheKey = $"weather_coords_{lat}_{lon}";
            
            // Check if weather is already cached
            if (_cache.TryGetValue(cacheKey, out WeatherResponse? cachedWeather))
            {
                return cachedWeather;
            }
            
            try
            {
                // If API key is not configured, return null
                if (string.IsNullOrEmpty(_apiKey))
                {
                    return null;
                }
                
                // Make API request to Weatherbit.io
                var response = await _httpClient.GetAsync(
                    $"current?lat={lat}&lon={lon}&key={_apiKey}&units=M");
                
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var weatherResponse = JsonSerializer.Deserialize<WeatherResponse>(content);
                    
                    // Cache the weather data
                    if (weatherResponse != null)
                    {
                        _cache.Set(cacheKey, weatherResponse, _cacheDuration);
                    }
                    
                    return weatherResponse;
                }
                
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching weather by coordinates");
                return null;
            }
        }
        
        public WeatherResponse? GetCachedWeather()
        {
            _cache.TryGetValue(CacheKey, out WeatherResponse? cachedWeather);
            return cachedWeather;
        }
        
        public string GetDefaultLocation()
        {
            // First check if the user has set a custom location
            if (_cache.TryGetValue("UserDefaultLocation", out string? userLocation) && !string.IsNullOrEmpty(userLocation))
            {
                return userLocation;
            }
            
            // Fall back to configured default location or London
            return _configuration["Weather:DefaultLocation"] ?? "Tel Aviv";
        }
        
        public void SetDefaultLocation(string location)
        {
            // Store the location in a cache with a very long expiration (pseudo-persistence)
            // In a production app, you'd store this in a database or user preferences
            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(30) // 30 days
            };
            
            _cache.Set("UserDefaultLocation", location, cacheOptions);
            
            // Clear the current weather cache to force a refresh with the new location
            _cache.Remove(CacheKey);
        }
    }
}
