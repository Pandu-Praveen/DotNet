using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServerSideStateManagement
{
    public partial class Employee1Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (
                !string.IsNullOrEmpty(txtEmp1Name.Text)
                && !string.IsNullOrEmpty(txtEmp1Designation.Text)
                && !string.IsNullOrEmpty(txtEmp1Branch.Text)
            ) {

                Session["Emp1Name"] = txtEmp1Name.Text;
                Session["Emp1Designation"] = txtEmp1Designation.Text;
                Session["Emp1Branch"] = txtEmp1Branch.Text;
                Application["CompanyName"] = "Encora";
                Response.Redirect("Employee2Form.aspx");
            }
            else
            {
                Response.Write("Please fill out all the fields");
            }
        }
    }
}
