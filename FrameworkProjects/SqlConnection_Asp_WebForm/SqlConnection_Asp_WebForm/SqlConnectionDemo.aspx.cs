using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SqlConnection_Asp_WebForm
{
    public partial class SqlConnectionDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }
            
        protected void btnConnect_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            lblMessage.Text = "Connection Opened Successfully";
            conn.Close();
        }
    }
}
