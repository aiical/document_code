using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace myControl
{
    public partial class FilterControl : UserControl
    {
        private string _FilterFields = "";
        private DevExpress.XtraGrid.GridControl _gc;
        public FilterControl()
        {
            InitializeComponent();
        }

        [Description("过滤字段，用;号分隔"), Category("UserControl")]
        public string FilterFields
        {
            get
            {
                return _FilterFields;
            }
            set
            {
                _FilterFields = value;
            }
        }

        public DevExpress.XtraGrid.GridControl DataGrid
        {
            get
            {
                return _gc;
            }
            set
            {
                _gc = value;
            }
        }

        private DataView GetDataView()
        {
            DataView dv = null;
            if (DataGrid.DataSource == null) return null;
            switch (DataGrid.DataSource.GetType().Name)
            {
                case "DataTable":
                    dv = ((DataTable)DataGrid.DataSource).DefaultView;
                    break;
                case "DataView":
                    dv = (DataView)DataGrid.DataSource;
                    break;
                case "DataSet":
                    dv = ((DataSet)DataGrid.DataSource).Tables[0].DefaultView;
                    break;
            }
            return dv;
        }

        private void FilterControl_Resize(object sender, EventArgs e)
        {
            this.Height = 21;
        }

        private void txtFilter_EditValueChanged(object sender, EventArgs e)
        {
            DataView dv = GetDataView();
            if (dv == null) return;

            string strFilter = "";

            if (FilterFields == "")
            {
                foreach (DataColumn dc in dv.Table.Columns)
                {
                    if (dc.DataType.ToString() == "System.String")
                    {
                        strFilter = strFilter + "(" + dc.ColumnName + " like '" + txtFilter.Text + "%') or";
                    }
                }

                strFilter = strFilter.Substring(0, strFilter.Length - 2);
                dv.RowFilter = strFilter;
            }

            else
            {
                string[] Fields = FilterFields.Split(';');

                foreach (string s in Fields)
                {
                    if (s == "F_Spell")
                    {
                        if (dv.Table.Columns.Contains(s) == false) continue;
                    }
                    strFilter = strFilter + "(" + s + " like '" + txtFilter.Text + "%') or";
                }

                if (strFilter != "")
                {
                    strFilter = strFilter.Substring(0, strFilter.Length - 2);
                    dv.RowFilter = strFilter;
                }
            }
        }

       
    }
}
