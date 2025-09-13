using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketApp
{
    internal class DBHelper
    {
        private static readonly string connectionString =
            "yourDB_CONNECTION_STRING";
        public static string ConnectionString
        {
            get { return connectionString; }
        }
    }
}
