using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WeatherWCF;

namespace WCFHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(WeatherService)))
            {
                host.Open();
                Console.WriteLine("Host Open");
                Console.ReadKey();
            }
        }
    }
}
