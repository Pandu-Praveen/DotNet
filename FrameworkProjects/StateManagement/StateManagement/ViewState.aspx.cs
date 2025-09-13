using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagement
{
    public partial class ViewState : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSave.Text = string.Empty;
            lblShow.Text = string.Empty;    
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ViewState["Name"] = txtName.Text;
            lblSave.Text = "Name Saved";
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            lblShow.Text = ViewState["Name"].ToString();
        }
    }
}