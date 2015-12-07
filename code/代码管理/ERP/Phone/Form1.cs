using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace Phone
{
    public partial class Form1 : Form
    {
        public static readonly string NewLine = "\r\n";
        public Form1()
        {
            InitializeComponent();
        }

        IModem modem = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            modem = new Modem();
            modem.Ring += new EventHandler<RingEventArgs>(modem_Ring);
            try
            {
                modem.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private string phoneNumber = string.Empty;
        void modem_Ring(object sender, RingEventArgs e)
        {
            this.phoneNumber = e.PhoneNumber;
            this.ShowPhoneNumber();
        }


        private void ShowPhoneNumber()
        {
            if (textBox1.InvokeRequired)
            {
                this.Invoke(new System.Windows.Forms.MethodInvoker(ShowPhoneNumber));
            }
            else
            {
                textBox1.Text += this.phoneNumber + NewLine;
            }
        }
    }
}