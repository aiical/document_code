using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace myControl
{
    public partial class frmDataList : Form
    {
        public string sInvokeClass = "";
        public string strDisplayCaption = "";
        public string keyField, DisplayField;

        public lupControl myControl;
        public uLookUp upControl;

        public frmDataList()
        {
            InitializeComponent();
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sbOK_Click(object sender, EventArgs e)
        {
            if (gvQuery.FocusedRowHandle >= 0)
               this.DialogResult = DialogResult.OK;
        }

        private void gvQuery_DoubleClick(object sender, EventArgs e)
        {
            sbOK_Click(null, null);
        }

        private void txtQuery_EditValueChanged(object sender, EventArgs e)
        {
            DataView dv = null;
            if (gcQuery.DataSource.GetType().Name == "DataTable")
                dv = ((DataTable)gcQuery.DataSource).DefaultView;
            else
                dv = (DataView)gcQuery.DataSource;

            if (txtQuery.Text.Length == 0)
                dv.RowFilter = "";
            else
            {
                if (dv.Table.Columns.Contains("F_Spell") == false)
                    dv.RowFilter = "(" + keyField + " like '%" + txtQuery.Text + "%') or ( " + DisplayField + " like '%" + txtQuery.Text + "%')";
                else
                {
                    dv.RowFilter = "(" + keyField + " like '%" + txtQuery.Text + "%') or ( " + DisplayField + " like '%" + txtQuery.Text + "%') or ( F_Spell like '" + txtQuery.Text + "%')";
                }
            }
        }

        private void frmDataList_Load(object sender, EventArgs e)
        {
            //BaseClass.clsIme.SetIme(this);
            if (strDisplayCaption != "")
            {
                string[] strTitle = strDisplayCaption.Split(',');
                for(int i = 0;i < strTitle.Length; i ++)
                {
                    if (this.gvQuery.Columns[i] != null)
                       this.gvQuery.Columns[i].Caption = strTitle[i];
                }
            }
        }

        private void gvQuery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
               sbOK_Click(null, null);
        }

        private void frmDataList_Shown(object sender, EventArgs e)
        {
            txtQuery.Focus();
        }

        private void txtQuery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                gcQuery.Focus();
        }

        private void frmDataList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void sbNew_Click(object sender, EventArgs e)
        {
            string[] sName = sInvokeClass.Split('.');
            Assembly pAsm = Assembly.LoadFile(Application.StartupPath + "\\Base.dll");
            Type pType = pAsm.GetType("Base.CallBase");
            MethodInfo pmethod = pType.GetMethod(sInvokeClass);
            object obj = pAsm.CreateInstance("Base.CallBase");
            pmethod.Invoke(obj, null);
            if (myControl == null)
            {
                upControl.gridQuery.DataSource = null;
                upControl.DataBind();
                gcQuery.DataSource = upControl.gridQuery.DataSource;
            }
            else
            {
                myControl.lupEdit.Properties.DataSource = null;
                myControl.BindData();
                gcQuery.DataSource = myControl.lupEdit.Properties.DataSource;
            }
        }
    }
}