using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetEnv;

namespace sqlconsoleconnection
{
    internal class Program
    {
       
        static string connectionString =
            "yourDB_CONNECTION_STRING";
        static SqlConnection conn = new SqlConnection(connectionString);

        static void Main(string[] args)
        {
           
            try
            {
                conn.Open();
                Console.WriteLine("===successfully connected===");
                string query = "select * from emp";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    Console.WriteLine("Empid\t Name\t Salary");
                    while (dr.Read())
                    {
                        Console.WriteLine(dr["empId"] + "\t" + dr["empName"] + "\t" + dr["empSalary"]);

                    }

                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
