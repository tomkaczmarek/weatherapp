using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherProxy.ServiceProvider
{
    public class WeatherServiceProvider : IServiceProvider
    {
        private const string ADDID = "20221d0f599dd35e9f97bb7f68276360";
        private const string SUNRISE = "sunrise";
        private const string SUNSET = "sunset";

        public static string Sunrise
        {
            get { return SUNRISE; }
        }

        public static string Sunset
        {
            get { return SUNSET; }
        }

        public string ServiceName(string city)
        {
            string serviceurl = "http://api.openweathermap.org/data/2.5/weather?q=";
            return string.Format("{0}{1}&APPID={2}", serviceurl, city.ToLower(), ADDID);
        }
    }
}
