using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServerSideStateManagement
{
    public partial class DisplayDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmpName"]!=null && Session["EmpDesignation"] != null)
            {
                lblEmpName.Text = Session["EmpName"].ToString();
                lblEmpDesignation.Text = Session["EmpDesignation"].ToString();
            }
            else
            {
                lblEmpName.Text = "Error Fetching in Employee Name";
                lblEmpDesignation.Text = "Error Fetching in Employee Designation";
            }
            if (Session["UserId"] != null && Session["Password"] != null)
            {
                lblUserId.Text = Session["UserId"].ToString();
                lblUserPassword.Text = Session["Password"].ToString();
            }
            else
            {
                lblUserId.Text = "Error Fetching in User Id";
                lblUserPassword.Text = "Error Fetching in User Password";
            }
        }
    }
}