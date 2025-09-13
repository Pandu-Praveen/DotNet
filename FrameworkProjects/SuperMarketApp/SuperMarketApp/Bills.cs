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
    public partial class Bills : Form
    {
        static string connectionString = DBHelper.ConnectionString;
        string salespersonId = LoginSalesPerson.salespersonId;

        public Bills()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Close();
            SalesPerson salesPerson = new SalesPerson();
            salesPerson.Show();
        }

        private void btnShowBill_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query =
                        @"
                SELECT 
                    B.BillID,
                    B.ProductID,
                    P.Name AS ProductName,
                    B.Quantity,
                    B.Price,
                    B.LineTotal,
                    B.BillDate
                FROM Bill B
                JOIN Product P ON B.ProductID = P.ProductID
                WHERE B.SalespersonID = @SalespersonID
                ORDER BY B.BillDate DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SalespersonID", salespersonId);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;

                    decimal grandTotal = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        grandTotal += Convert.ToDecimal(row["LineTotal"]);
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
