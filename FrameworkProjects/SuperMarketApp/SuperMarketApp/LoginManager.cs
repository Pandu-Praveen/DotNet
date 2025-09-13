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

namespace SuperMarketApp
{
    public partial class LoginManager : Form
    {
        static string connectionString = DBHelper.ConnectionString;
        public static string managerName;

        public LoginManager()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string customerName = userNameInput.Text.Trim();
            string password = passwordInput.Text;

            if (string.IsNullOrEmpty(customerName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show(
                    "Please enter both username and password.",
                    "Missing Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query =
                        "SELECT * FROM Manager WHERE Username = @Username AND Password = @Password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", customerName);
                        cmd.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MessageBox.Show(
                                    "Login successful!",
                                    "Welcome",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );

                                managerName = reader["UserName"].ToString();
                                Manager manager = new Manager();
                                manager.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show(
                                    "Invalid username or password.",
                                    "Login Failed",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occurred while connecting to the database:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage homePage = new HomePage();
            homePage.BringToFront();
        }
    }
}
