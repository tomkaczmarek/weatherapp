using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WeatherDatabase.DataExchange
{
    public class WeatherData
    {
        public DateTime UpdateDate { get; set; }
        public string Name { get; set; }
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }
        public bool IsRain { get; set; }
        public bool IsCloud { get; set; }
    }


}
