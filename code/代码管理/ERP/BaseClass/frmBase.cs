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
        protected bool blnLog = true; //Load事件是否加到日志中 

        public frmBase()
        {
            InitializeComponent();
            components = new Container(); 
            this.ImeMode = ImeMode.OnHalf;
        }

        private void frmBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.Control && e.Alt && e.KeyCode == Keys.F12 && DataLib.SysVar.strUGroup == "超级用户")
            {
                MessageBox.Show(this, "所在命名空间:"+GetType().Namespace+"   窗口名称:"+this.Name, "窗口信息");
            }
        }

        private void frmBase_Load(object sender, EventArgs e)
        {
            //clsIme.SetIme(this);
            if (blnLog == true && this.DesignMode == false)
               DataLib.SysVar.SetLog(this.Text, "进入","");
        }

        private void frmBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (blnLog == true)
               DataLib.SysVar.SetLog(this.Text, "离开","");
        }
    }
}