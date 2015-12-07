using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace myControl
{
    public partial class SpinControl : UserControl
    {
        private string _Field;
        private object _binSource;

        public SpinControl()
        {
            InitializeComponent();
        }

        [Description("编辑控件"), Category("UserControl")]
        public string EditLabel
        {
            get
            {
                return lbLabel.Text;
            }
            set
            {
                lbLabel.Text = value;
                spinEdit.Left = lbLabel.Left + lbLabel.Width + 1;
                spinEdit.Width = this.Width - (lbLabel.Left + lbLabel.Width + 2);
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

        public object GetValue()
        {
            return spinEdit.EditValue;
        }


        public void SetValue(object value)
        {
            spinEdit.EditValue = value;
        }

        public void BindData()
        {
            if (DataSource == null) return;

            spinEdit.DataBindings.Clear();
            spinEdit.DataBindings.Add("EditValue", DataSource, DataField);
        }
    }
}
