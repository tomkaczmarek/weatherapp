using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDatabase.DAO;
using WeatherDatabase.DataExchange;

namespace WeatherDatabase.Operation
{
    public class InsertOperation : OperationBase
    {
        public override void Execute(WeatherData data)
        {
            try
            {
                WEATHER_DATA weatherData = new WEATHER_DATA();
                weatherData.CITY_NAME = data.Name;
                weatherData.SUNRISE = data.Sunrise;
                weatherData.SUNSET = data.Sunset;
                weatherData.UPDATE_DATE = data.UpdateDate;
                weatherData.IS_CLOUD = data.IsCloud;
                weatherData.IS_RAIN = data.IsRain;
                weatherData.Id = WeatherDAO.Instance.GetNextId();

                dbContex.WEATHER_DATAs.InsertOnSubmit(weatherData);
                dbContex.SubmitChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
