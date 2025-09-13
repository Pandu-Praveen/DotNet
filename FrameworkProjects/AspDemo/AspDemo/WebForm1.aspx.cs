using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspDemo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(userName.Text) && !string.IsNullOrEmpty(password.Text))
            {
                string name = userName.Text;
                string pass = password.Text;
                Response.Write($"<script>alert('Welcome {name}');</script>");
            }
            else
            {
                Response.Write("<script>alert('Invalid username or password');</script>");
            }
        }
    }
}
