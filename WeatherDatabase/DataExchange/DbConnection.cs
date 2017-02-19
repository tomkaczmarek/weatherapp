using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDatabase.DataExchange
{
    public class DbConnection
    {
        private static DbConnection _inststance;
        private static object _lockObject = new object();
        private string _connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|WeatherDatabase.mdf;Integrated Security = True";

        public static DbConnection Instance
        {
            get
            {
                lock(_lockObject)
                {
                    if (_inststance == null)
                        _inststance = new DbConnection();
                    return _inststance;
                }           
            }
        }

        public string GetFixedConnectionString()
        {
            string connectionString = string.Empty;
            string path = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo d = Directory.GetParent(path).Parent.Parent.Parent;
            path = d.FullName + @"\WeatherDatabase\";
            connectionString = _connectionString.Replace("|DataDirectory|", path);
            return connectionString;
        }
    }
}
