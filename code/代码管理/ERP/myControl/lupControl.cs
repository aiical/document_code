using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using System.Collections;
using System.Drawing.Design;

namespace myControl
{
    //事件代表的声明RefreshDateEventArgs
    public delegate void ButtonClickEventHandler(object sender, System.EventArgs e);
    public delegate void SelectChangeEventHandler(object sender, System.EventArgs e);

    public partial class lupControl : UserControl
    {    
        private event ButtonClickEventHandler EventHandler;//事件
        private event SelectChangeEventHandler ValueChangedHandler; 
        private string _Field;
        private string _keyField;
        private string _DisplayField;
        private string _DisplayCaption = "";
        private string _InvokeClass = "";
        private string _dropSQL = "";
        private object _binSource;
        private DataView _dvSource;
        private bool _Request = false;

        private Hashtable _LinkFields;

        public lupControl()
        {
            InitializeComponent();
            lupEdit.EditValueChanged += new EventHandler(SelectValueChanged);
        }

        //事件属性
        [
        Category("UserControl"),
        Description("当期间改变刷新时发生")
        ]
        public event ButtonClickEventHandler ButtonClick
        {
            add
            {
                EventHandler += value;
                sbSelect.Click += new EventHandler(EventHandler);
            }
            remove
            {
                EventHandler -= value;
            }
        }

        //事件属性
        [
        Category("UserControl"),
        Description("值改变时发生")
        ]
        public event SelectChangeEventHandler ValueChanged
        {
            add
            {
                ValueChangedHandler += value;
                lupEdit.EditValueChanged += new EventHandler(ValueChangedHandler);
            }
            remove
            {
                ValueChangedHandler -= value;
            }
        }

        private void SelectValueChanged(object sender,EventArgs e)
        {
            if (LinkFields != null)
            {
                if (LinkFields.Count == 0) return;
                if (lupEdit.EditValue == DBNull.Value) return;
                DataRow drSource = ((DataRowView)lupEdit.Properties.GetDataSourceRowByKeyValue(lupEdit.EditValue)).Row;

                BindingSource binData = (BindingSource)DataSource;
                binData.EndEdit(); 
                DataRow dr = ((DataRowView)binData.Current).Row;

                if (dr.RowState == DataRowState.Unchanged) return;

                dr.BeginEdit();
                dr[DataField] = drSource[LookUpKeyField];
                dr.EndEdit();
                foreach (DictionaryEntry de in LinkFields)
                {
                    dr.BeginEdit();
                    dr[de.Key.ToString()] = drSource[de.Value.ToString()];
                    dr.EndEdit();
                }
                
            }
        }

        /// <summary>
        /// 动态执行类库
        /// </summary>
        public string InvokeClass
        {
            get
            {
                return _InvokeClass;
            }
            set
            {
                _InvokeClass = value;
            }
        }

        [Description("下拉控件"), Category("UserControl")]
        public string EditLabel
        {
            get
            {
                return lbLabel.Text;
            }
            set
            {
                lbLabel.Text = value;
                lupEdit.Left = lbLabel.Left + lbLabel.Width + 1;
                lupEdit.Width = this.Width - (lbLabel.Left + lbLabel.Width + sbSelect.Width + 2);
            }
        }

        [Description("关联字段设置"),Category("UserControl"),Editor(typeof(ParmTypeEdit), typeof(UITypeEditor))]
        public Hashtable LinkFields
        {
            get
            {
                return _LinkFields;
                //return ParseParameters(DropSQL);
            }
            set
            {
                _LinkFields = value;
            }
        }

        [Description("下拉控件"), Category("UserControl")]
        public string DisplayCaption
        {
            get
            {
                return _DisplayCaption;
            }
            set
            {
                _DisplayCaption = value;
            }
        }

        [Description("编辑控件"), Category("UserControl")]
        public DataView LookUpDataSource
        {
            get
            {
                return _dvSource;
            }
            set
            {
                _dvSource = value;
                lupEdit.Properties.DataSource = value;
            }
        }

        [Description("编辑控件"), Category("UserControl")]
        public string LookUpKeyField
        {
            get
            {
                return _keyField;
            }
            set
            {
                _keyField = value;
                lupEdit.Properties.ValueMember = value;
            }
        }

        [Description("编辑控件"), Category("UserControl")]
        public string LookUpDisplayField
        {
            get
            {
                return _DisplayField;
            }
            set
            {
                _DisplayField = value;
                lupEdit.Properties.DisplayMember = value;
            }
        }

        [Description("下拉控件"), Category("UserControl")]
        public string DropSQL
        {
            get
            {
                return _dropSQL;
            }
            set
            {
                _dropSQL = value;
            }
        }


        public DevExpress.XtraEditors.LookUpEdit LookUpControl
        {
            get
            {
                return this.lupEdit; 
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

        public int PopWidth
        {
            get
            {
                return lupEdit.Properties.PopupWidth;
            }
            set
            {
                lupEdit.Properties.PopupWidth = value;
            }
        }

        public object GetValue()
        {
            return lupEdit.EditValue;
        }

        public void SetValue(object Value)
        {
            lupEdit.EditValue = Value;
        }
             
        private DataView GetDropDataSource()
        {
            if (DropSQL != "")
            {
                DataLib.DataHelper myHelper = new DataLib.DataHelper();
                return myHelper.GetDs(DropSQL).Tables[0].DefaultView;
            }
            else
                return null;
        }

        public void BindData()
        {
            if (DataSource == null) return;

            if (lupEdit.Properties.DataSource == null)
                lupEdit.Properties.DataSource = GetDropDataSource();

            lupEdit.DataBindings.Clear();
            lupEdit.DataBindings.Add("EditValue", DataSource, DataField);
           
        }

        private void ShowData()
        {
            frmDataList myDataList = new frmDataList();
            if (lupEdit.Properties.DataSource != null)
            {
                myDataList.strDisplayCaption = DisplayCaption;
                myDataList.gcQuery.DataSource = lupEdit.Properties.DataSource;
                myDataList.keyField = _keyField;
                myDataList.DisplayField = _DisplayField;
                foreach (GridColumn gc in myDataList.gvQuery.Columns)
                {
                    if (gc.FieldName == "F_ID")
                    {
                        gc.Width = 100;
                        gc.Caption = "编码";
                    }

                    if (gc.FieldName == "F_Name")
                    {
                        gc.Width = 200;
                        gc.Caption = "名称";
                    }

                    if (gc.FieldName == "F_Spell")
                    {
                        gc.Width = 100;
                        gc.Caption = "拼音码";
                    }

                    
                }
            }
            myDataList.myControl = this;
            if (InvokeClass == null) myDataList.sbNew.Visible = false;
            if (InvokeClass == "") myDataList.sbNew.Visible = false;
            myDataList.sInvokeClass = InvokeClass;
            if (myDataList.ShowDialog() == DialogResult.OK)
            {
                DataRow dr = myDataList.gvQuery.GetDataRow(myDataList.gvQuery.FocusedRowHandle);
                lupEdit.EditValue = dr[_keyField];
            }
            myDataList.Dispose();
        }

        private void sbSelect_Click(object sender, EventArgs e)
        {
            if (EventHandler == null)
                ShowData();
        }

        private void lupEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9 && EventHandler == null)
                ShowData();
        }
    }
}
