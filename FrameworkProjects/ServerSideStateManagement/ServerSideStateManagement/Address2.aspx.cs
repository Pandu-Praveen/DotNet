using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServerSideStateManagement
{
    public partial class Address2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCityName.Text) &&
               !string.IsNullOrEmpty(txtPinCode.Text))
            {
                Session["CityName"] = txtCityName.Text;
                Session["PinCode"] = txtPinCode.Text;
           

                Response.Redirect("DisplayAddress.aspx");
            }
            else
            {

                Response.Write("Please fill in all the required fields.");
            }
       
        }
    }
}