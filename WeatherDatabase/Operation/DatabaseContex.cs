using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDatabase.DataExchange;

namespace WeatherDatabase.Operation
{
    public class DatabaseContex : OperationBase
    {
        private WeatherDataMapDataContext context;

        public WeatherDataMapDataContext Context
        {
            get
            {
                return context;
            }
        }

        public DatabaseContex()
        {
            context = new WeatherDataMapDataContext();
        }

        public override void Execute(WeatherData data)
        {
            
        }
    }
}
