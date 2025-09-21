using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServerSideStateManagement
{
    public partial class ApplicationResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "Welcome To "+Application["CompanyName"].ToString();
            lblMessage.ForeColor = System.Drawing.Color.Green;
        }
    }
}