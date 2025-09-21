using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServerSideStateManagement
{
    public partial class DisplayAllEmployeeDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblEmpName1.Text = Session["Emp1Name"].ToString();
            lblEmpName2.Text = Session["Emp2Name"].ToString();
            lblEmpDesignation1.Text = Session["Emp1Designation"].ToString();
            lblEmpDesignation2.Text = Session["Emp2Designation"].ToString();
            lblBranch1.Text = Session["Emp1Branch"].ToString();
            lblBranch2.Text = Session["Emp2Branch"].ToString();
            lblCompanyName.Text = Application["CompanyName"].ToString();    
        }
    }
}