using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarketApp
{
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
        }

        private void btnShowAllProducts_Click(object sender, EventArgs e)
        {
            ShowAllProducts showAllProducts = new ShowAllProducts();
            showAllProducts.Show();
        }

        private void btnAddNewProduct_Click(object sender, EventArgs e)
        {
            AddProduct product = new AddProduct();  
            product.Show();
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            UpdateProduct product = new UpdateProduct();    
            product.Show();
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            DeleteProduct product = new DeleteProduct();    
            product.Show();
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

                HomePage homePage = new HomePage();
                homePage.BringToFront();
            }
        }

        private void Manager_Load(object sender, EventArgs e)
        {
            txtWelcome.Text += LoginManager.managerName;
        }
    }
}
