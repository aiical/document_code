using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace OA
{
    public partial class frmEditOAFile : Common.frmDialog
    {
        private string strSQL;
        public frmEditOAFile()
        {
            InitializeComponent();
        }

        public override void New()
        {
            base.New();
            strSQL = "select * from t_OAFile where Aid = 0";
            if (blnBind == false)
                BindData();
            DataRow dr = ((DataRowView)binData.AddNew()).Row;
            dr.BeginEdit();
            dr["F_Date"] = DataLib.SysVar.GetDate();
            dr["F_BuildMan"] = DataLib.SysVar.strUName;
            dr.EndEdit();
            binData.EndEdit();
            dateControl1.Focus();
        }

        public override void Edit(string sID)
        {
            strSQL = "select * from t_OAFile where Aid = " + sID;
            BindData();
        }

        protected override void BindData()
        {
            strSaveSlaverSQL = strSQL;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            binData.DataSource = ds.Tables[0].DefaultView;
            base.BindData();
        }

        private void sbView_Click(object sender, EventArgs e)
        {
            DataRow dr = ((DataRowView)binData.Current).Row;
            DataLib.sysClass myClass = new DataLib.sysClass();
            myClass.LoadFileFromDr(dr, "F_FileName", "F_File");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog F = new OpenFileDialog();
            if (F.ShowDialog() == DialogResult.No) return;
            string[] str = F.FileName.Split('\\');
            string sFile = str[str.Length - 1];
            FileStream s = File.OpenRead(F.FileName);
            byte[] bytes = new byte[s.Length];
            s.Read(bytes, 0, Convert.ToInt32(s.Length));
            DataRow dr = ((DataRowView)binData.Current).Row;
            dr.BeginEdit();
            dr["F_FileName"] = sFile;
            dr["F_File"] = bytes;
            dr.EndEdit();
            s.Close();
        }
    }
}
