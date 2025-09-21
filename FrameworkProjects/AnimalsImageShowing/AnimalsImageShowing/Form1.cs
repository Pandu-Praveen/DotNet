using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimalsImageShowing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("Dog");
            listBox1.Items.Add("Tiger");
            listBox1.Items.Add("Cat");
            listBox1.Items.Add("Lion");
            listBox1.Items.Add("Rabbit");
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = Image.FromFile(@"your_path_dog.jpg");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string currAnimal = listBox1.SelectedItem as string;
            try
            {
                pictureBox1.Image = Image.FromFile($"your_path_{currAnimal}.jpg");
            }
            catch (Exception ex)
            {

                MessageBox.Show("This image is not Available in " + ex.Message, "Warning");
            }
        }
    }
}
