using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarketApp
{
    public partial class DeleteProduct : Form
    {
        static string connectionString = DBHelper.ConnectionString;

        public DeleteProduct()
        {
            InitializeComponent();
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(productId.Text.Trim(), out int pId))
            {
                MessageBox.Show("Invalid Product ID.");
                return;
            }
            var confirm = MessageBox.Show(
                "Are you sure you want to delete this product?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
            if (confirm != DialogResult.Yes)
            {
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "delete from Product where ProductID = @ProductID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ProductID", pId);
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Product Deleted successfully.");
                        productId.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Product not found!");
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
