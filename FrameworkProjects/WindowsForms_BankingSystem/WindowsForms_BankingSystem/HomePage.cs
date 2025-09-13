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

namespace WindowsForms_BankingSystem
{
    public partial class HomePage : Form
    {
        private int accountNumber;
        private int pinNumber;
        static string connectionString = DBHelper.ConnectionString;
        static SqlConnection conn = new SqlConnection(connectionString);

       
        public HomePage()
        {
            InitializeComponent();
        }
        public HomePage(int accountNumber, int pinNumber)
        {
            InitializeComponent();
            this.accountNumber = accountNumber;
            this.pinNumber = pinNumber;
            name.Text += DBHelper.CustomerName;
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            Deposit deposit = new Deposit(accountNumber, pinNumber);
            deposit.ShowDialog();
        }

        private void btnShowBalance_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                string query = "SELECT accBalance FROM customers WHERE accNo = @accNo";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@accNo", accountNumber);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    decimal balance = Convert.ToDecimal(reader["accBalance"]);
                    MessageBox.Show(balance.ToString());
                }
                else
                {
                    MessageBox.Show("error");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btnMiniStatement_Click(object sender, EventArgs e) { 
            MiniStatement miniStatement = new MiniStatement(accountNumber,pinNumber);
            miniStatement.ShowDialog();
            
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            Withdraw withdraw = new Withdraw(accountNumber, pinNumber);
            withdraw.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to log out?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Hide();

                Form1 loginForm = new Form1();
                loginForm.Show();
            }
        }
    }
}
