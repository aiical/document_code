using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace myControl
{
    public partial class DateControl : UserControl
    {
        private string _Field;
        private object _binSource;
        private bool _Request = false;

        public DateControl()
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
                dateEdit.Left = lbLabel.Left + lbLabel.Width + 1;
                dateEdit.Width = this.Width - (lbLabel.Left + lbLabel.Width + 2);
            }
        }

        public string EditMask
        {
            get
            {
                return dateEdit.Properties.EditMask;
            }
            set
            {
                dateEdit.Properties.EditMask = value;
            }
        }

        public string DisplayFormat
        {
            get
            {
                return dateEdit.Properties.DisplayFormat.FormatString;
            }
            set
            {
                dateEdit.Properties.DisplayFormat.FormatString = value;
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

        [Description("编辑控件"), Category("UserControl")]
        public bool Request
        {
            get
            {
                return _Request;
            }
            set
            {
                _Request = value;
                if (_Request == true)
                    lbLabel.ForeColor = Color.Green;
                else
                    lbLabel.ForeColor = Color.Black;
            }
        }

        public object GetValue()
        {
            return dateEdit.EditValue;
        }

        public void BindData()
        {
            if (DataSource == null) return;
            dateEdit.DataBindings.Clear();
            dateEdit.DataBindings.Add("EditValue", DataSource, DataField);
        }
    }
}
