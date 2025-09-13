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
    public partial class Cart : Form
    {
        static string connectionString = DBHelper.ConnectionString;
        private string salesPersonId,
            userName;

        public Cart()
        {
            InitializeComponent();
            this.salesPersonId = LoginSalesPerson.salespersonId;
            this.userName = LoginSalesPerson.userName;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Close();
            SalesPerson salesPerson = new SalesPerson();
            salesPerson.Show();
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string groupCartQuery =
                        "select ProductID, SUM(Quantity) AS TotalQuantity, MAX(Price) AS UnitPrice FROM Cart WHERE SalesPersonId = @SalesPersonId GROUP BY ProductID";

                    SqlCommand groupCartCmd = new SqlCommand(groupCartQuery, conn);
                    groupCartCmd.Parameters.AddWithValue("@SalesPersonId", salesPersonId);

                    SqlDataAdapter adapter = new SqlDataAdapter(groupCartCmd);
                    DataTable groupedCart = new DataTable();
                    adapter.Fill(groupedCart);

                    if (groupedCart.Rows.Count == 0)
                    {
                        MessageBox.Show("Cart is empty.");
                        return;
                    }

                    string insertBillQuery =
                        "INSERT INTO Bills (SalespersonID, ProductID, Quantity, UnitPrice) VALUES (@SalespersonID, @ProductID, @Quantity, @Price)";

                    foreach (DataRow row in groupedCart.Rows)
                    {
                        int productId = Convert.ToInt32(row["ProductID"]);
                        int quantity = Convert.ToInt32(row["TotalQuantity"]);
                        decimal price = Convert.ToDecimal(row["UnitPrice"]);
                        decimal lineTotal = price * quantity;

                        SqlCommand insertCmd = new SqlCommand(insertBillQuery, conn);
                        insertCmd.Parameters.AddWithValue("@SalespersonID", salesPersonId);
                        insertCmd.Parameters.AddWithValue("@ProductID", productId);
                        insertCmd.Parameters.AddWithValue("@Quantity", quantity);
                        insertCmd.Parameters.AddWithValue("@Price", price);
                     

                        insertCmd.ExecuteNonQuery();
                    }

                    string clearCartQuery = "DELETE FROM Cart WHERE SalesPersonId = @SalesPersonId";
                    SqlCommand clearCmd = new SqlCommand(clearCartQuery, conn);
                    clearCmd.Parameters.AddWithValue("@SalesPersonId", salesPersonId);
                    clearCmd.ExecuteNonQuery();

                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();

                    MessageBox.Show("Bill generated successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while generating bill: " + ex.Message);
            }
        }

        private void Cart_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "select * from cart WHERE SalesPersonId = @salesPersonId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@salesPersonId", salesPersonId);
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
    }
}
