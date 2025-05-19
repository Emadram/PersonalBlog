using System.Text.Json.Serialization;

namespace PersonalBlog.Models
{
    public class WeatherResponse
    {
        // Weatherbit.io returns data in a "data" array, with usually one item for current weather
        [JsonPropertyName("data")]
        public List<WeatherData> Data { get; set; } = new List<WeatherData>();
        
        // These helper properties maintain compatibility with our UI
        public WeatherData CurrentWeather => Data.FirstOrDefault() ?? new WeatherData();
        
        // Compatibility properties to match our existing UI
        public List<WeatherCondition> Weather => new List<WeatherCondition> { CurrentWeather.Weather };
        public string Name => CurrentWeather.CityName;
        public MainWeatherData Main => new MainWeatherData 
        { 
            Temperature = CurrentWeather.Temp ?? 0,
            FeelsLike = CurrentWeather.AppTemp ?? 0,
            Humidity = Convert.ToInt32(CurrentWeather.Rh ?? 0)
        };
        public Sys Sys => new Sys { Country = CurrentWeather.CountryCode };
        
        // Helper properties for the weather widget
        public string Description => CurrentWeather.Weather?.Description ?? "Unknown";
        public string Icon => CurrentWeather.Weather?.Icon ?? "c01d";
        public string FormattedTemperature => $"{Math.Round(CurrentWeather.Temp ?? 0)}°C";
        
        // Get a Font Awesome icon for the weather widget
        public string GetFontAwesomeIcon() => CurrentWeather.Weather?.GetFontAwesomeIcon() ?? "fas fa-cloud";
    }

    public class WeatherData
    {
        [JsonPropertyName("city_name")]
        public string CityName { get; set; } = string.Empty;
        
        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; } = string.Empty;
        
        [JsonPropertyName("lat")]
        public double Lat { get; set; }
        
        [JsonPropertyName("lon")]
        public double Lon { get; set; }
        
        [JsonPropertyName("temp")]
        public double? Temp { get; set; }
        
        [JsonPropertyName("app_temp")]
        public double? AppTemp { get; set; }
        
        [JsonPropertyName("rh")]
        public double? Rh { get; set; } // Relative humidity
        
        [JsonPropertyName("wind_spd")]
        public double? WindSpeed { get; set; }
        
        [JsonPropertyName("wind_dir")]
        public double? WindDir { get; set; }
        
        [JsonPropertyName("clouds")]
        public double? Clouds { get; set; }
        
        [JsonPropertyName("uv")]
        public double? Uv { get; set; }
        
        [JsonPropertyName("ob_time")]
        public string ObTime { get; set; } = string.Empty;
        
        [JsonPropertyName("weather")]
        public WeatherCondition Weather { get; set; } = new WeatherCondition();
    }

    public class WeatherCondition
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }
        
        [JsonPropertyName("icon")]
        public string Icon { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
        
        // Default property to maintain compatibility with existing code
        public string Main => Description;

        // Returns the appropriate Font Awesome icon based on the Weatherbit icon code
        public string GetFontAwesomeIcon()
        {
            return Icon switch
            {
                "c01d" => "fas fa-sun", // Clear sky day
                "c01n" => "fas fa-moon", // Clear sky night
                "c02d" => "fas fa-cloud-sun", // Few clouds day
                "c02n" => "fas fa-cloud-moon", // Few clouds night
                "c03d" or "c03n" => "fas fa-cloud", // Scattered clouds
                "c04d" or "c04n" => "fas fa-cloud", // Broken clouds
                "r01d" or "r01n" or "r02d" or "r02n" => "fas fa-cloud-rain", // Light/moderate rain
                "r03d" or "r03n" => "fas fa-cloud-showers-heavy", // Heavy rain
                "f01d" or "f01n" => "fas fa-smog", // Freezing rain
                "r04d" or "r04n" => "fas fa-cloud-rain", // Light rain shower
                "r05d" or "r05n" => "fas fa-cloud-showers-heavy", // Heavy rain shower
                "r06d" or "r06n" => "fas fa-cloud-rain", // Mixed rain/snow
                "s01d" or "s01n" or "s02d" or "s02n" => "fas fa-snowflake", // Light/moderate snow
                "s03d" or "s03n" => "fas fa-snowflake", // Heavy snow
                "s04d" or "s04n" => "fas fa-snowflake", // Snow shower
                "s05d" or "s05n" => "fas fa-snowflake", // Flurries
                "s06d" or "s06n" => "fas fa-snowflake", // Mixed snow/rain
                "a01d" or "a01n" or "a02d" or "a02n" => "fas fa-smog", // Mist/fog
                "a03d" or "a03n" => "fas fa-smog", // Sand/dust
                "a04d" or "a04n" => "fas fa-smog", // Smoke
                "a05d" or "a05n" => "fas fa-smog", // Haze
                "a06d" or "a06n" => "fas fa-smog", // Dust
                "t01d" or "t01n" or "t02d" or "t02n" => "fas fa-bolt", // Thunderstorm
                "t03d" or "t03n" => "fas fa-bolt", // Thunderstorm with light rain
                "t04d" or "t04n" => "fas fa-bolt", // Thunderstorm with rain
                "t05d" or "t05n" => "fas fa-bolt", // Thunderstorm with heavy rain
                "d01d" or "d01n" or "d02d" or "d02n" or "d03d" or "d03n" => "fas fa-wind", // Drizzle
                "u00d" or "u00n" => "fas fa-question", // Unknown Precipitation
                _ => "fas fa-cloud" // Default
            };
        }
    }

    public class MainWeatherData
    {
        [JsonPropertyName("temp")]
        public double Temperature { get; set; }

        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }

        [JsonPropertyName("temp_min")]
        public double TempMin { get; set; }

        [JsonPropertyName("temp_max")]
        public double TempMax { get; set; }

        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        // Helper property to get rounded temperature in Celsius
        public int TemperatureC => (int)Math.Round(Temperature);
    }

    public class Wind
    {
        [JsonPropertyName("speed")]
        public double Speed { get; set; }

        [JsonPropertyName("deg")]
        public int Deg { get; set; }

        [JsonPropertyName("gust")]
        public double Gust { get; set; }
    }

    public class Clouds
    {
        [JsonPropertyName("all")]
        public int All { get; set; }
    }

    public class Sys
    {
        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("sunrise")]
        public long Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public long Sunset { get; set; }
    }
}
