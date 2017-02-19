using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WeatherWCF
{
    [ServiceContract]
    public interface IWeatherService
    {
        [OperationContract]
        string GetData(string url);

    }
}
