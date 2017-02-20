using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WeatherDatabase;
using WeatherDatabase.Operation;
using WeatherProxy.Helpers;
using WeatherProxy.ServiceProvider;
using WeatherProxy.WeatherServiceReference;
using WeatherDatabase.DAO;
using WeatherDatabase.DataExchange;

namespace WeatherProxy
{
    public class Weather : IWeather
    {
        #region private_fields

        private WeatherData _weatherData;
        private string _parameters, _cityName;
        private DataFormat _dataFormat;

        #endregion

        #region Properties

        public WeatherData WeatherData
        {
            get { return _weatherData; }
            set { _weatherData = value; }
        }

        public string CityName
        {
            get { return _cityName; }
            set { _cityName = value; }
        }

        public DataFormat DataFormat
        {
            get { return _dataFormat; }
            set { _dataFormat = value; }
        }

        public string Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        #endregion

        public Weather(string parameters)
        {
            Parameters = parameters.ToLower();
        }

        public string GetData()
        {
            string data = string.Empty;
            GetParameters(Parameters);
                      
            DateTime updateDate = DateTime.Now.AddHours(-1);

            WeatherData = LocalCache.Instance.Get<WeatherData>(CityName);

            if(WeatherData == null || (WeatherData != null && WeatherData.UpdateDate < updateDate))
            {
                LocalCache.Instance.Remove(CityName);
                WeatherData = GetDataFromDatabase(CityName, updateDate);
                if (WeatherData == null)
                {
                    WeatherDataJson jsonData = new WeatherDataJson();
                    jsonData = GetDataFromWCF(new WeatherServiceProvider());
                    if (jsonData.DataMembers != null)
                    {
                        WeatherData = ConvertHelper.ConvertFromJsonData(jsonData);
                        DatabaseOperation(new InsertOrUpdateOperation(), WeatherData);
                    }
                }
                LocalCache.Instance.Add(WeatherData, CityName);
            }
            if(WeatherData !=null)
            {
                if(DataFormat == DataFormat.JSON)
                {
                    data = ConvertHelper.ConvertToJSON(WeatherData);
                }
                else
                {
                    data = ConvertHelper.ConvertToXml(WeatherData);
                }             
            }                   
            return data;
        }

        #region private methods

        private void GetParameters(string parameters)
        {
            string[] p = parameters.Split('/');
            if (p.Length > 1)
                DataFormat = p[1].Equals("json") ? DataFormat.JSON : DataFormat.XML;
            CityName = p[0];
        }

        private WeatherData GetDataFromDatabase(string cityName, DateTime updateDate)
        {
            WeatherData weatherData = new WeatherData();
            weatherData = WeatherDAO.Instance.GetWeatherDataByCityNameAndUpdateDate(cityName, updateDate);
            return weatherData;
        }

        private WeatherDataJson GetDataFromWCF(ServiceProvider.IServiceProvider service)
        {
            WeatherDataJson weatherData = new WeatherDataJson();
            string data = string.Empty;

            var end_adress = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/WeatherWCF/WeatherService/");
            using (WeatherServiceClient proxy = new WeatherServiceClient(new BasicHttpBinding(), end_adress))
            {
                data = proxy.GetData(service.ServiceName(CityName));
            }

            if (!string.IsNullOrEmpty(data))
                weatherData = ConvertHelper.ConvertFromJSON(data);

            return weatherData;
        }

        private void DatabaseOperation(OperationBase operation, WeatherData weatherData)
        {
            operation.Execute(weatherData);
        }

        #endregion
    }
    public enum DataFormat
    {
        XML,
        JSON
    }

}
