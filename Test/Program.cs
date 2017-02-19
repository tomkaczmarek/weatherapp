using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherProxy;
using WeatherDatabase.DataExchange;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string choise;
            string data;
            do
            {
                Console.WriteLine("!!For test make sure that WCFHost project is working in Without Debugging mode!!");
                Console.WriteLine("Please give city name. Example: poznan, warsaw");
                Console.WriteLine("Default data format XML. To get json format write /json. Example: poznan/json.");
                choise = Console.ReadLine();
                IWeather weather = new Weather(choise);
                data = weather.GetData();
                Console.WriteLine("------------------------------------------");
                Console.WriteLine(data);
                Console.WriteLine("------------------------------------------");
            }
            while (true);
        }
    }
}
