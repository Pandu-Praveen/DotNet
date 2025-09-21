using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServerSideStateManagement
{
    public partial class SessionResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                lblMessage.Text = "Hello " + Session["UserName"].ToString();
            }
            else
            {
                lblMessage.Text = "Please go back to the previous page and enter your name.";
            }
        }
    }
}
