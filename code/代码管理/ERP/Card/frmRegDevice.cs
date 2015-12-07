using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraPrinting.Localization;
using Common;

namespace Card
{
    public partial class frmRegDevice : BaseClass.frmBase
    {
        private string strQuerySQL = "";
        public frmRegDevice()
        {
            InitializeComponent();
            SetLinkEvent();
            strQuerySQL = @"select * from t_Device where (F_Uses = @Value or @Value = '')";
            tvType.ExpandAll();
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
                    case "修改":
                        Edit();
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
                        Print();
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

        /// <summary>
        /// 设置指定工具栏项可用状态
        /// </summary>
        /// <param name="sText"></param>
        /// <param name="bState"></param>
        protected void SetToolBarItemState(string sText, bool bState)
        {
            foreach (ToolStripItem tsItem in this.toolStrip.Items)
            {
                if (tsItem is ToolStripButton)
                {
                    if ((tsItem as ToolStripButton).Text == sText)
                        (tsItem as ToolStripButton).Enabled = bState;
                }
            }
        }

        private void New()
        {
            frmEditDevice F = new frmEditDevice();
            F.strType = tvType.SelectedNode.Text;
            F.New();
            if (F.ShowDialog() == DialogResult.OK)
                BindData();
            F.Dispose();
        }

        private void Edit()
        {
            if (gvBase.FocusedRowHandle < 0) return;
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            frmEditDevice F = new frmEditDevice();
            F.Edit(dr["F_ID"].ToString());
            if (F.ShowDialog() == DialogResult.OK)
                BindData();
            F.Dispose();
        }

        private void Del()
        {
            if (gvBase.FocusedRowHandle < 0) return;
            if (MessageBox.Show(this, "真的要删除本记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_Device where F_ID = '" + dr["F_ID"].ToString() + "'") == 0)
                gvBase.DeleteRow(gvBase.FocusedRowHandle);
        }

        private Hashtable GetParm()
        {
            Hashtable parm = new Hashtable();
            if (tvType.SelectedNode.Level == 0)
                parm.Add("@Value", "");
            else
                parm.Add("@Value", tvType.SelectedNode.Text);

            return parm;
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        protected virtual void BindData()
        {
            if (strQuerySQL.Length == 0) return;
            BaseClass.frmFlag myFlag = new BaseClass.frmFlag();
            myFlag.Show();
            myFlag.Update();
            try
            {
                DataLib.DataHelper myHelper = new DataLib.DataHelper();
                DataSet ds = myHelper.GetOtherDs(strQuerySQL, GetParm());
                if (ds == null) return;
                int intRow = gvBase.FocusedRowHandle;
                gcBase.DataSource = ds.Tables[0].DefaultView;
                DataLib.SysVar.TestColumnRight(gvBase, this.Name);
                if (intRow <= gvBase.RowCount)
                    gvBase.FocusedRowHandle = intRow;
            }
            finally
            {
                myFlag.Dispose();
            }
        }

        private void frmRegDevice_Shown(object sender, EventArgs e)
        {
            if (DesignMode == false)
            {
                BindData();
            }
            DataLib.sysClass.LoadFormatFromDB(gvBase, this.Name, 0);
        }

        private void tvType_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0)
                SetToolBarItemState("增加", false);
            else
                SetToolBarItemState("增加", true);
            BindData();
        }

        private void gvBase_DoubleClick(object sender, EventArgs e)
        {
            Edit();
        }

        private void frmRegDevice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7 && DataLib.SysVar.strUGroup == "超级用户")
            {
                Common.frmSetGrid myGrid = new Common.frmSetGrid();
                myGrid.gvSource = gvBase;
                myGrid.ShowDialog();
                myGrid.Dispose();
            }

            if (e.KeyCode == Keys.F5 && DataLib.SysVar.strUGroup == "超级用户")
            {
                DataLib.sysClass.SaveGridToDB(gvBase, this.Name, 0);
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

    }
}
