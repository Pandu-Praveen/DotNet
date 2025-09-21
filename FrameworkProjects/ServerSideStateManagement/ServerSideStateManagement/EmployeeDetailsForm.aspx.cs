using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServerSideStateManagement
{
    public partial class EmployeeDetailsForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(txtEmpName.Text!=null && txtEmpDesignation.Text!=null)
            {
                Session["EmpName"] = txtEmpName.Text;
                Session["EmpDesignation"] = txtEmpDesignation.Text;
               
                Response.Redirect("CredentialsForm.aspx");
            }
            else
            {
                Response.Write("Please enter employee Details");
            }
        }
    }
}