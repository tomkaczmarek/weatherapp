using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDatabase.DataExchange;

namespace WeatherDatabase.Operation
{
    public abstract class OperationBase
    {
        protected WeatherDataMapDataContext dbContex = new WeatherDataMapDataContext(DbConnection.Instance.GetFixedConnectionString());

        public WeatherDataMapDataContext DbContex
        {
            get { return dbContex; }
        }

        public abstract void Execute(WeatherData data);
    }
}
