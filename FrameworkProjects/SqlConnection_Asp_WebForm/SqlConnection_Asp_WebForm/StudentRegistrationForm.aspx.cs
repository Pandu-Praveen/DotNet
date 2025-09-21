using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SqlConnection_Asp_WebForm
{
    public partial class StudentRegistrationForm : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["conn"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCities();
            }
        }

        private void LoadCities()
        {
            
            string query = "SELECT CityId, CityName FROM tblCities";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
              
                DropDownList1.DataSource = reader;
                DropDownList1.DataTextField = "CityName";
                DropDownList1.DataValueField = "CityId";
                DropDownList1.DataBind();

                connection.Close();
            }
           
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 0)
            {
                lblMessage.Text = "Please select a valid city.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            try
            {
                //Here im checking if email already exists
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string checkQuery = "SELECT COUNT(*) FROM Students WHERE Email = @Email";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@Email", txtStudentEmail.Text.Trim());
                        connection.Open();
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        connection.Close();
                        if (count > 0)
                        {
                            lblMessage.Text = "This email is already registered!";
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                    }
                }

                //Here im inserting the data into the students table
                string query =
                    @"
                    INSERT INTO Students (Name, Address, City, PinCode, MobileNumber, Email)
                    VALUES (@Name, @Address, @City, @PinCode, @MobileNumber, @Email);
                    SELECT SCOPE_IDENTITY();";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", txtStudentName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtStudentAddress.InnerText.Trim());
                    cmd.Parameters.AddWithValue("@City", DropDownList1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@PinCode", txtStudentPinCode.Text.Trim());
                    cmd.Parameters.AddWithValue(
                        "@MobileNumber",
                        txtStudentMobileNumber.Text.Trim()
                    );
                    cmd.Parameters.AddWithValue("@Email", txtStudentEmail.Text.Trim());

                    connection.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        int rollNumber = Convert.ToInt32(result);
                        lblMessage.Text =
                            $"Your registration is successful! Your Roll Number is {rollNumber}.";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblMessage.Text = "Something went wrong.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtStudentName.Text = "";
            txtStudentAddress.InnerText = "";
            txtStudentPinCode.Text = "";
            txtStudentMobileNumber.Text = "";
            txtStudentEmail.Text = "";
            DropDownList1.SelectedIndex = 0;
            lblMessage.Text = "";
        }
    }
}
