using System;
using System.Net;

namespace WeatherWCF
{
    public class WeatherService : IWeatherService
    {
        public string GetData(string url)
        {
            string data = string.Empty;

            try
            {              
                using (WebClient web = new WebClient())
                {
                    data = web.DownloadString(url);
                }
            }
            catch(Exception)
            {
                throw;
            }

            return data;
        }
    }
}
