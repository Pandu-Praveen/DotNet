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

namespace LoginForm
{
    public partial class Form1 : Form
    {
        static string connectionString =
            "yourDB_CONNECTION_STRING";
        static SqlConnection conn = new SqlConnection(connectionString);

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
               
                conn.Open();
                string query = "select * from users where userId=@userId and password=@password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId.Text);
                cmd.Parameters.AddWithValue("@password", password.Text);

                SqlDataReader reader = cmd.ExecuteReader();
                
                if (reader.Read())
                {
                    welcomeLabel.Text = "Welcome " + reader["userId"].ToString() + "!";
                    welcomeLabel.ForeColor = Color.DarkGreen;
                }
                else
                {
                    welcomeLabel.Text = "OOPS!, User ID is not Found";
                    welcomeLabel.ForeColor = Color.DarkRed;
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
