using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ServerSideStateManagement
{
    public partial class Address1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserName.Text) && 
                !string.IsNullOrEmpty(txtStreetName.Text) && !string.IsNullOrEmpty(txtHouseNumber.Value))
            {
                Session["UserName"] = txtUserName.Text;
                Session["StreetName"] = txtStreetName.Text;
                Session["HouseNumber"] = txtHouseNumber.Value;

                Response.Redirect("Address2.aspx");
            }
            else
            {
              
                Response.Write( "Please fill in all the required fields.");
            }
        }
    }
}