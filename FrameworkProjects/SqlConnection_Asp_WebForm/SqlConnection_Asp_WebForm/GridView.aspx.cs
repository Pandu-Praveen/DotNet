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
    public partial class GridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            string connectionString = ConfigurationManager
                .ConnectionStrings["conn"]
                .ConnectionString;
            string query = "SELECT * FROM Students";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(query, connection))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    GridView2.DataSource = ds;
                    GridView2.DataBind();
                }
            }
        }
    }
}
