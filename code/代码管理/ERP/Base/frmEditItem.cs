using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;

namespace Base
{
    public partial class frmEditItem : Common.frmDialog
    {
        public string strType = "";
        private string strSQL;
        private string strUnit;

        public frmEditItem()
        {
            InitializeComponent();
            blnNew = true;
            gbox.Parent = Page1;
            gbox.Dock = DockStyle.Fill;
            strNoCopyField = "F_ID";
        }

        protected override void CopyRecord()
        {

            int i,intCnt;
            intCnt = binUnit.Count;
            
            DataRow[] dr = new DataRow[intCnt];
            for(i = 0;i <= intCnt - 1;i++)
            {
                dr[i] = ((DataRowView)binUnit[i]).Row;
                
            }
            base.CopyRecord();

            if (binUnit.Count > 0) binUnit.RemoveCurrent();
            DataTable dt = ((DataView)binUnit.DataSource).Table;
            for (i = 0; i <= intCnt - 1; i++)
            {
                DataRow drUnit = ((DataRowView)binUnit.AddNew()).Row;
                foreach (DataColumn dc in dt.Columns)
                {
                    drUnit[dc.ColumnName] = dr[i][dc.ColumnName];
                    
                }
                drUnit.EndEdit();
            }
        }

        private void GetFile(int intFlag)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                switch (intFlag)
                {
                    case 1:
                        editControl7.SetValue(openFileDialog.FileName);
                        break;
                    case 2:
                        editControl8.SetValue(openFileDialog.FileName);
                        break;
                    case 3:
                        editControl10.SetValue(openFileDialog.FileName);
                        break;
                    case 4:
                        editControl11.SetValue(openFileDialog.FileName);
                        break;
                }
            }
        }

        /// <summary>
        /// 填充单位
        /// </summary>
        private void FillUnit()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select F_Name from t_Assist where F_Type = '计量单位'");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cbUnit.Items.Add(dr["F_Name"]);
            }
        }

        /// <summary>
        /// 填充颜色
        /// </summary>
        private void FillColor()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select F_Name from t_Assist where F_Type = '颜色'");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cbColor.AddItem(dr["F_Name"]);
            }           
        }

        private void SetDropSource()
        {
            string strSQL = "select F_ID,F_Name from t_Class where left(F_ID,3) = '04.'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            lupControl1.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl1.LookUpDisplayField = "F_Name";
            lupControl1.LookUpKeyField = "F_ID";

            strSQL = "select F_ID,F_Name from t_Storage";
            DataSet ds1 = myHelper.GetDs(strSQL);
            lupControl2.LookUpDataSource = ds1.Tables[0].DefaultView;
            lupControl2.LookUpDisplayField = "F_Name";
            lupControl2.LookUpKeyField = "F_ID";

            strSQL = "select F_ID,F_Name from t_Supplier";
            DataSet ds2 = myHelper.GetDs(strSQL);
            lupControl3.LookUpDataSource = ds2.Tables[0].DefaultView;
            lupControl3.LookUpDisplayField = "F_Name";
            lupControl3.LookUpKeyField = "F_ID";
        }

        public override void New()
        {
            strSQL = "select * from t_Item where F_ID = ''";
            strUnit = "select * from t_Unit where F_ItemID = ''";

            if (blnBind == false)
            {
                BindData();
                FillColor();
                FillUnit();
            }
            else
            {
                DataLib.DataHelper myHelper = new DataLib.DataHelper();
                DataSet ds1 = myHelper.GetDs(strUnit);
                binUnit.DataSource = ds1.Tables[0].DefaultView;
            }
            DataRow dr = ((DataRowView)binData.AddNew()).Row;
            dr.BeginEdit();
            dr["F_ID"] = GetMaxCode("原材料","t_Item");
            dr["F_Type"] = strType;
            dr["F_Kind"] = "原材料";
            dr["F_Attrib"] = "原材料";
            dr["F_CalStorage"] = true;
            if (DataLib.SysVar.GetParmValue("F_N9") == true)
            {
                dr["F_BarCode"] = DataLib.sysClass.GetRandom();
            }
            dr.EndEdit();
            binData.EndEdit();
            xtraTabControl1.SelectedTabPageIndex = 0;
            editControl1.Focus();
            NewUnit();
            base.New();
        }

        private void NewUnit()
        {
            DataRow drUnit = ((DataRowView)binUnit.AddNew()).Row;
            drUnit["F_Main"] = true;
            drUnit["F_Rate"] = 1;
        }

        public override void Edit(string strID)
        {
            ckOption.Checked = false;
            base.Edit(strID);
            strSQL = "select * from t_Item where F_ID = '" + strID + "'";
            strUnit = "select * from t_Unit where F_ItemID = '" + strID + "'";
            BindData();
            FillColor();
            FillUnit();
        }

        /// <summary>
        /// 保存前检查
        /// </summary>
        /// <returns></returns>
        protected override bool SavePre()
        {
            int m = 0;
            if (base.SavePre() == false) return false;
            DataRow drItem = ((DataRowView)binData.Current).Row;
            binUnit.EndEdit();
            int intCnt = binUnit.Count;
            binUnit.MoveFirst();
            for (int i = 0; i < intCnt; i++)
            {
                DataRow dr = ((DataRowView)binUnit.Current).Row;
                if (dr["F_Name"] == DBNull.Value)
                {
                    MessageBox.Show("单位名称不能为空!!");
                    Page2.Focus();
                    return false;
                }
                if (Convert.ToBoolean(dr["F_Main"]) == true)
                    m = m + 1;
                dr["F_ItemID"] = drItem["F_ID"];
                binUnit.MoveNext();
            }
            if (m > 1)
            {
                MessageBox.Show("不能同时存在多个主单位!!", "提示");
                xtraTabControl1.SelectedTabPageIndex = 1;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        protected override bool Save()
        {
            //return base.Save();
            binData.EndEdit();
            if (SavePre() == false) return false;
            DataSet ds = ((DataView)binData.DataSource).Table.DataSet;
            DataSet dsUnit = ((DataView)binUnit.DataSource).Table.DataSet;

            DataSet[] dsData = new DataSet[2];
            dsData[0] = ds;
            dsData[1] = dsUnit;

            string[] strSQL = new string[2];
            strSQL[0] = strSaveSlaverSQL;
            strSQL[1] = strUnit;

            DataLib.DataHelper myHelper = new DataLib.DataHelper();

            if (myHelper.SaveMuteData(dsData, strSQL).Length == 0)
            {
                ds.AcceptChanges();
                dsUnit.AcceptChanges();
                return true;
            }
            else
                return false;
        }

        protected override void BindData()
        {
            strSaveSlaverSQL = strSQL;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            binData.DataSource = ds.Tables[0].DefaultView;
            SetDropSource();

            DataSet ds1 = myHelper.GetDs(strUnit);
            binUnit.DataSource = ds1.Tables[0].DefaultView;
            base.BindData();
            peItem.DataBindings.Add("EditValue", binData, "F_Photo");

            foreach (Control uCon in Page4.Controls)
            {
                if (uCon is myControl.EditControl)
                    (uCon as myControl.EditControl).BindData();

                if (uCon is myControl.lupControl)
                    (uCon as myControl.lupControl).BindData();

                if (uCon is myControl.cbControl)
                    (uCon as myControl.cbControl).BindData();

                if (uCon is myControl.DateControl)
                    (uCon as myControl.DateControl).BindData();

                if (uCon is myControl.SpinControl)
                    (uCon as myControl.SpinControl).BindData();

                if (uCon is myControl.ckControl)
                    (uCon as myControl.ckControl).BindData();
            }


        }

        private void sbAdd_Click(object sender, EventArgs e)
        {
            NewUnit();
        }

        private void sbDel_Click(object sender, EventArgs e)
        {
            binUnit.RemoveCurrent();
        }

        private void sbLoad_Click(object sender, EventArgs e)
        {
            string strFile = DataLib.sysClass.ShowOpenFileDialog("图片文件", "所有文件|*.*");
            if (strFile != "")
            {
                 peItem.Image = Image.FromFile(strFile);
            }
                
        }

        private void peItem_DoubleClick(object sender, EventArgs e)
        {
            frmPic myPic = new frmPic();
            myPic.pePic.Image = peItem.Image;
            myPic.ShowDialog();
            myPic.Dispose();
        }

        private void sbClear_Click(object sender, EventArgs e)
        {
            peItem.Image = null;
        }

        private void ckOption_CheckedChanged(object sender, EventArgs e)
        {
            blnNew = ckOption.Checked;
        }

        private void frmEditItem_Load(object sender, EventArgs e)
        {
            editControl1.Focus();
            this.radioButton3.Checked = true;
            /*
            string[] strKind;
            DataLib.sysClass myClass = new DataLib.sysClass();
            strKind = myClass.GetItemKind();

            for (int i = 0; i < strKind.Length; i++)
            {
                cbControl1.AddItem(strKind[i]);
            }
             */ 
        }

        private void frmEditItem_Shown(object sender, EventArgs e)
        {
            editControl1.Focus();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            GetFile(1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            GetFile(2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            GetFile(3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            GetFile(4);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbControl1_SelectIndexChange(object sender, EventArgs e)
        {
           
        }
    }
}

