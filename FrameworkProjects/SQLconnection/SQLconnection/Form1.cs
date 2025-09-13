using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLconnection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string connectionUrl =
            "yourDB_CONNECTION_STRING";
        static SqlConnection conn = new SqlConnection(connectionUrl);

        private void getLastEmpId_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string getLastRowId = "SELECT TOP 1 empId FROM emp ORDER BY empId DESC";

                SqlCommand cmd = new SqlCommand(getLastRowId, conn);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    label1.Text = "Last Emp ID: " + result.ToString();
                }
                else
                {
                    label1.Text = "No employees found.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
