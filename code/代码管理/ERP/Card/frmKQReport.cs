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
    public partial class frmKQReport : BaseClass.frmBase
    {
        public frmKQReport()
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


        /// <summary>
        /// 填充树型
        /// </summary>
        protected void FillDept(string strType, TreeNode ParentNode)
        {

            TreeNode Node = null, cNode = null;
            string strSQL = "";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (ParentNode == null)
            {
                //strTVType = strType;
                ParentNode = tvDept.Nodes.Add("", "所有部门", 0);
                ParentNode.Tag = "";
                FillDept(strType, ParentNode);
            }
            else
            {
                strSQL = "select F_ID,F_Name from t_Class where F_UPID = '" + strType + "'";

                DataSet ds = myHelper.GetDs(strSQL);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    cNode = ParentNode.Nodes.Add(dr["F_ID"].ToString(), dr["F_ID"].ToString() + " (" + dr["F_Name"].ToString() + ")", 0);

                    cNode.Tag = dr["F_ID"].ToString();
                    FillDept(dr["F_ID"].ToString(), cNode);
                }
            }
        }

        private void frmKQReport_Shown(object sender, EventArgs e)
        {
            if (DesignMode == false)
            {
                FillDept("03", null);
                tvDept.SelectedNode = tvDept.TopNode;
                tvDept.TopNode.Expand();
                DataLib.sysClass.LoadFormatFromDB(viewQuery, this.Name, 0);
            }
        }

        protected virtual void DataBind(string strType)
        {
           
        }

        private void tvDept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DataBind(e.Node.Tag.ToString());
        }

        private void ucDate1_RefreshDateChanged(object sender, EventArgs e)
        {
            DataBind(tvDept.SelectedNode.Tag.ToString());
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
