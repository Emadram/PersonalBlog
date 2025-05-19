using PersonalBlog.Models;

namespace PersonalBlog.Services
{
    public interface IWeatherService
    {
        /// <summary>
        /// Gets the current weather for a location by city name
        /// </summary>
        /// <param name="city">City name (e.g., "London", "New York")</param>
        /// <returns>Weather response containing current conditions</returns>
        Task<WeatherResponse?> GetCurrentWeatherAsync(string city);
        
        /// <summary>
        /// Gets the current weather for a location using coordinates
        /// </summary>
        /// <param name="lat">Latitude</param>
        /// <param name="lon">Longitude</param>
        /// <returns>Weather response containing current conditions</returns>
        Task<WeatherResponse?> GetCurrentWeatherByCoordinatesAsync(double lat, double lon);
        
        /// <summary>
        /// Gets the cached weather response without making a new API request
        /// </summary>
        /// <returns>The cached weather response or null if not cached</returns>
        WeatherResponse? GetCachedWeather();
        
        /// <summary>
        /// Gets the default location to use for weather
        /// </summary>
        /// <returns>The default city name</returns>
        string GetDefaultLocation();
        
        /// <summary>
        /// Sets the default location to use for weather
        /// </summary>
        /// <param name="location">City name to use</param>
        void SetDefaultLocation(string location);
    }
}
