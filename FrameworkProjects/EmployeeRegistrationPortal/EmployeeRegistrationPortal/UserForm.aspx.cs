using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeRegistrationPortal
{
    public partial class UserForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text; 
            string userId = txtUserId.Text;
            string userPassword = txtPassword.Text;
            if (Page.IsValid)
            {
                HelperClass.userId = userId;
                HelperClass.userName = userName;
                HelperClass.userPassword = userPassword;
                Response.Redirect("ShowDetails.aspx");
            }
        }
    }
}