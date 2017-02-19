using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDatabase.DAO;
using WeatherDatabase.DataExchange;

namespace WeatherDatabase.Operation
{
    public class InsertOrUpdateOperation : OperationBase
    {
        public override void Execute(WeatherData data)
        {
            try
            {
                OperationBase operation;
                WeatherData weatherData = WeatherDAO.Instance.GetWeatherDataByCityName(data.Name);

                if(string.IsNullOrEmpty(weatherData.Name))
                {
                    operation = new InsertOperation();
                }
                else
                {
                    operation = new UpdateOperation();
                }
                operation.Execute(data);
                    
            }
            catch (Exception) { throw; }
        }
    }
}
