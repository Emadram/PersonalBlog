using PersonalBlog.Models;

namespace PersonalBlog.Services
{
    /// <summary>
    /// Provides functionality for retrieving weather information from Weatherbit.io API.
    /// </summary>
    public interface IWeatherService
    {
        /// <summary>
        /// Gets the current weather for a location by city name.
        /// </summary>
        /// <param name="city">City name (e.g., "London", "New York")</param>
        /// <returns>Weather response containing current conditions.</returns>
        /// <remarks>
        /// Results are cached for 30 minutes to minimize API calls.
        /// </remarks>
        Task<WeatherResponse?> GetCurrentWeatherAsync(string city);
        
        /// <summary>
        /// Gets the current weather for a location using coordinates.
        /// </summary>
        /// <param name="lat">Latitude</param>
        /// <param name="lon">Longitude</param>
        /// <returns>Weather response containing current conditions.</returns>
        /// <remarks>
        /// Results are cached for 30 minutes to minimize API calls.
        /// </remarks>
        Task<WeatherResponse?> GetCurrentWeatherByCoordinatesAsync(double lat, double lon);
        
        /// <summary>
        /// Gets the cached weather response without making a new API request.
        /// </summary>
        /// <returns>The cached weather response or null if not cached.</returns>
        WeatherResponse? GetCachedWeather();
        
        /// <summary>
        /// Gets the default location to use for weather.
        /// </summary>
        /// <returns>The default city name.</returns>
        /// <remarks>
        /// Priority order:
        /// 1. User's custom location if set
        /// 2. Location from configuration
        /// 3. Fallback to "Tel Aviv"
        /// </remarks>
        string GetDefaultLocation();
        
        /// <summary>
        /// Sets the default location to use for weather.
        /// </summary>
        /// <param name="location">City name to use.</param>
        /// <remarks>
        /// The location is stored in cache with a 30-day expiration.
        /// Setting a new location clears the current weather cache.
        /// </remarks>
        void SetDefaultLocation(string location);
    }
}
