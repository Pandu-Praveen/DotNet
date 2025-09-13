using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressBarApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                progressBar1.Value = i;

            Thread.Sleep(10);
            }
            MessageBox.Show("Installation Completed", "Status");
            //label1.Text = "com";
        }

        //private void btnUnInstall_Click(object sender, EventArgs e)
        //{
        //    for (int i = 100;i >=0; i--)
        //    {
        //        progressBar1.Value = i;

        //        Thread.Sleep(10);
        //    }
        //    MessageBox.Show("UnInstalled Successfully", "Status");
        //}

        private void btnUnInstall_Click_1(object sender, EventArgs e)
        {
            for (int i = 100; i >= 0; i--)
            {
                progressBar1.Value = i;

                Thread.Sleep(10);
            }
            MessageBox.Show("UnInstalled Successfully", "Status");
        }

        
    }
}
