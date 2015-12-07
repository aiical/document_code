using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPrinting.Localization; 

namespace Product
{
    public partial class frmProductArrange : BaseClass.frmBase
    {
        public frmProductArrange()
        {
            InitializeComponent();
            ucDate.Parent = pcTitle;
            Point Pos1 = new Point(ucDate.Left, 10);
            ucDate.Location = Pos1;
        }

        private void FillDept()
        {
            string strSQL = "";
            strSQL = "select F_ID,F_Name from t_Class where F_ID like '03.%' ";
            strSQL = strSQL + "union ";
            strSQL = strSQL + "select '','所有部门'";

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            lupDept.Properties.DataSource = ds.Tables[0].DefaultView;
            lupDept.Properties.DisplayMember = "F_Name";
            lupDept.Properties.ValueMember = "F_ID";

        }

        /// <summary>
        /// 排程分析
        /// </summary>
        private void Anly()
        {
            if (MessageBox.Show(this, "排程分析可能需要一些时间，你要进行此操作吗?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            string strSQL = "";
            string strHour = "";
            decimal decQty = 0;
            decimal decTotalHour = 0;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            int intCnt = gvList.RowCount;
            for (int i = 0; i < intCnt; i++)
            {
                DataRow dr = gvList.GetDataRow(i);
                string strItemID = dr["F_ItemID"].ToString();
                decQty = Convert.ToDecimal(dr["F_Qty"]);

                strSQL = "select c.AID,c.F_DeptID,sum(b.F_WorkHour) as F_WorkHour ";
                strSQL = strSQL + "from t_ProductProcess a,t_ProductProcessDetail b,";
                strSQL = strSQL + "(select AID,F_DeptID from t_ArrangeDept) c ";
                strSQL = strSQL + "where a.F_BillID = b.F_BillID ";
                strSQL = strSQL + "and b.F_DeptID = c.F_DeptID ";
                strSQL = strSQL + "and a.F_ItemID = '"+strItemID+"'";
                strSQL = strSQL + "group by c.AID,c.F_DeptID";

                DataSet ds = myHelper.GetDs(strSQL);

                foreach (DataRow drArrange in ds.Tables[0].Rows)
                {
                    strHour = "F_ManHour" + drArrange["AID"].ToString();
                    dr[strHour] = decQty * Convert.ToDecimal(drArrange["F_WorkHour"]);
                    decTotalHour = decTotalHour + Convert.ToDecimal(drArrange["F_WorkHour"]);
                }

                dr["F_TotalHour"] = decQty * decTotalHour;

                ds.Dispose();
            }
        }

        private void DataBind()
        {     
            string strSQL = "select a.*,b.F_Name,b.F_Spec,c.F_Name as F_ClientName ";
            strSQL = strSQL + "from t_ProductArrange a,t_Item b,t_Client c ";
            strSQL = strSQL + "where a.F_ItemID = b.F_ID ";
            strSQL = strSQL + "and a.F_Client = c.F_ID ";
            strSQL = strSQL + "and F_Date >= '" + ucDate.dtStart.ToString()+"'";
            strSQL = strSQL + "and F_Date <= '" + ucDate.dtEnd.ToString()+ "'";
            strSQL = strSQL + "order by a.F_OrderBill,a.Aid";

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gcList.DataSource = ds.Tables[0].DefaultView;
        }

        private void tbClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbExport_Click(object sender, EventArgs e)
        {
            string strFile = DataLib.sysClass.ShowSaveFileDialog("Excel 文件", "Excel 文件|*.Xls");
            if (strFile != "")
                gvList.ExportToExcelOld(strFile);
        }

        private void tbPreview_Click(object sender, EventArgs e)
        {
            PreviewLocalizer.Active = new Common.XtraChinese.DxperienceXtraPrintingLocalizationCHS();
            this.printingSystem.Links[0].ShowPreview();
        }

        private void tbPrint_Click(object sender, EventArgs e)
        {
            this.printingSystem.Links[0].PrintDlg();
        }

        private void frmProductArrange_Shown(object sender, EventArgs e)
        {
            BaseClass.frmFlag myFlag = new BaseClass.frmFlag();
            myFlag.Show();
            myFlag.Update();
            try
            {
                DataBind();
                SetColumn();
                ShowHeader();
                FillDept();
            }
            finally
            {
                myFlag.Dispose();
            }
        }

        private void ucDate_RefreshDateChanged(object sender, EventArgs e)
        {
            DataBind();
        }

        /// <summary>
        /// 生成生产计划单
        /// </summary>
        private void GenPlan()
        {
            if (gvList.RowCount == 0) return;
            if (lupDept.Text.Length == 0) return; 
            if (MessageBox.Show(this, "真的要生成生产计划单吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            string strDept = lupDept.EditValue.ToString();
            frmProductPlan myProductPlan = new frmProductPlan(((DataView)gcList.DataSource).Table,strDept);
            //myProductPlan.GenBill(((DataView)gcList.DataSource).Table.DataSet,strDept);
            myProductPlan.ShowDialog();
            myProductPlan.Dispose();   
        }

        private void SetColumn()
        {
            string strDate1,strDate2,strDate3,strHour,strQty;

            int j = 0;
            for (int i = 0; i < 20; i++)
            {
                j = i + 1;
                strDate1 = "F_Date"+j.ToString()+"1";
                strDate2 = "F_Date"+j.ToString()+"2";
                strDate3 = "F_Date"+j.ToString()+"3";
                strHour = "F_ManHour" + j.ToString();
                strQty = "F_FinishQty" + j.ToString();
                gvList.Columns.ColumnByFieldName(strDate1).Caption = "开始日期";
                gvList.Columns.ColumnByFieldName(strDate2).Caption = "计划完成";
                gvList.Columns.ColumnByFieldName(strDate3).Caption = "实际完成";
                gvList.Columns.ColumnByFieldName(strHour).Caption = "总工时";
                gvList.Columns.ColumnByFieldName(strQty).Caption = "完成量";
                gvList.Bands["gridBand"+j.ToString()].Columns.Add(gvList.Columns.ColumnByFieldName(strDate1));
                gvList.Bands["gridBand" + j.ToString()].Columns.Add(gvList.Columns.ColumnByFieldName(strDate2));
                gvList.Bands["gridBand" + j.ToString()].Columns.Add(gvList.Columns.ColumnByFieldName(strDate3));
                gvList.Bands["gridBand" + j.ToString()].Columns.Add(gvList.Columns.ColumnByFieldName(strHour));
                gvList.Bands["gridBand" + j.ToString()].Columns.Add(gvList.Columns.ColumnByFieldName(strQty));
                gvList.Bands["gridBand" + j.ToString()].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gvList.Bands["gridBand" + j.ToString()].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

            }

            gvList.Bands["gridBand21"].Columns.Add(gvList.Columns.ColumnByFieldName("F_Client"));
            gvList.Bands["gridBand21"].Columns.Add(gvList.Columns.ColumnByFieldName("F_ClientName"));
            gvList.Bands["gridBand21"].Columns.Add(gvList.Columns.ColumnByFieldName("F_OrderBill"));
            gvList.Bands["gridBand21"].Columns.Add(gvList.Columns.ColumnByFieldName("F_Date"));
            gvList.Bands["gridBand21"].Columns.Add(gvList.Columns.ColumnByFieldName("Aid"));
            gvList.Bands["gridBand21"].Columns.Add(gvList.Columns.ColumnByFieldName("F_ItemID"));
            gvList.Bands["gridBand21"].Columns.Add(gvList.Columns.ColumnByFieldName("F_Name"));
            gvList.Bands["gridBand21"].Columns.Add(gvList.Columns.ColumnByFieldName("F_Spec"));
            gvList.Bands["gridBand21"].Columns.Add(gvList.Columns.ColumnByFieldName("F_Unit"));
            gvList.Bands["gridBand21"].Columns.Add(gvList.Columns.ColumnByFieldName("F_Qty"));
            gvList.Bands["gridBand21"].Columns.Add(gvList.Columns.ColumnByFieldName("F_Price"));
            gvList.Bands["gridBand21"].Columns.Add(gvList.Columns.ColumnByFieldName("F_Money"));
            gvList.Bands["gridBand21"].Columns.Add(gvList.Columns.ColumnByFieldName("F_CutOff"));
            gvList.Bands["gridBand21"].Columns.Add(gvList.Columns.ColumnByFieldName("F_Finish"));
            gvList.Bands["gridBand21"].Columns.Add(gvList.Columns.ColumnByFieldName("F_TotalHour"));
            gvList.Bands["gridBand21"].Columns.Add(gvList.Columns.ColumnByFieldName("F_SendDate"));
            gvList.Bands["gridBand21"].Columns.Add(gvList.Columns.ColumnByFieldName("F_Remark"));
            gvList.Bands["gridBand21"].Caption = "订单信息";
            gvList.Bands["gridBand21"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvList.Bands["gridBand21"].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gvList.BestFitColumns();
        }

        private void ShowHeader()
        {
            string strSQL = "select a.Aid,a.F_DeptID,b.F_Name as F_Dept from t_ArrangeDept a,t_Class b where a.F_DeptID = b.F_ID";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);

            for (int i = 1; i < 21; i++)
            {
                gvList.Bands["gridBand" + i.ToString()].Visible = false;
            }
            
            int m = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                m = m + 1;
                gvList.Bands["gridBand" + m.ToString()].Caption = dr["F_Dept"].ToString();
                gvList.Bands["gridBand" + m.ToString()].Visible = true;
            }
        }

        private void frmProductArrange_Load(object sender, EventArgs e)
        {     

        }

        private void SaveData()
        {
            gvList.PostEditor();
            DataSet ds = ((DataView)gcList.DataSource).Table.DataSet;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.SaveData(ds, "select * from t_ProductArrange") == 0)
            {
                MessageBox.Show("数据保存成功!!", "提示");
            }
        }

        private void tbSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void sbGenPlan_Click(object sender, EventArgs e)
        {
            GenPlan();
        }

        private void sbAnly_Click(object sender, EventArgs e)
        {
            Anly();
        }
    }
}

