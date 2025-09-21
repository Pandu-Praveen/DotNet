using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutoPostBack
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private void LoadCities()
        {
            ddList_Cities.Items.Add("Chennai");
            ddList_Cities.Items.Add("Hyderabad");
            ddList_Cities.Items.Add("Pune");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCities();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblMessage.Text = ddList_Cities.SelectedItem.ToString();
        }
        protected void ddList_Cities_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "You selected: " + ddList_Cities.SelectedItem.ToString();
        }

      
    }
}
