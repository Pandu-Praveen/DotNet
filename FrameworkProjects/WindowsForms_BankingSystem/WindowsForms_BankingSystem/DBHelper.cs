using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_BankingSystem
{
    internal class DBHelper
    {
        private static string _customerName;
        private static readonly string _connectionString =
            "yourDB_CONNECTION_STRING";

        public static string ConnectionString
        {
            get { return _connectionString; }
        }
        public static string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }
    }
}
