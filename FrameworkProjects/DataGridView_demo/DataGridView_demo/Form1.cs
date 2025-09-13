using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridView_demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Chennai");
            comboBox1.Items.Add("Pune");
            comboBox1.Items.Add("Hyderabad");
            comboBox1.Items.Add("Mumbai");
            comboBox1.Items.Insert(0, "-- Select City --");

            comboBox1.SelectedIndex = 0;

            dataGridView1.Columns.Add("customerId", "Customer Id");
            dataGridView1.Columns.Add("customerName", "Customer Name");
            dataGridView1.Columns.Add("customerCity", "Customer City");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (
                !int.TryParse(customerId.Text, out int id)
                || customerName.Text == null
                || comboBox1.SelectedIndex <= 0
            )
            {
                MessageBox.Show("Please enter the values correctly");
                return;
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (
                    row.Cells["customerId"].Value != null
                    && row.Cells["customerId"].Value.ToString() == id.ToString()
                )
                {
                    MessageBox.Show("Customer ID already exists. Please enter a unique ID.");
                    return;
                }
            }
            dataGridView1.Rows.Add(customerId.Text, customerName.Text, comboBox1.SelectedItem);
        }
    }
}
