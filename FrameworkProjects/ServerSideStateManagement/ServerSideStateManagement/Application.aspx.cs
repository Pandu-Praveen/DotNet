using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServerSideStateManagement
{
    public partial class Application : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCompanyName.Text))
            {
                //Application state is a global storage mechanism that allows you to store and share data across all users and sessions in an ASP.NET application.
                //Example: Number of clicks made on a website. and more like that.
                Application["CompanyName"] = txtCompanyName.Text;
                //Server.Transfer method transfers the request to another page on the server without making a round trip back to the client's browser.
                //This means that the URL in the browser remains unchanged, and the state of the current page is preserved.
                Server.Transfer("ApplicationResult.aspx");
            }
            else
            {
                Response.Write("Please fill in the required field.");
            }
        }
    }
}