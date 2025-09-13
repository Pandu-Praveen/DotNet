
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sqldemo
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }
        private void btnGetLastEmpId_Click(object sender, EventArgs e)
        {
            try
            {
                 string connectionUrl = "server=ENCOPDBANLT1776\\MSSQLSERVER1;database=myencora;Integrated Security=True";
                 SqlConnection conn = new SqlConnection(connectionUrl);
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
          
        }
    }
}




        
