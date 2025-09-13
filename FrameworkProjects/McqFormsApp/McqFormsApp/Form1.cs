using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace McqFormsApp
{
    public partial class Form1 : Form
    {
        static int score = 0;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
                
        private void next_Click(object sender, EventArgs e)
        {
            bool isCorrect = radioButton3.Checked;
            if (isCorrect)
            {
                score++;
            }
            Form2 form2 = new Form2();
            this.Hide();
            form2.ShowDialog();
            
        }
    }
}
