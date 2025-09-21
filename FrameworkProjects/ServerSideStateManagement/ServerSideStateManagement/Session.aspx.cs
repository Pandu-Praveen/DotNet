using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServerSideStateManagement
{
    public partial class Session : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(txtName.Text.Length > 0)
            {
                Session["userName"] = txtName.Text;
                Response.Redirect("SessionResult.aspx");
            }
            else
            {
                Response.Write("Please enter your name.");
            }
        }
    }
}