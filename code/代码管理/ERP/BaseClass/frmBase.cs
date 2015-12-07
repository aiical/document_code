using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BaseClass
{
    public partial class frmBase : Form
    {
        protected bool blnLog = true; //Load�¼��Ƿ�ӵ���־�� 

        public frmBase()
        {
            InitializeComponent();
            components = new Container(); 
            this.ImeMode = ImeMode.OnHalf;
        }

        private void frmBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.Control && e.Alt && e.KeyCode == Keys.F12 && DataLib.SysVar.strUGroup == "�����û�")
            {
                MessageBox.Show(this, "���������ռ�:"+GetType().Namespace+"   ��������:"+this.Name, "������Ϣ");
            }
        }

        private void frmBase_Load(object sender, EventArgs e)
        {
            //clsIme.SetIme(this);
            if (blnLog == true && this.DesignMode == false)
               DataLib.SysVar.SetLog(this.Text, "����","");
        }

        private void frmBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (blnLog == true)
               DataLib.SysVar.SetLog(this.Text, "�뿪","");
        }
    }
}