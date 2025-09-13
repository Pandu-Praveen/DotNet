using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspRadioDemo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (rbtRed.Checked)
            {
                result.Text = "You Selected Red";
            }
            if (rbtGreen.Checked)
            {
                result.Text = "You Selected Green";
            }
            if (rbtBlue.Checked)
            {
                result.Text = "You Selected Blue";
            }
        }

        protected void submit2_Click(object sender, EventArgs e)
        {
            string value = RadioButtonList1.SelectedItem.ToString();    
            result2.Text = "You selected "+value.ToUpper();
        }
    }
}