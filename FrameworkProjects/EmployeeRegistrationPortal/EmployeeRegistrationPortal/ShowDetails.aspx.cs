using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeRegistrationPortal
{
    public partial class ShowDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
                dspEmpId.Text = HelperClass.empId;
                dspEmpName.Text = HelperClass.empName;
                dspEmpAge.Text = HelperClass.empAge;
                dspEmpDept.Text = HelperClass.empDept;
                dspEmpAddress.Text = HelperClass.empAddress;
                dspEmpCity.Text = HelperClass.empCity;
                dspEmpPin.Text = HelperClass.empPincode;
                dspEmpMobileNumber.Text = HelperClass.empMobileNumber;
                dspEmpEmailId.Text = HelperClass.empEmail;
            //user Details here....
                dspUserId.Text = HelperClass.userId;
                dspUserName.Text = HelperClass.userName;
                dspUserPassword.Text = HelperClass.userPassword;
            
        }

    }
}