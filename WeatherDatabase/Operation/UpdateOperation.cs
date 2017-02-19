using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDatabase.DataExchange;

namespace WeatherDatabase.Operation
{
    public class UpdateOperation : OperationBase
    {
        
        public override void Execute(WeatherData data)
        {
            var weatherData = from w in dbContex.WEATHER_DATAs
                        where w.CITY_NAME == data.Name
                        select w;

            foreach(var item in weatherData)
            {
                item.CITY_NAME = data.Name;
                item.SUNRISE = data.Sunrise;
                item.SUNSET = data.Sunset;
                item.UPDATE_DATE = data.UpdateDate;
                item.IS_RAIN = data.IsRain;
                item.IS_CLOUD = data.IsCloud;
            }
            
            dbContex.SubmitChanges();
            dbContex.Dispose();
        }
    }
}
