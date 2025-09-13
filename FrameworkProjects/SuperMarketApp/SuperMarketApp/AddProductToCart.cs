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
    public partial class AddProductToCart : Form
    {
        static string connectionString = DBHelper.ConnectionString;
        private string salesPersonId,
            userName;

        public AddProductToCart()
        {
            InitializeComponent();
            this.salesPersonId = LoginSalesPerson.salespersonId;
            this.userName = LoginSalesPerson.userName;
        }

       

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(productId.Text.Trim(), out int pId))
            {
                MessageBox.Show("Please enter a valid Product ID.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query =
                        "SELECT Name, Price, AvailableQuantity FROM Product WHERE ProductID = @ProductID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ProductID", pId);

                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        productName.Text = reader["Name"].ToString();
                        productPrice.Text = reader["Price"].ToString();
                        productQuantity.Text = reader["AvailableQuantity"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Product not found.");
                        productName.Clear();
                        productPrice.Clear();
                        productQuantity.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnAddProductToCart_Click(object sender, EventArgs e)
        {
            if (
                !int.TryParse(productId.Text.Trim(), out int pId)
                || !int.TryParse(productQuantity.Text.Trim(), out int quantityToAdd)
                || quantityToAdd <= 0
            )
            {
                MessageBox.Show("Please enter a valid Product ID and Quantity.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string checkQuery =
                        "SELECT AvailableQuantity FROM Product WHERE ProductID = @ProductID";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@ProductID", pId);

                    int availableQty = 0;
                    object result = checkCmd.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show("Product does not exist.");
                        return;
                    }
                    else
                    {
                        availableQty = Convert.ToInt32(result);
                        if (availableQty < quantityToAdd)
                        {
                            MessageBox.Show($"Only {availableQty} items available in stock.");
                            return;
                        }
                    }

                    string insertQuery =
                        "INSERT INTO Cart (SalespersonID,ProductID, ProductName, Price, Quantity) VALUES (@SalespersonID,@ProductID, @ProductName, @Price, @Quantity)";

                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@SalespersonID", salesPersonId);
                    insertCmd.Parameters.AddWithValue("@ProductID", pId);
                    insertCmd.Parameters.AddWithValue("@ProductName", productName.Text);
                    insertCmd.Parameters.AddWithValue("@Price", productPrice.Text);
                    insertCmd.Parameters.AddWithValue("@Quantity", quantityToAdd);

                    int rowsAffected = insertCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        string updateQuery =
                            "UPDATE Product SET AvailableQuantity = AvailableQuantity - @Quantity WHERE ProductID = @ProductID";
                        SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                        updateCmd.Parameters.AddWithValue("@Quantity", quantityToAdd);
                        updateCmd.Parameters.AddWithValue("@ProductID", pId);
                        updateCmd.ExecuteNonQuery();

                        MessageBox.Show("Product added to cart successfully.");
                        productId.Clear();
                        productName.Clear();
                        productPrice.Clear();
                        productQuantity.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add product to cart.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Close();
            SalesPerson salesPerson = new SalesPerson();
            salesPerson.Show();
        }
    }
}
