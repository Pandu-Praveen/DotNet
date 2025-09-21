using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServerSideStateManagement
{
    public partial class Employee2Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (
                !string.IsNullOrEmpty(txtEmp2Name.Text)
                && !string.IsNullOrEmpty(txtEmp2Designation.Text)
                && !string.IsNullOrEmpty(txtEmp2Branch.Text)
            )
            {

                Session["Emp2Name"] = txtEmp2Name.Text;
                Session["Emp2Designation"] = txtEmp2Designation.Text;
                Session["Emp2Branch"] = txtEmp2Branch.Text;
                Application["CompanyName"] = "Encora";
                Response.Redirect("DisplayAllEmployeeDetails.aspx");
            }
            else
            {

            }
            {
                Response.Write("Please fill out all the fields");
            }
        }
    }
}