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
using System.Xml.Linq;

namespace SuperMarketApp
{
    public partial class UpdateProduct : Form
    {
        static string connectionString = DBHelper.ConnectionString;

        public UpdateProduct()
        {
            InitializeComponent();
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

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(productId.Text.Trim(), out int pId))
            {
                MessageBox.Show("Invalid Product ID.");
                return;
            }

            if (string.IsNullOrEmpty(productName.Text))
            {
                MessageBox.Show("Product name is required.");
                return;
            }

            if (!decimal.TryParse(productPrice.Text.Trim(), out decimal price) || price < 0)
            {
                MessageBox.Show("Enter a valid price.");
                return;
            }

            if (!int.TryParse(productQuantity.Text.Trim(), out int quantity) || quantity < 0)
            {
                MessageBox.Show("Enter a valid quantity.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query =
                        "update Product set Name = @Name, Price = @Price, AvailableQuantity = @Quantity where ProductID = @ProductID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ProductID", pId);
                    cmd.Parameters.AddWithValue("@Name", productName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Product updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Update failed. Product not found.");
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
        }
    }
}
