using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;

namespace myControl
{
    [DefaultBindingProperty("EditValue")]
    public partial class uLookUp : UserControl
    {
        private event ButtonClickEventHandler EventHandler;//事件
        private event SelectChangeEventHandler ValueChangedHandler; 

        private string _DropSQL = "";
        private string _ValueMember = "";
        private string _DisplayMember = "";
        private object _Value;
        private string _DisplayCaption = "";
        private string _InvokeClass = "";
        private string _DataField;
        private object _DataSource;

        private bool _Request;

        private bool bSelected = false;
        private bool bModify = false;

        public uLookUp()
        {
            InitializeComponent();
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
                pEdit.EditValueChanged += new EventHandler(ValueChangedHandler);
            }
            remove
            {
                ValueChangedHandler -= value;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            viewQuery.BestFitColumns();
            if (this.DesignMode == false) DataBind();
        }

        public void DataBind()
        {
            if (DropSQL == "") return;
            if (ValueMember == "") return;
            if (DisplayMember == "") return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(DropSQL);
            gridQuery.DataSource = ds.Tables[0];
            viewQuery.ClearSelection();
            
        }

        public void BindData()
        {
            this.DataBindings.Clear();
            this.DataBindings.Add("EditValue", DataSource, DataField);

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

        [Description("数据源"), Category("UserControl")]
        public object DataSource
        {
            get
            {
                return _DataSource;
            }
            set
            {
                _DataSource = value;
            }
        }

        [Description("关联字段"), Category("UserControl")]
        public string DataField
        {
            get
            {
                return _DataField;
            }
            set
            {
                _DataField = value;
            }
        }

        [Description("列名中文显示"), Category("UserControl")]
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

        /// <summary>
        /// 数据值
        /// </summary>
        /// <returns></returns>
        public object EditValue
        {
            get{ return _Value;}
            set
            {
                if (value != _Value)
                {
                    _Value = value;
                    if (_Value != null)
                    {
                        //if (gridQuery.DataSource == null) return;
                        //DataTable dt = (DataTable)gridQuery.DataSource;
                        //DataRow[] dr = dt.Select(ValueMember + "= '" + _Value.ToString() + "'");
                        //if (dr.Length > 0) pEdit.Text = dr[0][DisplayMember].ToString();

                    }
                }
            }
        }

        /// <summary>
        /// 下拉SQL
        /// </summary>
        public string DropSQL
        {
            get{ return _DropSQL;}
            set{ _DropSQL = value;}
        }

        /// <summary>
        /// 显示字段
        /// </summary>
        public string ValueMember
        {
            get { return _ValueMember; }
            set { _ValueMember = value; }
        }

        /// <summary>
        /// 数据字段
        /// </summary>
        public string DisplayMember
        {
            get { return _DisplayMember; }
            set { _DisplayMember = value; }
        }

        private void pEdit_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
        {
            if (viewQuery.SelectedRowsCount == 0) return;
            if (viewQuery.FocusedRowHandle < 0) return;
            bSelected = true;
            DataRow dr = viewQuery.GetDataRow(viewQuery.FocusedRowHandle);
            e.Value = dr[DisplayMember];
            EditValue = dr[ValueMember];
            DataTable dt = ((DataTable)gridQuery.DataSource);
            dt.DefaultView.RowFilter = "";
        }

        [Description("字符描述"), Category("UserControl")]
        public string EditLabel
        {
            get
            {
                return lbLabel.Text;
            }
            set
            {
                lbLabel.Text = value;
                pEdit.Left = lbLabel.Left + lbLabel.Width + 1;
                pEdit.Width = this.Width - (lbLabel.Left + lbLabel.Width + sbSelect.Width + 2);
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
            return pEdit.EditValue;
        }

        public void SetValue(object Value)
        {
            pEdit.EditValue = Value;
        }



        private void viewQuery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pEdit.ClosePopup();
            }
        }

        private void viewQuery_Click(object sender, EventArgs e)
        {
            pEdit.ClosePopup();
        }

        private void pEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (gridQuery.DataSource != null && pEdit.IsModified == true && bSelected == false && bModify == true)
            {

                pEdit.ShowPopup();
                pEdit.Focus();
                DataTable dt = ((DataTable)gridQuery.DataSource);

                string strFilter = "";
                foreach (DataColumn dc in dt.Columns)
                {
                    strFilter = strFilter + "(" + dc.ColumnName + " like '" + pEdit.Text + "%') or";
                }

                strFilter = strFilter.Substring(0, strFilter.Length - 2);

                dt.DefaultView.RowFilter = strFilter;

            }
            else
            {
                bSelected = false;
                bModify = true;
            }

        }

        private void pEdit_Popup(object sender, EventArgs e)
        {
            int iRow = viewQuery.LocateByDisplayText(0, viewQuery.Columns[DisplayMember], pEdit.Text);
            viewQuery.FocusedRowHandle = iRow;
        }

        private void uLookUp_Resize(object sender, EventArgs e)
        {
            this.Height = 21;
        }

        private void ShowData()
        {
            frmDataList myDataList = new frmDataList();
            if (gridQuery.DataSource != null)
            {
                myDataList.strDisplayCaption = DisplayCaption;
                myDataList.gcQuery.DataSource = gridQuery.DataSource;
                myDataList.keyField = ValueMember;
                myDataList.DisplayField = DisplayMember;
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

            myDataList.upControl = this;
            if (InvokeClass == "") myDataList.sbNew.Visible = false;
            myDataList.sInvokeClass = InvokeClass;
            if (myDataList.ShowDialog() == DialogResult.OK)
            {
                DataRow dr = myDataList.gvQuery.GetDataRow(myDataList.gvQuery.FocusedRowHandle);
                this.EditValue = dr[ValueMember];
            }
            myDataList.Dispose();
        }

        private void sbSelect_Click(object sender, EventArgs e)
        {
            if (EventHandler == null)
                ShowData();
        }

        private void pEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9 && EventHandler == null)
            {
                ShowData();
            }

            if (e.KeyCode == Keys.Down)
            {
                viewQuery.Focus();
            }
        }

        private void pEdit_BindingContextChanged(object sender, EventArgs e)
        {
            
        }

        private void pEdit_QueryDisplayText(object sender, DevExpress.XtraEditors.Controls.QueryDisplayTextEventArgs e)
        {
            if (viewQuery.SelectedRowsCount == 0) return;
            if (viewQuery.FocusedRowHandle < 0) return;
            bSelected = true;
            DataRow dr = viewQuery.GetDataRow(viewQuery.FocusedRowHandle);
            e.DisplayText = dr[DisplayMember].ToString();
            DataTable dt = ((DataTable)gridQuery.DataSource);
            dt.DefaultView.RowFilter = "";
        }

        
    }
}
