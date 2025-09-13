using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsForms_BankingSystem
{
    public partial class Withdraw : Form
    {
        private readonly int accountNumber;
        private readonly int pinNumber;
        private readonly string connectionString = DBHelper.ConnectionString;

        public Withdraw(int accountNumber, int pinNumber)
        {
            InitializeComponent();
            this.accountNumber = accountNumber;
            this.pinNumber = pinNumber;
            name.Text += DBHelper.CustomerName;
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(amount.Text, out decimal withdrawAmount) || withdrawAmount <= 0)
            {
                MessageBox.Show("Enter a valid withdrawal amount.");
                return;
            }

            if (!int.TryParse(tpin.Text, out int enteredPin))
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
                        "SELECT accBalance FROM customers WHERE accNo = @accNo and accPin=@accPin";
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

                    if (withdrawAmount > currentBalance)
                    {
                        MessageBox.Show("Insufficient balance.");
                        return;
                    }

                    decimal newBalance = currentBalance - withdrawAmount;
                    string updateQuery =
                        "UPDATE customers SET accBalance = @accBalance WHERE accNo = @accNo";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@accBalance", newBalance);
                        cmd.Parameters.AddWithValue("@accNo", accountNumber);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Withdrawal successful. New Balance: {newBalance}");
                            string insertTransactionQuery =
                                "INSERT INTO transaction_history (accNo, transactionType, amount) VALUES (@accNo, @transactionType, @amount)";

                            using (
                                SqlCommand transCmd = new SqlCommand(insertTransactionQuery, conn)
                            )
                            {
                                transCmd.Parameters.AddWithValue("@accNo", accountNumber);
                                transCmd.Parameters.AddWithValue("@transactionType", "Withdrawal");
                                transCmd.Parameters.AddWithValue("@amount", withdrawAmount);

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
