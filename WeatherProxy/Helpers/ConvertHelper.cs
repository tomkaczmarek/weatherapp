using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherDatabase.DataExchange;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;
using WeatherProxy.ServiceProvider;

namespace WeatherProxy.Helpers
{
    public static class ConvertHelper
    {
        public static WeatherDataJson ConvertFromJSON(string json)
        {
            WeatherDataJson weatherData = new WeatherDataJson();
            WeatherDataMembersJson weatherDataMember = new WeatherDataMembersJson();
            try
            {
                weatherDataMember = JsonConvert.DeserializeObject<WeatherDataMembersJson> (json);
                weatherData.DataMembers = weatherDataMember;
                weatherData.UpdateDate = DateTime.Now;
            }
            catch (Exception) { }

            return weatherData;
        }

        public static string ConvertToJSON(WeatherData data)
        {
            return JsonConvert.SerializeObject(data);
        }

        public static DateTime ConvertUTCTimeToDateTime(string utc)
        {
            int i;
            DateTime dateTime = DateTime.Now;
            if (int.TryParse(utc, out i))
            {
                dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                dateTime = dateTime.AddSeconds(i);
            }
            return dateTime;
        }

        public static string ConvertToXml(WeatherData data)
        {
            string xml = string.Empty;

            XmlSerializer seralizer = new XmlSerializer(typeof(WeatherData));

            using (StringWriter writer = new StringWriter())
            {
                seralizer.Serialize(writer, data);
                xml = writer.ToString();
            }
            return xml;
        }

        public static WeatherData ConvertFromJsonData(WeatherDataJson jsonData)
        {
            WeatherData weatherData = new WeatherData();
            DateTime sunrise = ConvertUTCTimeToDateTime(jsonData.DataMembers.Sys[WeatherServiceProvider.Sunrise]);
            DateTime sunset = ConvertUTCTimeToDateTime(jsonData.DataMembers.Sys[WeatherServiceProvider.Sunset]);

            weatherData.Name = jsonData.DataMembers.Name.ToLower();
            weatherData.UpdateDate = jsonData.UpdateDate;
            weatherData.IsCloud = jsonData.DataMembers.Clouds == null ? false : true;
            weatherData.IsRain = jsonData.DataMembers.Rain == null ? false : true;
            weatherData.Sunset = sunset;
            weatherData.Sunrise = sunrise;

            return weatherData;
        }

    }



}
