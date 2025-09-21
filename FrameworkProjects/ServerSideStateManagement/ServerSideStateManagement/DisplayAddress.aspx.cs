using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServerSideStateManagement
{
    public partial class DisplayAddress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUserName.Text =
                    Session["UserName"] != null
                        ? Session["UserName"].ToString()
                        : "Name not provided.";
                lblStreetName.Text =
                    Session["StreetName"] != null
                        ? Session["StreetName"].ToString()
                        : "Street not provided.";
                lblHouseNumber.Text =
                    Session["HouseNumber"] != null
                        ? Session["HouseNumber"].ToString()
                        : "House number not provided.";
                lblCityName.Text =
                    Session["CityName"] != null
                        ? Session["CityName"].ToString()
                        : "City not provided.";
                lblPinCode.Text =
                    Session["PinCode"] != null
                        ? Session["PinCode"].ToString()
                        : "Pin code not provided.";
            }
        }
    }
}
