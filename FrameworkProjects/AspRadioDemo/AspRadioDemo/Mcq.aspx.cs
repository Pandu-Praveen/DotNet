using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspRadioDemo
{
    public partial class Mcq : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedIndex == 0)
            {
                result.Text = "Correct";
                result.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                result.Text = "InCorrect";

                result.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
