using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace myControl
{
    public partial class ckControl : UserControl
    {
        private string _Field;
        private object _binSource;

        public ckControl()
        {
            InitializeComponent();
            ckEdit.Top = 0;
            this.Height = ckEdit.Height;
        }

        [Description("编辑控件"), Category("UserControl")]
        public string EditLabel
        {
            get
            {
                return ckEdit.Text;
            }
            set
            {
                ckEdit.Text = value;
                ckEdit.Left = 0;
                ckEdit.Width = this.Width;
            }
        }

        [Description("编辑控件"), Category("UserControl")]
        public object DataSource
        {
            get
            {
                return _binSource;
            }
            set
            {
                _binSource = value;
            }
        }

        [Description("编辑控件"), Category("UserControl")]
        public string DataField
        {
            get
            {
                return _Field;
            }
            set
            {
                _Field = value;
            }
        }

        public void BindData()
        {
            if (DataSource == null) return;
            ckEdit.DataBindings.Clear();
            ckEdit.DataBindings.Add("EditValue", DataSource, DataField);
        }

        public object GetValue()
        {
            return ckEdit.EditValue;
        }

        public void SetValue(string value)
        {
            ckEdit.EditValue = value;
        }

        private void EditControl_Load(object sender, EventArgs e)
        {

        }
    }
}