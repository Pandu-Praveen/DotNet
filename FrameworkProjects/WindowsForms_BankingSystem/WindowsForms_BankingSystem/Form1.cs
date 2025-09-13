using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsForms_BankingSystem
{
    
    public partial class Form1 : Form
    {
        static string connectionString = DBHelper.ConnectionString;
        static SqlConnection conn = new SqlConnection(connectionString);

        public Form1()
        {
            InitializeComponent();
            this.FormClosed += (s, e) => Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (
                !int.TryParse(accNo.Text, out int accountNumber)
                || !int.TryParse(accPin.Text, out int accountPin)
            )
            {
                MessageBox.Show("Please enter valid numeric Account Number and PIN.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query =
                        "SELECT * FROM customers WHERE accNo = @accNo AND accPin = @accPin";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@accNo", accountNumber);
                        cmd.Parameters.AddWithValue("@accPin", accountPin);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                DBHelper.CustomerName = dr["customerName"].ToString();
                                HomePage homePage = new HomePage(accountNumber, accountPin);
                                homePage.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("User Not Found!");
                            }
                        }
                    }
                }
            } //End of Try
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        } //end of btnLogin
    }
}
