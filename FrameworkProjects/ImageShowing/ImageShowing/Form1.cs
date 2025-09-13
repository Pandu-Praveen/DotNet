using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageShowing
{
    public partial class Form1 : Form
    {
        private bool showFirstImage = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
       



        private void btnShow_Click(object sender, EventArgs e)
        {
            
            try
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
              
                if (showFirstImage)
                {
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Praveen.S3\Downloads\dotnet1.jpg");
                }
                else
                {
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Praveen.S3\Downloads\dotnet2.jpg");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message);
            }
            showFirstImage = !showFirstImage;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }
    }
}


   

        
    