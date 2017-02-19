using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDatabase.DataExchange
{
    public class WeatherDataJson
    {
        public DateTime UpdateDate { get; set; }
        public WeatherDataMembersJson DataMembers { get; set; }
    }

    public class WeatherDataMembersJson
    {
        public string Name { get; set; }
        public IDictionary<string, string> Sys { get; set; }
        public IDictionary<string, string> Rain { get; set; }
        public IDictionary<string, string> Clouds { get; set; }

    }
}
