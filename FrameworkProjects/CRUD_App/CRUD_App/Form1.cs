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
using System.Xml.Linq;

namespace CRUD_App
{
    public partial class Form1 : Form
    {
        static string connectionString =
            "server=ENCOPDBANLT1776\\MSSQLSERVER1;database=myencora;Integrated Security=True";
        static SqlConnection conn = new SqlConnection(connectionString);

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string addQuery =
                    "insert into emp(empId,empName,empSalary)values(@empId,@empName,@empSalary)";

                SqlCommand cmd = new SqlCommand(addQuery, conn);

                cmd.Parameters.AddWithValue("@empId", empId.Text);
                cmd.Parameters.AddWithValue("@empName", empName.Text);
                cmd.Parameters.AddWithValue("@empSalary", empSalary.Text);

                int totalRowsAffected = cmd.ExecuteNonQuery();
                if (totalRowsAffected > 0)
                {
                    MessageBox.Show(totalRowsAffected + " Rows Added", "Insert Query");
                }
                else
                {
                    MessageBox.Show("No rows affected");
                }

                conn.Close();
            }
            catch (Exception ex) { }
        }

        private void btnUpdateEmp_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                string updateQuery =
                    "update emp set empName=@empName,empSalary=@empSalary where empId=@empId";
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@empId", empId.Text);
                cmd.Parameters.AddWithValue("@empName", empName.Text);
                cmd.Parameters.AddWithValue("@empSalary", empSalary.Text);
                int totalRowsAffected = cmd.ExecuteNonQuery();
                if (totalRowsAffected > 0)
                {
                    MessageBox.Show(totalRowsAffected + " Row Updated", "Update Query");
                }
                else
                {
                    MessageBox.Show("No Rows Updated");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnDeleteEmp_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string deleteQuery = "delete from emp where empId=@empId";
                SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                cmd.Parameters.AddWithValue("@empId", empId.Text);
                int totalAffectedRows = cmd.ExecuteNonQuery();
                if (totalAffectedRows > 0)
                {
                    MessageBox.Show(totalAffectedRows + " Row Deleted", "Delete Query");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnClearFields_Click(object sender, EventArgs e)
        {
            empId.Text = string.Empty;
            empName.Text = string.Empty;
            empSalary.Text = string.Empty;
        }

        private void btnShowEmp_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                string ShowQuery = "select * from emp where empId=@empId";

                SqlCommand cmd = new SqlCommand(ShowQuery, conn);

                cmd.Parameters.AddWithValue("@empId", empId.Text);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    empName.Text = dr["empName"].ToString();
                    empSalary.Text = dr["empSalary"].ToString();
                }
                else
                {
                    MessageBox.Show(empId + " is Not Found!!!");
                }

                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e) { }
    }
}
