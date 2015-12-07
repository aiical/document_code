using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPrinting.Localization; 

namespace Cash
{
    public partial class frmCashList : BaseClass.frmBase
    {
        public frmCashList()
        {
            InitializeComponent();
            lbTag.Parent = pcTitle;
            Point Pos = new Point(2, 8);
            lbTag.Location = Pos;
            //DataLib.SysVar.strDB = "tsJxc";
            //DataLib.SysVar.strServer = "127.0.0.1";
        }

        /// <summary>
        /// 测试权限
        /// </summary>
        /// <returns></returns>
        protected bool TestRight(string strName, string sTag)
        {
            if (DataLib.SysVar.strUGroup == "超级用户") return true;
            string strSQL = "select * from t_RightDetail where F_Group = '" + DataLib.SysVar.strUGroup + "' and F_Class = '" + sTag + "' and F_Name = '" + strName + "' and F_Enable = 1";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("对不起，你无权限!!", "提示");
                return false;
            }
            else
                return true;
        }

        #region 业务

        private void DataBind()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_DayAccount");
            gcList.DataSource = ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// 新增
        /// </summary>
        private void New()
        {
            if (TestRight("新增", this.Name) == false) return;
            frmEditCash myEditCash = new frmEditCash();
            myEditCash.bFlag = true;
            myEditCash.ShowDialog();
            myEditCash.Dispose();
            DataBind();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        private void Edit()
        {
            if (gvList.FocusedRowHandle < 0) return;
            if (TestRight("编辑", this.Name) == false) return;
            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);
            frmEditCash myEditCash = new frmEditCash();
            myEditCash.bFlag = false;
            myEditCash.decID = Convert.ToDecimal(dr["F_DayOrder"]);
            myEditCash.dtDate = Convert.ToDateTime(dr["F_Date"]);
            myEditCash.ShowDialog();
            myEditCash.Dispose();
            DataBind();
        }

        /// <summary>
        /// 删除
        /// </summary>
        private void Del()
        {
            if (gvList.FocusedRowHandle < 0) return;
            if (TestRight("删除", this.Name) == false) return;
            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);
            if (MessageBox.Show(this, "真的删除选定分录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();

            if (myHelper.ExecuteSQL("delete from t_DayAccount where F_Date = '" + dr["F_Date"].ToString() + "' and F_DayOrder = '" + dr["F_DayOrder"].ToString() + "'") == 0)
                DataBind();
        }

        /// <summary>
        /// 打印
        /// </summary>
        private void Print()
        {
            if (TestRight("打印", this.Name) == false) return;
            PreviewLocalizer plZer = new Common.XtraChinese.DxperienceXtraPrintingLocalizationCHS();
            DataLib.sysClass myClass = new DataLib.sysClass();
            myClass.DoPrint(this.Text, plZer, this.printingSystem);
        }

        /// <summary>
        /// 预览
        /// </summary>
        private void Preview()
        {
            if (TestRight("预览", this.Name) == false) return;
            PreviewLocalizer plZer = new Common.XtraChinese.DxperienceXtraPrintingLocalizationCHS();
            DataLib.sysClass myClass = new DataLib.sysClass();
            myClass.DoPreview(this.Text, plZer, this.printingSystem);
        }

        /// <summary>
        /// 引出
        /// </summary>
        private void Export()
        {
            if (TestRight("引出", this.Name) == false) return;
            string strFile = DataLib.sysClass.ShowSaveFileDialog("Excel 文件", "Excel 文件|*.Xls");
            if (strFile != "")
                gvList.ExportToExcelOld(strFile);
        }

        /// <summary>
        /// 过滤
        /// </summary>
        private void Filter()
        {
        }

        #endregion


        private void tsClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void tsPrint_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void tsPreview_Click(object sender, EventArgs e)
        {
            Preview();
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            New();
        }

        private void tsEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void frmCashList_Load(object sender, EventArgs e)
        {
            if (this.DesignMode == false)
                DataBind();
        }

        private void tsDel_Click(object sender, EventArgs e)
        {
            Del();
        }
    }
}

