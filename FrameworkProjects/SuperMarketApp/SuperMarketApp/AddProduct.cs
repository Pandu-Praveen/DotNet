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
    public partial class AddProduct : Form
    {
        static string connectionString = DBHelper.ConnectionString;
        public AddProduct()
        {
            InitializeComponent();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            string name = productName.Text.Trim();
            decimal price;
            int quantity;

           
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show(
                    "Please enter the product name.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            if (!decimal.TryParse(productPrice.Text.Trim(), out price) || price < 0)
            {
                MessageBox.Show(
                    "Please enter a valid price.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            if (!int.TryParse(productQuantity.Text.Trim(), out quantity) || quantity < 0)
            {
                MessageBox.Show(
                    "Please enter a valid quantity.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query =
                        "INSERT INTO Product (Name, Price, AvailableQuantity) VALUES (@Name, @Price, @Quantity)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Price", price);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);

                        conn.Open();
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show(
                                "Product added successfully!",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                           
                            productName.Clear();
                            productPrice.Clear();
                            productQuantity.Clear();
                        }
                        else
                        {
                            MessageBox.Show(
                                "Failed to add product.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message,
                    "I Think there is an Exception:(",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }
    }
}
