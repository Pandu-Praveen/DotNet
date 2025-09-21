using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2_DisconnectedArchitecture
{
    public partial class Form1 : Form
    {
        static string connectionString =
            "your_connection_string_here";
        static SqlConnection conn = new SqlConnection(connectionString);
        static SqlDataAdapter da;
        static DataSet ds;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(connectionString);  
               
                ds = new DataSet();
                da = new SqlDataAdapter("select * from users", conn);
                da.Fill(ds, "users");
                dataGridView1.DataSource = ds.Tables["users"];
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(da);
            da.Update(ds, "users");
            MessageBox.Show("Original Database is updated");
        }
    }
}
