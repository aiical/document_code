using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Card
{
    public partial class frmSetClass : BaseClass.frmBase
    {
        public frmSetClass()
        {
            InitializeComponent();
            GridClass.AutoGenerateColumns = false;
            SetLinkEvent();
            BindData();
            SetDropDataSource();
        }

        private void SetDropDataSource()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select F_ID,F_Name from t_Class where F_UPID = '03'");
            lupDept.Properties.DataSource = ds.Tables[0];
            lupDept.Properties.DisplayMember = "F_Name";
            lupDept.Properties.ValueMember = "F_ID";
        }

        private void SetLinkEvent()
        {
            foreach (ToolStripItem tsItem in toolStrip.Items)
            {
                if (tsItem is ToolStripButton)
                {
                    (tsItem as ToolStripButton).Click += new EventHandler(ButtonClick);
                }
            }

        }

        private void ButtonClick(object sender, EventArgs e)
        {
            if (sender is ToolStripButton)
            {
                switch ((sender as ToolStripButton).Text)
                {
                    case "增加":
                        New();
                        break;
                    case "保存":
                        Save();
                        break;
                    case "删除":
                        Del();
                        break;
                    case "刷新":
                        BindData();
                        break;
                    case "预览":
                        //PrintReport(0);
                        break;
                    case "打印":
                        //Print();
                        break;
                    case "引出":
                        //ExportData();
                        break;
                    case "关闭":
                        Close();
                        break;

                }
            }
        }

        private void New()
        {
            DataRow dr = ((DataRowView)binData.AddNew()).Row;
            dr["F_Type"] = "正常班次";
            dr["F_qd1"] = false;
            dr["F_qt1"] = false;
            dr["F_jb1"] = false;
            dr["F_qd2"] = false;
            dr["F_qt2"] = false;
            dr["F_jb2"] = false;

            dr["F_qd3"] = false;
            dr["F_qt3"] = false;
            dr["F_jb3"] = false;

            dr["F_qd4"] = false;
            dr["F_qt4"] = false;
            dr["F_jb4"] = false;

            dr["F_qd5"] = false;
            dr["F_qt5"] = false;
            dr["F_jb5"] = false;


        }

        private void Save()
        {
            binData.EndEdit();
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.SaveData(((DataTable)binData.DataSource).DataSet, "select * from t_SetClass") == 0)
            {
                MessageBox.Show(this, "数据保存成功!", "提示");
            }
        }

        private void Del()
        {
            if (GridClass.CurrentRow.Index < 0) return;
            if (MessageBox.Show(this, "真的要删除本记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataGridViewRow dr= GridClass.CurrentRow;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_SetClass where F_ID = '" + dr.Cells["F_ID"].Value.ToString() + "'") == 0)
                GridClass.Rows.Remove(GridClass.CurrentRow);
        }

        private void BindData()
        {
            string strSQL = "select * from t_SetClass";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            binData.DataSource = ds.Tables[0];
            GridClass.DataSource = binData;
            BindControl();
        }

        private void BindControl()
        {
            txtID.DataBindings.Clear();
            txtID.DataBindings.Add("Text", binData, "F_ID");
            txtName.DataBindings.Clear();
            txtName.DataBindings.Add("Text", binData, "F_Name");
            lupDept.DataBindings.Clear();
            lupDept.DataBindings.Add("EditValue", binData, "F_DeptID");
            cbType.DataBindings.Clear();
            cbType.DataBindings.Add("Text", binData, "F_Type");

            spinEdit1.DataBindings.Clear();
            spinEdit1.DataBindings.Add("EditValue", binData, "F_zgs");

            checkEdit1.DataBindings.Clear();
            checkEdit1.DataBindings.Add("EditValue", binData, "F_qd1");
            spinEdit2.DataBindings.Clear();
            spinEdit2.DataBindings.Add("EditValue", binData, "F_qq1");
            timeEdit1.DataBindings.Clear();
            timeEdit1.DataBindings.Add("EditValue", binData, "F_sb1");
            spinEdit3.DataBindings.Clear();
            spinEdit3.DataBindings.Add("EditValue", binData, "F_xx1");
            checkEdit2.DataBindings.Clear();
            checkEdit2.DataBindings.Add("EditValue", binData, "F_qt1");
            timeEdit2.DataBindings.Clear();
            timeEdit2.DataBindings.Add("EditValue", binData, "F_xb1");
            spinEdit4.DataBindings.Clear();
            spinEdit4.DataBindings.Add("EditValue", binData, "F_tc1");
            checkEdit3.DataBindings.Clear();
            checkEdit3.DataBindings.Add("EditValue", binData, "F_jb1");
            spinEdit5.DataBindings.Clear();
            spinEdit5.DataBindings.Add("EditValue", binData, "F_gs1");

            checkEdit6.DataBindings.Clear();
            checkEdit6.DataBindings.Add("EditValue", binData, "F_qd2");
            spinEdit9.DataBindings.Clear();
            spinEdit9.DataBindings.Add("EditValue", binData, "F_qq2");
            timeEdit4.DataBindings.Clear();
            timeEdit4.DataBindings.Add("EditValue", binData, "F_sb2");
            spinEdit8.DataBindings.Clear();
            spinEdit8.DataBindings.Add("EditValue", binData, "F_xx2");
            checkEdit5.DataBindings.Clear();
            checkEdit5.DataBindings.Add("EditValue", binData, "F_qt2");
            timeEdit3.DataBindings.Clear();
            timeEdit3.DataBindings.Add("EditValue", binData, "F_xb2");
            spinEdit7.DataBindings.Clear();
            spinEdit7.DataBindings.Add("EditValue", binData, "F_tc2");
            checkEdit4.DataBindings.Clear();
            checkEdit4.DataBindings.Add("EditValue", binData, "F_jb2");
            spinEdit6.DataBindings.Clear();
            spinEdit6.DataBindings.Add("EditValue", binData, "F_gs2");

            checkEdit9.DataBindings.Clear();
            checkEdit9.DataBindings.Add("EditValue", binData, "F_qd3");
            spinEdit13.DataBindings.Clear();
            spinEdit13.DataBindings.Add("EditValue", binData, "F_qq3");
            timeEdit6.DataBindings.Clear();
            timeEdit6.DataBindings.Add("EditValue", binData, "F_sb3");
            spinEdit12.DataBindings.Clear();
            spinEdit12.DataBindings.Add("EditValue", binData, "F_xx3");
            checkEdit8.DataBindings.Clear();
            checkEdit8.DataBindings.Add("EditValue", binData, "F_qt3");
            timeEdit5.DataBindings.Clear();
            timeEdit5.DataBindings.Add("EditValue", binData, "F_xb3");
            spinEdit11.DataBindings.Clear();
            spinEdit11.DataBindings.Add("EditValue", binData, "F_tc3");
            checkEdit7.DataBindings.Clear();
            checkEdit7.DataBindings.Add("EditValue", binData, "F_jb3");
            spinEdit10.DataBindings.Clear();
            spinEdit10.DataBindings.Add("EditValue", binData, "F_gs3");

            checkEdit12.DataBindings.Clear();
            checkEdit12.DataBindings.Add("EditValue", binData, "F_qd4");
            spinEdit17.DataBindings.Clear();
            spinEdit17.DataBindings.Add("EditValue", binData, "F_qq4");
            timeEdit8.DataBindings.Clear();
            timeEdit8.DataBindings.Add("EditValue", binData, "F_sb4");
            spinEdit16.DataBindings.Clear();
            spinEdit16.DataBindings.Add("EditValue", binData, "F_xx4");
            checkEdit11.DataBindings.Clear();
            checkEdit11.DataBindings.Add("EditValue", binData, "F_qt4");
            timeEdit7.DataBindings.Clear();
            timeEdit7.DataBindings.Add("EditValue", binData, "F_xb4");
            spinEdit15.DataBindings.Clear();
            spinEdit15.DataBindings.Add("EditValue", binData, "F_tc4");
            checkEdit10.DataBindings.Clear();
            checkEdit10.DataBindings.Add("EditValue", binData, "F_jb4");
            spinEdit14.DataBindings.Clear();
            spinEdit14.DataBindings.Add("EditValue", binData, "F_gs4");

            checkEdit15.DataBindings.Clear();
            checkEdit15.DataBindings.Add("EditValue", binData, "F_qd5");
            spinEdit21.DataBindings.Clear();
            spinEdit21.DataBindings.Add("EditValue", binData, "F_qq5");
            timeEdit10.DataBindings.Clear();
            timeEdit10.DataBindings.Add("EditValue", binData, "F_sb5");
            spinEdit20.DataBindings.Clear();
            spinEdit20.DataBindings.Add("EditValue", binData, "F_xx5");
            checkEdit14.DataBindings.Clear();
            checkEdit14.DataBindings.Add("EditValue", binData, "F_qt5");
            timeEdit9.DataBindings.Clear();
            timeEdit9.DataBindings.Add("EditValue", binData, "F_xb5");
            spinEdit19.DataBindings.Clear();
            spinEdit19.DataBindings.Add("EditValue", binData, "F_tc5");
            checkEdit13.DataBindings.Clear();
            checkEdit13.DataBindings.Add("EditValue", binData, "F_jb5");
            spinEdit18.DataBindings.Clear();
            spinEdit18.DataBindings.Add("EditValue", binData, "F_gs5");

        }
    }
}
