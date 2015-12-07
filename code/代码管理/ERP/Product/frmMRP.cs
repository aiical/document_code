using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Product
{
    public partial class frmMRP : BaseClass.frmBase
    {
        public frmMRP()
        {
            InitializeComponent();
        }

        private void sbClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sbNext_Click(object sender, EventArgs e)
        {
            switch (TabControl.SelectedTabPageIndex)
            {
                case 0:
                    TabControl.SelectedTabPage = PageSelect;
                    break;
                case 1:
                    if (rbSellOrder.Checked)
                    {
                        TabControl.SelectedTabPage = PageSellOrder;
                        ShowSellOrder(ucDate.dtStart, ucDate.dtEnd);
                        GetOrderDetail();
                    }
                    if (rbTask.Checked)
                    {
                        TabControl.SelectedTabPage = PageTask;
                        ShowTask(ucTask.dtStart, ucTask.dtEnd);
                        GetTaskDetail();
                    }
                    if (rbNeed.Checked)
                    {
                        TabControl.SelectedTabPage = PageNeed;
                        BindNeed();
                    }
                    break;
                case 2:
                    TabControl.SelectedTabPage = PageResult;
                    break;
                case 3:
                    TabControl.SelectedTabPage = PageResult;
                    break;
                case 4:
                    TabControl.SelectedTabPage = PageResult;
                    break;
                case 5:
                    break;
            }
            sbPre.Enabled = true;
        }

        private void sbPre_Click(object sender, EventArgs e)
        {
            if (TabControl.SelectedTabPageIndex == 0)
                sbPre.Enabled = false;
            else
            {
                TabControl.SelectedTabPageIndex = TabControl.SelectedTabPageIndex - 1;
                sbNext.Enabled = true;
            }
        }

        private void ShowSellOrder(DateTime dtStart,DateTime dtEnd)
        {
            string strSQL = "select cast(0 as bit) as F_Select,a.F_BillID,a.F_Date,b.F_Name as F_Client,c.F_Name as F_Dept,d.F_Name as F_Opertor,a.F_SendDate,a.F_BillMan,a.F_CheckMan,a.F_CheckDate from t_SellOrder a left join t_Client b ";
            strSQL = strSQL + "on a.F_ClientID = b.F_ID left join t_Class c on a.F_DeptID = c.F_ID left join t_Emp d on a.F_Opertor = d.F_ID where F_Check = 1 and F_Date >= '"+dtStart.ToString()+"' and F_Date <= '"+dtEnd.ToString()+"'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gcSellOrderMain.DataSource = ds.Tables[0].DefaultView;
        }

        private void GetTaskDetail()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("sp_TaskTmp");
            gcTaskTmp.DataSource = ds.Tables[0].DefaultView;
        }

        private void GetOrderDetail()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("sp_SellOrderTmp");
            gcTmp.DataSource = ds.Tables[0].DefaultView;
        }

        private void ucDate_RefreshDateChanged(object sender, EventArgs e)
        {
            ShowSellOrder(ucDate.dtStart,ucDate.dtEnd);
        }

        private void AddOrderDetail()
        {
            string strSQL;
            DataTable dt = ((DataView)gcTmp.DataSource).Table;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            int intCnt = gvSellOrderMain.RowCount;
            for (int i = 0; i < intCnt; i++)
            {
                DataRow dr = gvSellOrderMain.GetDataRow(i);
                if (Convert.ToBoolean(dr["F_Select"]) == false) continue;
                string strBill = dr["F_BillID"].ToString();
                strSQL = "select F_BillID,AID,F_ItemID,b.F_Name as F_ItemName,b.F_Spec,a.F_Unit,a.F_Qty,0 as F_EvaQty,a.F_Qty as F_NeedQty ";
                strSQL = strSQL + "from t_SellOrderDetail a,t_Item b ";
                strSQL = strSQL + "where a.F_ItemID = b.F_ID ";
                strSQL = strSQL + "and F_BillID = '" + strBill + "'";
                DataSet ds = myHelper.GetDs(strSQL);
                foreach (DataRow drItem in ds.Tables[0].Rows)
                {
                    DataRow[] drTmp = dt.Select("(F_BillID = '" + drItem["F_BillID"].ToString() + "') and AID = " + drItem["AID"].ToString());
                    if (drTmp.Length > 0) continue;
                    DataRow drNew = dt.NewRow();
                    drNew["F_Select"] = false;
                    drNew["F_BillID"] = drItem["F_BillID"];
                    drNew["AID"] = drItem["AID"];
                    drNew["F_ItemName"] = drItem["F_ItemName"];
                    drNew["F_Spec"] = drItem["F_Spec"];
                    drNew["F_Unit"] = drItem["F_Unit"];
                    drNew["F_Qty"] = drItem["F_Qty"];
                    drNew["F_EvaQty"] = drItem["F_EvaQty"];
                    drNew["F_NeedQty"] = drItem["F_NeedQty"];
                    dt.Rows.Add(drNew);
                }
            }
        }

        private void BindNeed()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("sp_NeedTmp");
            gcItem.DataSource = ds.Tables[0].DefaultView;
        }

        private void sbAdd_Click(object sender, EventArgs e)
        {
            AddOrderDetail();
        }

        private void sbRemove_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvTmp.RowCount; i++)
            {
                if (Convert.ToBoolean(gvTmp.GetRowCellValue(i, "F_Select")) == false) continue;
                gvTmp.DeleteRow(i);
            }
        }

        private void cbSelAll1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < gvSellOrderMain.RowCount; i++)
            {
                gvSellOrderMain.SetRowCellValue(i, "F_Select", cbSelAll1.Checked);
            }
        }

        private void cbSelAll2_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < gvTmp.RowCount; i++)
            {
                gvTmp.SetRowCellValue(i, "F_Select", cbSelAll2.Checked);
            }
        }

        private void sbAddRow_Click(object sender, EventArgs e)
        {
            gvItem.AddNewRow();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            gvItem.DeleteRow(gvItem.FocusedRowHandle);
            SetAutoID();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            int i = gvItem.RowCount;
            while (true)
            {
                gvItem.DeleteRow(i);
                i = gvItem.RowCount;
                if (i == 0) break;
            }
        }

        private void ItemButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CommonData.frmSelItem mySelItem = new CommonData.frmSelItem();
            //mySelItem.binDes = binSlaver;
            if (mySelItem.ShowDialog() == DialogResult.OK)
            {
                //mySelItem.gvMain.GetDataRow(i);
            }

            mySelItem.Dispose();
        }

        private void gvItem_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvItem.SetRowCellValue(e.RowHandle, "Aid", gvItem.RowCount);
        }

        /// <summary>
        /// 设置序号
        /// </summary>
        private void SetAutoID()
        {
            int intCnt = gvItem.RowCount;
            gvItem.BeginUpdate();
            for (int i = 0; i < intCnt; i++)
            {
                gvItem.SetRowCellValue(i, "Aid", i + 1);
            }
            gvItem.EndUpdate();
        }

        /// <summary>
        /// 任务单查询
        /// </summary>
        private void ShowTask(DateTime dtStart, DateTime dtEnd)
        {
            string strSQL = "select cast(0 as bit) as F_Select,* from t_Task  where F_Check = 1 and F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gcTaskMain.DataSource = ds.Tables[0].DefaultView;
        }


         /// <summary>
        /// 根据BOM展开
        /// </summary>
        private void Expand(string strItemID,decimal decQty)
        {
            string strSQL;
            decimal decMQty = 0;
            DataSet dsTmp = null;
            strSQL = "select c.F_ID,c.F_Name,c.F_Spec,b.F_Unit,b.F_Qty,b.F_Waste,b.F_ActuQty,c.F_Price ";
            strSQL = strSQL + "from t_Bom a,t_BomDetail b,t_Item c ";
            strSQL = strSQL + "where a.F_BillID = b.F_BillID ";
            strSQL = strSQL + "and b.F_ItemID = c.F_ID ";
            strSQL = strSQL + "and a.F_ItemID = '" + strItemID + "'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            /*
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                dsTmp = myHelper.GetDs("select F_ItemID from t_Bom where F_ItemID = '"+dr["F_ID"].ToString()+"'");
                if (dsTmp.Tables[0].Rows.Count > 0)
                {
                    DataRow drHalf = ((DataRowView)binHalf.AddNew()).Row;
                    drHalf["Aid"] = gvHalf.RowCount + 1;
                    drHalf["PAid"] = decGID;
                    drHalf["F_PItemID"] = strItemID; 
                    drHalf["F_ItemID"] = dr["F_ID"]; 
                    drHalf["F_ItemName"] = dr["F_Name"];
                    drHalf["F_Spec"] = dr["F_Spec"];
                    drHalf["F_Unit"] = dr["F_Unit"];
                    if (dr["F_ActuQty"] == DBNull.Value)
                        decMQty = Convert.ToDecimal(dr["F_ActuQty"]) * decQty;
                    else
                        decMQty = 0;

                    drHalf["F_Qty"] = decMQty;
                }
                else
                {
                    DataRow drItem = null;
                    DataTable dtTmp = ((DataView)binItem.DataSource).Table;
                    if (dtTmp.Select("(F_PItemID = '"+strPItemID+"') and F_ItemID = ('"+dr["F_ID"].ToString()+"')").Length > 0)
                    {
                        drItem = ((DataRowView)binItem.Current).Row;
                        if (dr["F_ActuQty"] == DBNull.Value)
                           decMQty = Convert.ToDecimal(dr["F_ActuQty"]) * decQty;
                        else
                           decMQty = 0;

                        drItem["F_Qty"] = decMQty;
                    }
                    else
                    {
                       drItem = ((DataRowView)binItem.AddNew()).Row;
                       drItem["Aid"] = gvItem.RowCount + 1;
                       drItem["PAid"] = decGID;
                       drItem["F_PItemID"] = strItemID; 
                       drItem["F_ItemID"] = dr["F_ID"]; 
                       drItem["F_ItemName"] = dr["F_Name"];
                       drItem["F_Spec"] = dr["F_Spec"];
                       drItem["F_Unit"] = dr["F_Unit"];
                       if (dr["F_ActuQty"] == DBNull.Value)
                          decMQty = Convert.ToDecimal(dr["F_ActuQty"]) * decQty;
                       else
                          decMQty = 0;

                       drItem["F_Qty"] = decMQty;
                    }

                   Expand(dr["F_ID"].ToString(),decMQty);
                }
             
            }
             */ 
        }
    }
}

