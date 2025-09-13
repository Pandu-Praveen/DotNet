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
    public partial class MiniStatement : Form
    {
        private int accountNumber;
        private int pinNumber;
        private readonly string connectionString = DBHelper.ConnectionString;
        public MiniStatement(int accountNumber,int pinNumber)
        {
            InitializeComponent();
            this.accountNumber = accountNumber; 
            this.pinNumber = pinNumber;
            name.Text += DBHelper.CustomerName;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT TOP 10 transactionType, amount, transactionDate
                        FROM transaction_history
                        WHERE accNo = @accNo
                        ORDER BY transactionDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@accNo", accountNumber);
                        conn.Open();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching transactions: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }

        
    }
}
