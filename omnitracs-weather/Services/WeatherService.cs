using Newtonsoft.Json;
using omnitracs_weather.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace omnitracs_weather.Services
{
    public class WeatherService
    {
        public async Task<Weather> getWeather(string country)
        {
            Service s = new Service();
            var response = await s.GetAPIService(country);
            var json = JsonConvert.DeserializeObject<WeatherServiceModel>(response);

            DateTime date = DateTime.Now;
            DateTime.TryParse(json.location.localtime, out date);

            return new Weather
            {
                Country = json.location.country,
                Descriptions = json.current.weather_descriptions[0],
                Localtime = date.GetDateTimeFormats()[85],
                Precip = json.current.precip,
                Temperature = json.current.temperature,
                WeatherImage = json.current.weather_icons[0]
            };
        }
        public async Task<Weather> getWeather(string Latitude, string Longitude)
        {
            Service s = new Service();
            var response = await s.GetAPIService(Latitude, Longitude);
            var json = JsonConvert.DeserializeObject<WeatherServiceModel>(response);

            DateTime date = DateTime.Now;
            DateTime.TryParse(json.location.localtime, out date);

            return new Weather
            {
                Country = json.location.country,
                Descriptions = json.current.weather_descriptions[0],
                Localtime = date.GetDateTimeFormats()[85],
                Precip = json.current.precip,
                Temperature = json.current.temperature,
                WeatherImage = json.current.weather_icons[0]
            };
        }
    }
}