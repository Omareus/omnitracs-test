using Newtonsoft.Json;
using omnitracs_weather.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace omnitracs_weather.Services
{
    public class Service
    {
        public async Task<string> GetAPIService(string Country)
        {
            string url = this.GetURLService("WeatherServiceUrl") + "&query=" + Country;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;                    
                }
                return String.Empty;
            }
        }

        public async Task<string> GetAPIService(string Latitude, string Longitude)
        {
            string url = this.GetURLService("WeatherServiceUrl") + "&query=" + Latitude + "," + Longitude;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
                return String.Empty;
            }
        }

        private string GetURLService(string key) {
            if (!(String.IsNullOrEmpty(key)))
            return WebConfigurationManager.AppSettings[key];
            return String.Empty;
        }
    }
}