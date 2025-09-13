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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsForms_BankingSystem
{
    public partial class Deposit : Form
    {
        private readonly string connectionString = DBHelper.ConnectionString;
        private readonly int accountNumber;
        private readonly int pinNumber;

        public Deposit(int accountNumber, int pinNumber)
        {
            InitializeComponent();
            this.accountNumber = accountNumber;
            this.pinNumber = pinNumber;
            name.Text += DBHelper.CustomerName;
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(amount.Text, out decimal depositAmount) || depositAmount <= 0)
            {
                MessageBox.Show("Enter a valid deposit amount.");
                return;
            }
            if (!int.TryParse(accPin.Text, out int enteredPin))
            {
                MessageBox.Show("Please enter a valid numeric PIN.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    decimal currentBalance = 0;
                    string selectQuery =
                        "SELECT accBalance FROM customers WHERE accNo = @accNo and accPin = @accPin";
                    using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@accNo", accountNumber);
                        cmd.Parameters.AddWithValue("@accPin", enteredPin);
                        var result = cmd.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show("Please Enter the Correct Pin");
                            return;
                        }

                        currentBalance = Convert.ToDecimal(result);
                    }

                    decimal newBalance = currentBalance + depositAmount;
                    string updateQuery =
                        "UPDATE customers SET accBalance = @accBalance WHERE accNo = @accNo";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@accBalance", newBalance);
                        cmd.Parameters.AddWithValue("@accNo", accountNumber);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Deposit successful! New balance: {newBalance}");
                            string insertTransactionQuery =
                                "INSERT INTO transaction_history (accNo, transactionType, amount) VALUES (@accNo, @transactionType, @Amount)";

                            using (
                                SqlCommand transCmd = new SqlCommand(insertTransactionQuery, conn)
                            )
                            {
                                transCmd.Parameters.AddWithValue("@accNo", accountNumber);
                                transCmd.Parameters.AddWithValue("@transactionType", "Deposit");
                                transCmd.Parameters.AddWithValue("@amount", depositAmount);

                                transCmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Failed to update balance.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        
    }
}
