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
    public partial class SalesPerson : Form
    {
        public SalesPerson()
        {
            InitializeComponent();
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

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            this.Close();
            AddProductToCart addProductToCart = new AddProductToCart(); 
            addProductToCart.Show();
        }

        private void btnFindBills_Click(object sender, EventArgs e)
        {
            this.Close();
            Bills bills = new Bills();
            bills.Show();
        }

        private void btnMyCart_Click(object sender, EventArgs e)
        {
            this.Close();
            Cart cart = new Cart(); 
            cart.Show();
        }

        private void SalesPerson_Load(object sender, EventArgs e)
        {
            txtWelcome.Text += LoginSalesPerson.userName;
        }
    }
}
