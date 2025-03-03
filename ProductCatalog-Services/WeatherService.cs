using ProductCatalog_Services.Contracts;
using ProductCatolog_Core.Models;
using System;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace ProductCatalog_Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "d2ea8afe48cf68f825420f9d8c8b89e0";
        private const string BaseUrl = "https://api.openweathermap.org/data/2.5/weather";

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherResponse> GetWeatherAsync(string city)
        {
            try
            {
                // Eğer şehir adı boşsa, varsayılan olarak "Istanbul" kullan
                if (string.IsNullOrWhiteSpace(city))
                {
                    city = "Istanbul";
                }

                string url = $"{BaseUrl}?q={city}&appid={ApiKey}&units=metric";
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Weather API Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                    return null;
                }

                var jsonString = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Weather API Response: {jsonString}"); // Loglama

                var json = JsonNode.Parse(jsonString);
                if (json == null) return null;

                return new WeatherResponse
                {
                    Temp = json["main"]?["temp"]?.GetValue<double>() ?? 0.0,
                    Description = json["weather"]?[0]?["description"]?.GetValue<string>() ?? "No description",
                    Icon = json["weather"]?[0]?["icon"]?.GetValue<string>() ?? "default"
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in GetWeatherAsync: {ex.Message}");
                return null;
            }
        }

    }
}
