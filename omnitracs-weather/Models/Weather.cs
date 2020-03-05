using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace omnitracs_weather.Models
{
    public class Weather
    {
        public string Country { get; set; }
        public string Temperature { get; set; }
        public string WeatherImage { get; set; }        
        public string Descriptions { get; set; }
        public string Precip { get; set; }
        public string Localtime { get; set; }

    }
}