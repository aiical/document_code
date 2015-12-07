using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace myControl
{
    //事件代表的声明RefreshDateEventArgs
    public delegate void ValueChangeEventHandler(object sender, System.EventArgs e);
    public delegate void EditKeyEventHandler(object sender, KeyEventArgs e);

    public partial class EditControl : UserControl
    {
        private event ValueChangeEventHandler eventHandler;//事件
        private event EditKeyEventHandler keyEventHandler;
        private string _Field = "";
        private object _binSource;
        private bool _Request = false;

        public EditControl()
        {
            InitializeComponent();
            txtEdit.Top = 0;
            this.Height = txtEdit.Height;
        }

        //事件属性
        [
        Category("UserControl"),
        Description("当数据改变时发生")
        ]
        public event ValueChangeEventHandler ValueChanged
        {
            add
            {
                eventHandler += value;
                txtEdit.Leave += new EventHandler(eventHandler);
            }
            remove
            {
                eventHandler -= value;
            }
        }

        //事件属性
        [
        Category("UserControl"),
        Description("当数据改变时发生")
        ]
        public event EditKeyEventHandler EditKeyDown
        {
            add
            {
                keyEventHandler += value;
                txtEdit.KeyDown += new KeyEventHandler(keyEventHandler);
            }
            remove
            {
                keyEventHandler -= value;
            }
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
                txtEdit.Left = lbLabel.Left + lbLabel.Width + 1;
                txtEdit.Width = this.Width - (lbLabel.Left + lbLabel.Width + 2);
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
                    lbLabel.ForeColor = Color.Black ;
            }
        }

        public void BindData()
        {
            if (DataSource == null) return;
            if (DataField == "") return;
            txtEdit.DataBindings.Clear();
            txtEdit.DataBindings.Add("EditValue", DataSource, DataField);
        }

        public object GetValue()
        {
            return txtEdit.EditValue;
        }

        public void SetValue(string value)
        {
            txtEdit.EditValue = value;
        }

        private void EditControl_Load(object sender, EventArgs e)
        {

        }
    }
}