using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherProxy.ServiceProvider
{
    public interface IServiceProvider
    {
        string ServiceName(string city);
    }
}
