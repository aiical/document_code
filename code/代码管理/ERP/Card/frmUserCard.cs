using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPrinting.Localization;
using Common;

namespace Card
{
    public partial class frmUserCard : BaseClass.frmBase
    {
        public frmUserCard()
        {
            InitializeComponent();
            SetLinkEvent();
            
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
                    case "新增":
                        New();
                        break;
                    case "编辑":
                        Edit();
                        break;
                    case "删除":
                        Del();
                        break;
                    case "预览":
                        //PrintReport(0);
                        break;
                    case "打印":
                        Print();
                        break;
                    case "导出":
                        Export();
                        break;
                    case "关闭":
                        Close();
                        break;

                }
            }
        }


        private void New()
        {
            frmEditUserCard F = new frmEditUserCard();
            F.New();
            if (F.ShowDialog() == DialogResult.OK)
                DataBind();
            F.Dispose();
        }

        private void Edit()
        {
            if (viewQuery.FocusedRowHandle < 0) return;
            DataRow dr = viewQuery.GetDataRow(viewQuery.FocusedRowHandle);
            frmEditUserCard F = new frmEditUserCard();
            F.Edit(Convert.ToDecimal(dr["Aid"]));
            if (F.ShowDialog() == DialogResult.OK)
                DataBind();
            F.Dispose();
        }

        private void Del()
        {
            if (viewQuery.FocusedRowHandle < 0) return;
            if (MessageBox.Show(this, "真的要删除本记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataRow dr = viewQuery.GetDataRow(viewQuery.FocusedRowHandle);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_UserCard where Aid = " + dr["Aid"].ToString()) == 0)
                viewQuery.DeleteRow(viewQuery.FocusedRowHandle);
        }

        private void frmKQReport_Shown(object sender, EventArgs e)
        {
            if (DesignMode == false)
            {
                DataBind();
                DataLib.sysClass.LoadFormatFromDB(viewQuery, this.Name, 0);
            }
        }

        private void DataBind()
        {
            string strSQL = @"select a.*,b.F_Name,c.F_Name as F_Dept,d.F_Name as F_ClassName from t_UserCard a
                              left join t_Emp b
                              on a.F_ID = b.F_ID
                              left join t_Class c
                              on b.F_Type = c.F_ID
                              left join t_SetClass d
                              on a.F_Class = d.F_ID
                              where a.F_Date >= '" +ucDate1.dtStart.ToString()+@"'
                              and a.F_Date <= '"+ucDate1.dtEnd.ToString()+"'";

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gridQuery.DataSource = ds.Tables[0];

        }


        private void ucDate1_RefreshDateChanged(object sender, EventArgs e)
        {
            DataBind();
        }

        private void frmKQReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7 && DataLib.SysVar.strUGroup == "超级用户")
            {
                Common.frmSetGrid myGrid = new Common.frmSetGrid();
                myGrid.gvSource = viewQuery;
                myGrid.ShowDialog();
                myGrid.Dispose();
            }

            if (e.KeyCode == Keys.F5 && DataLib.SysVar.strUGroup == "超级用户")
            {
                DataLib.sysClass.SaveGridToDB(viewQuery, this.Name, 0);
            }
        }

        /// <summary>
        /// 预览
        /// </summary>
        protected virtual void Print()
        {
            PreviewLocalizer plZer = new XtraChinese.DxperienceXtraPrintingLocalizationCHS();
            DataLib.sysClass myClass = new DataLib.sysClass();
            myClass.DoPreview(this.Text, plZer, this.printingSystem);
        }

        /// <summary>
        /// 引出Excel
        /// </summary>
        private void Export()
        {
            string strFile = DataLib.sysClass.ShowSaveFileDialog("Excel 文件", "Excel 文件|*.Xls");
            if (strFile != "")
                viewQuery.ExportToExcelOld(strFile);
        }
    }
}
