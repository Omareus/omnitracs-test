using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using omnitracs_weather.Services;

namespace omnitracs_weather.Controllers
{
    public class WeatherController : ApiController
    {
        [HttpGet]        
        public async Task<HttpResponseMessage> getWeatherByCountry(string country) {
            WeatherService weatherService = new WeatherService();
            var response = await weatherService.getWeather(country);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> getWeatherByLocation(string latitude,string longitude)
        {
            WeatherService weatherService = new WeatherService();
            var response = await weatherService.getWeather(latitude, longitude);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
