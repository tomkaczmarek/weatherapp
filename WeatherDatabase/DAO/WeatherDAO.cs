using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using WeatherDatabase.DataExchange;

namespace WeatherDatabase.DAO
{
    public class WeatherDAO
    {
        private static WeatherDAO _instance;

        public static WeatherDAO Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new WeatherDAO();
                return _instance;
            }
        }

        public WeatherData GetWeatherDataByCityName(string cityName)
        {
            WeatherData weatherData = new WeatherData();
            WeatherDataMapDataContext db = new WeatherDataMapDataContext(DbConnection.Instance.GetFixedConnectionString());

            var query = (from w in db.WEATHER_DATAs
                        where w.CITY_NAME == cityName
                        select w).FirstOrDefault();

            weatherData.Name = query == null ? string.Empty : query.CITY_NAME;

            return weatherData;
        }

        public WeatherData GetWeatherDataByCityNameAndUpdateDate(string cityName, DateTime updateDate)
        {
            WeatherData weatherData = null;
            WeatherDataMapDataContext db = new WeatherDataMapDataContext(DbConnection.Instance.GetFixedConnectionString());

            var query = from w in db.WEATHER_DATAs
                        where w.CITY_NAME == cityName && w.UPDATE_DATE > updateDate
                        select w;

            foreach (var q in query)
            {
                weatherData = new WeatherData();
                weatherData.Name = q.CITY_NAME;
                weatherData.Sunrise = q.SUNRISE.Value;
                weatherData.Sunset = q.SUNSET.Value;
                weatherData.UpdateDate = q.UPDATE_DATE.Value;
                weatherData.IsCloud = q.IS_CLOUD.Value;
                weatherData.IsRain = q.IS_RAIN.Value;
            }          
            return weatherData;
        }

        public int GetNextId()
        {
            int id = 0;
            WeatherDataMapDataContext db = new WeatherDataMapDataContext(DbConnection.Instance.GetFixedConnectionString());

            var query = db.WEATHER_DATAs.OrderByDescending(i => i.Id).FirstOrDefault();

            if (query != null)
                id = query.Id + 1;

            return id;
        }

    }
}
