using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServerSideStateManagement
{
    public partial class CredentialsForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(txtUserId.Text!=null && txtUserPassword.Text!=null)
            {
                Session["UserId"] = txtUserId.Text;
                Session["Password"] = txtUserPassword.Text;
                Response.Redirect("DisplayDetails.aspx");
            }
            else
            {
                Response.Write("Please enter User Details");
            }
        }
    }
}