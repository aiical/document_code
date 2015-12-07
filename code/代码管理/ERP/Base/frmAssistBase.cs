using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base
{
    public partial class frmAssistBase : BaseClass.frmBase
    {
        public frmAssistBase()
        {
            InitializeComponent();
        }

        private void DataBind(string strType)
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_Assist where F_Type = '" + strType + "'");
            ds.Tables[0].TableNewRow += new DataTableNewRowEventHandler(RowNew);
            gcAssist.DataSource = ds.Tables[0];
        }

        private void RowNew(object sender, DataTableNewRowEventArgs e)
        {
            e.Row["F_Type"] = tvType.SelectedNode.Text;
        }

        private void tvType_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DataBind(e.Node.Text);
        }

        private void tsClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsDel_Click(object sender, EventArgs e)
        {
            gvAssist.DeleteRow(gvAssist.FocusedRowHandle);
        }

        private void tsAdd_Click(object sender, EventArgs e)
        {
            gvAssist.AddNewRow();
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            gvAssist.PostEditor();
            gvAssist.CloseEditor();

            DataSet ds = ((DataTable)gcAssist.DataSource).DataSet;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.SaveData(ds, "select * from t_Assist") == 0)
                ds.AcceptChanges();
        }
    }
}
