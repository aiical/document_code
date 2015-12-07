using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;

namespace myControl
{
    public delegate void SelectIndexChangeEventHandler(object sender, System.EventArgs e);

    [Serializable] 
    public partial class cbControl : UserControl
    {
        private event SelectIndexChangeEventHandler EventHandler;//事件
        private string _Field;
        private object _binSource;
        private bool _Request = false;
        private ComboBoxItem[] _cbItem = null;
        private TextEditStyles _TextStyle = TextEditStyles.Standard;

        public cbControl()
        {
            InitializeComponent();
        }

        //事件属性
        [
        Category("UserControl"),
        Description("当期间改变刷新时发生")
        ]
        public event SelectIndexChangeEventHandler SelectIndexChange
        {
            add
            {
                EventHandler += value;
                cbEdit.SelectedIndexChanged += new EventHandler(EventHandler);
            }
            remove
            {
                EventHandler -= value;
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
                cbEdit.Left = lbLabel.Left + lbLabel.Width + 1;
                cbEdit.Width = this.Width - (lbLabel.Left + lbLabel.Width + 2);
            }
        }

        public int SelectedIndex
        {
            get
            {
                return cbEdit.SelectedIndex;
            }
            set
            {
                cbEdit.SelectedIndex = value;
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

        [Description("编辑控件"), Category("UserControl")]
        public ComboBoxItem[] cbItem
        {
            get
            {
                return _cbItem;
            }
            set
            {
                _cbItem = value;
                if (cbItem != null)
                    cbEdit.Properties.Items.AddRange(cbItem);
            }
        }

        [Description("编辑控件"), Category("UserControl")]
        public TextEditStyles EditStyle
        {
            get
            {
                return _TextStyle;
            }
            set
            {
                _TextStyle = value;
                cbEdit.Properties.TextEditStyle = _TextStyle;
            }
        }

        public void BindData()
        {
            if (DataSource == null) return;
            cbEdit.DataBindings.Clear();
            cbEdit.DataBindings.Add("EditValue", DataSource, DataField);
        }

        public object GetValue()
        {
            return cbEdit.EditValue;
        }

        public void SetValue(object value)
        {
            cbEdit.EditValue = value;
        }


        public void AddItem(object value)
        {
            cbEdit.Properties.Items.Add(value);
        }

    }
}
