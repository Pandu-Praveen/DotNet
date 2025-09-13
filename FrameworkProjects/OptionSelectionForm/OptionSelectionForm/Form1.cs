using System;
using System.Windows.Forms;

namespace OptionSelectionForm
{
    public partial class btnSubmit : Form
    {
        public btnSubmit()
        {
            InitializeComponent();
        }

        // This method runs when the form loads
        private void btnSubmit_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("--Select the Course--");
            comboBox1.Items.Add("C#");
            comboBox1.Items.Add("Python");
            comboBox1.Items.Add("Java");
            comboBox1.SelectedIndex = 0; // Set default selected item
        }

        // Button click event handler
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a course.", "Warning");
            }
            else
            {
                selectedCourse.Text = comboBox1.SelectedItem.ToString();

                //MessageBox.Show("You selected: " + selectedCourse, "Course Selected");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Optional: code for when the selection changes
        }
    }
}
