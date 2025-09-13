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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
            this.FormClosed += (s, e) => Application.Exit();
        }

        private void btnManagerLogin_Click(object sender, EventArgs e)
        {
           LoginManager manager = new LoginManager();
            manager.Show();
        }

        private void btnSalesPersonLogin_Click(object sender, EventArgs e)
        {
            LoginSalesPerson salesPerson = new LoginSalesPerson();
            salesPerson.Show();
        }
    }
}
