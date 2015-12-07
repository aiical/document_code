using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPrinting.Localization;
using System.IO;
using System.Collections; 

namespace OA
{
    public partial class frmViewList : BaseClass.frmBase
    {
        private string _ReportTag = "";
        protected string strQuerySQL = "";
        public frmViewList()
        {
            InitializeComponent();
            SetLinkEvent();
            
        }

        /// <summary>
        /// 报表标志
        /// </summary>
        protected string ReportTag
        {
            get
            {
                if (_ReportTag == "")
                    _ReportTag = this.Name;
                return _ReportTag;
            }
            set
            {
                _ReportTag = value;
            }
        }

        protected void SetToolBarItemVisible(string sCaption, bool bState)
        {
            foreach (ToolStripItem tsItem in toolStrip.Items)
            {
                if (tsItem is ToolStripButton)
                {
                    if ((tsItem as ToolStripButton).Text == sCaption)
                    {
                        (tsItem as ToolStripButton).Visible = bState;
                    }
                }
            }
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

            this.KeyDown += new KeyEventHandler(FormKeyDown);
            this.Shown += new EventHandler((FormShown));
            this.gvList.DoubleClick += new EventHandler(GridDoubleClick);

        }

        private void ButtonClick(object sender, EventArgs e)
        {
            if (sender is ToolStripButton)
            {
                switch ((sender as ToolStripButton).Text)
                {
                    case "新增":
                        //if (DataLib.SysVar.TestRight(this.Name, "新增") == true)
                        //{
                            New();
                        //}
                        break;
                    case "编辑":
                        //if (DataLib.SysVar.TestRight(this.Name, "编辑") == true)
                        //{
                            Edit();
                        //}
                        break;
                    case "删除":
                        //if (DataLib.SysVar.TestRight(this.Name, "删除") == true)
                        //{
                            Del();
                        //}
                        break;
                    case "预览":
                        //if (DataLib.SysVar.TestRight(this.Name, "预览") == true)
                        //{
                            PrintReport(0);
                        //}
                        break;
                    case "打印":
                        //if (DataLib.SysVar.TestRight(this.Name, "打印") == true)
                        //{
                            PrintReport(1);
                        //}
                        break;
                    case "引出":
                        //if (DataLib.SysVar.TestRight(this.Name, "引出") == true)
                        //{
                            ExportData();
                        //}
                        break;
                    case "关闭":
                        Close();
                        break;

                }
            }
        }

        private void FormShown(object sender, EventArgs e)
        {
            if (this.DesignMode == false)
            {
                lbTitle.Text = this.Text;
                SetSQL();
            }
        }

        /// <summary>
        /// 设置表格格式
        /// </summary>
        protected virtual void SetGridFormat()
        {
            Common.frmSetGrid myGrid = new Common.frmSetGrid();
            myGrid.gvSource = gvList;
            myGrid.ShowDialog();
            myGrid.Dispose();
        }

        /// <summary>
        /// 设置SQL语句
        /// </summary>
        private void SetSQL()
        {
            gvList.Columns.Clear();
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_SQL where F_Class = '" + ReportTag + "' and F_Tag = 0");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["F_SQL"] != Convert.DBNull)
                {
                    strQuerySQL = ds.Tables[0].Rows[0]["F_SQL"].ToString();
                    BindData();
                }
            }
            ds.Dispose();
        }

        /// <summary>
        /// 期间报表  
        /// </summary>
        /// <returns></returns>
        protected virtual Hashtable GetParm()
        {
            Hashtable parm = new Hashtable();
            parm.Add("@Start", ucDate.dtStart);
            parm.Add("@End", ucDate.dtEnd);
            return parm;
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        protected virtual int BindData()
        {
            if (strQuerySQL.Length == 0) return -1;

            BaseClass.frmFlag myFlag = new BaseClass.frmFlag();
            myFlag.Show();
            myFlag.Update();

            try
            {
                try
                {
                    DataLib.DataHelper myHelper = new DataLib.DataHelper();
                    DataSet ds;

                    if (ucDate.Visible == true)
                        ds = myHelper.GetOtherDs(strQuerySQL, GetParm());
                    else
                        ds = myHelper.GetDs(strQuerySQL);
                    //if (rgOption.Visible == false)
                    //{
                    //    ds = myHelper.GetOtherDs(strQuerySQL, GetParm());
                    //}
                    //else
                    //{
                    //    ds = myHelper.GetOtherDs(strQuerySQL, GetParm1());
                    //}

                    if (ds == null) return -1;
                    //gvReport.Columns.Clear();
                    gcList.DataSource = ds.Tables[0].DefaultView;
                    //AssignField();
                    DataLib.sysClass.LoadFormatFromDB(gvList, ReportTag, 0);
                    DataLib.SysVar.TestColumnRight(gvList, this.Name);
                    return 0;
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message, "错误");
                    return -1;
                }
            }
            finally
            {
                myFlag.Dispose();
            }

        }



        private void FormKeyDown(object sender,KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7 && DataLib.SysVar.strUGroup == "超级用户")
            {
                SetGridFormat();
            }

            if (e.KeyCode == Keys.F5 && DataLib.SysVar.strUGroup == "超级用户")
            {
                DataLib.sysClass.SaveGridToDB(gvList, ReportTag, 0);
                //SaveFieldFormat();
            }

            if (e.Control == true && e.KeyCode == Keys.F9 && DataLib.SysVar.strUGroup == "超级用户")
            {
                Common.frmSQL mySQL = new Common.frmSQL();
                mySQL.MeSQL.Text = strQuerySQL;
                if (mySQL.ShowDialog() == DialogResult.OK)
                {
                    strQuerySQL = mySQL.MeSQL.Text;
                    if (BindData() == 0)
                    {
                        DataLib.DataHelper myHelper = new DataLib.DataHelper();
                        string strSQL = "select * from t_SQL where F_Class = '" + ReportTag + "' and F_Tag = 0";
                        DataSet ds = myHelper.GetDs(strSQL);
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            DataRow drNew = ds.Tables[0].NewRow();
                            drNew["F_Class"] = ReportTag;
                            drNew["F_Tag"] = 0;
                            drNew["F_SQL"] = strQuerySQL;
                            ds.Tables[0].Rows.Add(drNew);
                        }
                        else
                            ds.Tables[0].Rows[0]["F_SQL"] = strQuerySQL;
                        myHelper.SaveData(ds, strSQL);
                    }

                }
                mySQL.Dispose();
            }
        }

        private void GridDoubleClick(object sender,EventArgs e)
        {
            Edit();
        }

        protected virtual void New()
        {
        }

        protected virtual void Edit()
        {
        }

        protected virtual void Del()
        {
        }

        private void PrintReport(int iFlag)
        {
            if (DataLib.SysVar.strUGroup != "超级用户")
            {
                DataLib.DataHelper myHelper = new DataLib.DataHelper();
                DataSet ds = myHelper.GetDs("select isnull(F_Print,0) as F_Print from t_UserGroup where F_Group = '" + DataLib.SysVar.strUGroup + "'");
                if (Convert.ToBoolean(ds.Tables[0].Rows[0][0]) == false)
                {
                    MessageBox.Show(this, "你没有权限!", "提示");
                    return;
                }
            }

            PreviewLocalizer plZer = new Common.XtraChinese.DxperienceXtraPrintingLocalizationCHS();
            DataLib.sysClass myClass = new DataLib.sysClass();
            if (iFlag == 0)
                myClass.DoPreview(this.Text, plZer, this.printingSystem);
            else
                myClass.DoPrint(this.Text, plZer, this.printingSystem);
        }

        private void ExportData()
        {
            if (DataLib.SysVar.strUGroup != "超级用户")
            {
                DataLib.DataHelper myHelper = new DataLib.DataHelper();
                DataSet ds = myHelper.GetDs("select F_Export from t_UserGroup where F_Group = '" + DataLib.SysVar.strUGroup + "'");
                if (Convert.ToBoolean(ds.Tables[0].Rows[0][0]) == false)
                {
                    MessageBox.Show(this, "你没有权限!", "提示");
                    return;
                }
            }

            string strFile = DataLib.sysClass.ShowSaveFileDialog("Excel 文件", "Excel 文件|*.Xls");
            if (strFile != "")
                gvList.ExportToExcelOld(strFile);
        }

        private Stream LoadReport()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_Report where FType = '" + this.Name + "'");
            if (ds.Tables[0].Rows.Count == 0) return null;
            MemoryStream stream = new MemoryStream((byte[])ds.Tables[0].Rows[0]["FReport"]);
            return stream;
        }

        private void SaveReport(DevExpress.XtraReports.UI.XtraReport r)
        {
            MemoryStream stream = new MemoryStream();
            r.SaveLayout(stream);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_Report where FType = '" + this.Name + "'");
            DataRow dr = null;
            if (ds.Tables[0].Rows.Count == 0)
            {
                dr = ds.Tables[0].NewRow();
                dr["FType"] = this.Name;
                dr["FName"] = this.Text;
                dr["FReport"] = stream.ToArray();
                dr["FDefault"] = 1;
                ds.Tables[0].Rows.Add(dr);
            }
            else
            {
                dr = ds.Tables[0].Rows[0];
                dr.BeginEdit();
                dr["FReport"] = stream.ToArray();
                dr.EndEdit();
            }

            myHelper.SaveData(ds, "select * from t_Report where FType = '" + this.Name + "'");

        }

        private void ucDate_RefreshDateChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
