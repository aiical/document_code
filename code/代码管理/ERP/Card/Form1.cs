using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Card
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmRegDevice F = new frmRegDevice();
            F.ShowDialog();
            F.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmSetDevice F = new frmSetDevice();
            F.ShowDialog();
            F.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmNetDevice F = new frmNetDevice();
            F.ShowDialog();
            F.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmTimPick F = new frmTimPick();
            F.ShowDialog();
            F.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmNetDevice F = new frmNetDevice();
            F.iFlag = 1;
            F.ShowDialog();
            F.Dispose();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            frmSetClass F = new frmSetClass();
            F.ShowDialog();
            F.Dispose();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            frmKQRule F = new frmKQRule();
            F.ShowDialog();
            F.Dispose();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            frmCardReport F = new frmCardReport();
            F.ShowDialog();
            F.Dispose();
        }
    }
}
