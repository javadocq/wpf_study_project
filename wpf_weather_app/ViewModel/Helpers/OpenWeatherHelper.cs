using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;

namespace WeatherApp.ViewModel.Helpers
{
    public class OpenWeatherHelper
    {
        
        public const string BASE_URL = "https://api.openweathermap.org/data/2.5/";
        public const string WEATHER_ENDPOINT = "weather?lat={0}&lon={1}&appid={2}";

        public static string GetApiKey()
        {
            string json = File.ReadAllText("appsettings.json");
            JObject config = JObject.Parse(json);
            return config["OpenWeather"]["ApiKey"].ToString();
        }
        public static async Task<WeatherModel.Root> GetWeather(double lat, double lon)
        {
            string url = $"{BASE_URL}weather?lat={lat}&lon={lon}&units=metric&lang=kr&appid={GetApiKey()}";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<WeatherModel.Root>(json);
                }
                return null;
            }
        }
    }
}
