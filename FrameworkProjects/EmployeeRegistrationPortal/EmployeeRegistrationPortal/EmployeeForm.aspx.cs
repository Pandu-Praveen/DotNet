using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeRegistrationPortal
{
    public partial class EmployeeForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            string empId = txtEmpId.Text;   
            string empName = txtEmpName.Text;
            string empAge = txtAge.Text;
            string empDept = txtDept.Text; 
            string empAddress = txtAddress.Text;
            string empCity = txtCity.Text;
            string empPincode = txtPinCode.Text;   
            string empMobileNumber = txtMobileNumber.Text;
            string empEmail = txtEmailId.Text;

            if (Page.IsValid)
            {
                HelperClass.empId = txtEmpId.Text;
                HelperClass.empName = txtEmpName.Text;
                HelperClass.empAge = txtAge.Text;
                HelperClass.empDept = txtDept.Text;
                HelperClass.empAddress = txtAddress.Text;
                HelperClass.empCity = txtCity.Text;
                HelperClass.empPincode = txtPinCode.Text;
                HelperClass.empMobileNumber = txtMobileNumber.Text;
                HelperClass.empEmail = txtEmailId.Text;
                Response.Redirect("UserForm.aspx");
            }
        }
    }
}
