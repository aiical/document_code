using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPrinting.Localization; 

namespace Common
{
    public partial class frmReport : BaseClass.frmBase
    {
        private string _ReportTag = "";
        protected string strQuerySQL = "";
        protected string strValue = "";
        //protected DateTime dtValue = Convert.ToDateTime("1900-1-1");
        //protected string strItemType = "";
        protected bool bNormal = false;

        public frmReport()
        {
            InitializeComponent();
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
        /// 明细表
        /// </summary>
        /// <returns></returns>
        protected virtual Hashtable GetParm1()
        {

            Hashtable parm = new Hashtable();
            parm.Add("@Start", ucDate.dtStart);
            parm.Add("@End", ucDate.dtEnd);
            parm.Add("@Value", strValue);
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

                    if (rgOption.Visible == false)
                    {
                       ds = myHelper.GetOtherDs(strQuerySQL, GetParm());
                    }
                    else
                    {
                       ds = myHelper.GetOtherDs(strQuerySQL, GetParm1());
                    }

                    if (ds == null) return -1;
                    //gvReport.Columns.Clear();
                    gcReport.DataSource = ds.Tables[0].DefaultView;
                    //AssignField();
                    DataLib.sysClass.LoadFormatFromDB(gvReport, ReportTag, rgOption.SelectedIndex);
                    DataLib.SysVar.TestColumnRight(gvReport, this.Name);
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

        

        /// <summary>
        /// 取得分组数
        /// </summary>
        /// <param name="strField"></param>
        /// <returns></returns>
        protected GridGroupSummaryItem GetGroupType(string strField)
        {
            GridGroupSummaryItem GiResult = null;

            foreach (GridGroupSummaryItem Gi in gvReport.GroupSummary)
            {
                if (Gi.FieldName == strField)
                {
                    GiResult = Gi;
                    break;
                }
            }
            return GiResult;
        }

        /// <summary>
        /// 设置单据明细字段
        /// </summary>
        protected virtual void AssignField()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_ReportField where F_Class = '" + ReportTag + "' and F_Tag = '" + rgOption.SelectedIndex.ToString() + "' order by F_Order");
            DataTable dtGroup =  ds.Tables[0];
            if (ds.Tables[0].Rows.Count == 0) return;
            gvReport.GroupSummary.Clear();
            foreach (GridColumn gc in gvReport.Columns)
            {
                DataRow[] drTmp = dtGroup.Select("F_Field = '"+gc.FieldName+"'");
                if (drTmp.Length > 0)
                {
                    DataRow dr = drTmp[0];

                    gc.Caption = dr["F_Caption"].ToString();
                    gc.Width = Convert.ToInt32(dr["F_Width"]);
                    gc.Visible = Convert.ToBoolean(dr["F_Visible"]);
                    gc.VisibleIndex = Convert.ToInt32(dr["F_Order"]);

                    if (dr["F_Format"].ToString().Length > 0)
                    {
                        gc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                        gc.DisplayFormat.FormatString = dr["F_Format"].ToString();
                    }

                    switch (dr["F_SumType"].ToString())
                    {
                        case "sum":
                            gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                            break;
                        case "avg":
                            gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Average;
                            break;
                        case "count":
                            gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                            break;
                        case "max":
                            gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Max;
                            break;
                        case "min":
                            gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Min;
                            break;

                    }

                    if (dr["F_FootFormat"].ToString().Length > 0)
                        gc.SummaryItem.DisplayFormat = dr["F_FootFormat"].ToString();

                    if (Convert.ToBoolean(dr["F_Edit"]) == false)
                    {
                        //gc.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
                        gc.OptionsColumn.AllowFocus = false;
                        gc.OptionsColumn.AllowEdit = false;
                    }

                    if (Convert.ToBoolean(dr["F_Merge"]) == true)
                        gc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                    else
                        gc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;

                    gc.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    if (gc.FieldName == "Aid")
                    {
                        gc.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                        gc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    }

                    if (dr["F_GroupType"].ToString().Length > 0)
                    {
                        GridGroupSummaryItem Gi = new GridGroupSummaryItem();
                        switch (dr["F_GroupType"].ToString())
                        {
                            case "sum":
                                Gi.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                                break;
                            case "avg":
                                Gi.SummaryType = DevExpress.Data.SummaryItemType.Average;
                                break;
                            case "count":
                                Gi.SummaryType = DevExpress.Data.SummaryItemType.Count;
                                break;
                            case "max":
                                Gi.SummaryType = DevExpress.Data.SummaryItemType.Max;
                                break;
                            case "min":
                                Gi.SummaryType = DevExpress.Data.SummaryItemType.Min;
                                break;
                        }

                        Gi.FieldName = dr["F_Field"].ToString();
                        Gi.ShowInGroupColumnFooterName = dr["F_Field"].ToString();
                        Gi.DisplayFormat = dr["F_GroupFormat"].ToString();
                        //Gi.ShowInGroupColumnFooter = gc;
                        gvReport.GroupSummary.Add(Gi);
                    }
                }
            }
        }

        /// <summary>
        /// 保存字段格式
        /// </summary>
        protected virtual void SaveFieldFormat()
        {
            string strSumType = "";
            DataRow drColumn;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            
            DataSet ds = myHelper.GetDs("select * from t_ReportField where F_Class = '" + ReportTag + "' and F_Tag = '" + rgOption.SelectedIndex.ToString() + "'");
            foreach (GridColumn gc in gvReport.Columns)
            {
                string strField = gc.FieldName;
                string strCapiton = gc.Caption;
                int intWith = gc.Width;
                bool blnVisible = gc.Visible;

                drColumn = ds.Tables[0].NewRow();
              
                drColumn["F_Class"] = ReportTag;
                drColumn["F_Tag"] = rgOption.SelectedIndex;
                drColumn["F_Field"] = gc.FieldName;
                drColumn["F_Caption"] = strCapiton;
                drColumn["F_Width"] = intWith;
                drColumn["F_Visible"] = blnVisible;
                drColumn["F_Edit"] = 0;
                drColumn["F_Format"] = gc.DisplayFormat.FormatString;
                drColumn["F_FootFormat"] = gc.SummaryItem.DisplayFormat;
                drColumn["F_Order"] = gc.VisibleIndex;
                if (gc.OptionsColumn.AllowMerge == DevExpress.Utils.DefaultBoolean.True)
                    drColumn["F_Merge"] = true;
                else
                    drColumn["F_Merge"] = false;
                strSumType = "";
                switch (gc.SummaryItem.SummaryType)
                {
                    case DevExpress.Data.SummaryItemType.Sum:
                        strSumType = "sum";
                        break;
                    case DevExpress.Data.SummaryItemType.Average:
                        strSumType = "avg";
                        break;
                    case DevExpress.Data.SummaryItemType.Count:
                        strSumType = "count";
                        break;
                    case DevExpress.Data.SummaryItemType.Max:
                        strSumType = "max";
                        break;
                    case DevExpress.Data.SummaryItemType.Min:
                        strSumType = "min";
                        break;
                }
                drColumn["F_SumType"] = strSumType;

                GridGroupSummaryItem Gi = GetGroupType(strField);
                if (Gi != null)
                {
                    strSumType = "";
                    switch (Gi.SummaryType)
                    {
                        case DevExpress.Data.SummaryItemType.Sum:
                            strSumType = "sum";
                            break;
                        case DevExpress.Data.SummaryItemType.Average:
                            strSumType = "avg";
                            break;
                        case DevExpress.Data.SummaryItemType.Count:
                            strSumType = "count";
                            break;
                        case DevExpress.Data.SummaryItemType.Max:
                            strSumType = "max";
                            break;
                        case DevExpress.Data.SummaryItemType.Min:
                            strSumType = "min";
                            break;
                    }
                    drColumn["F_GroupType"] = strSumType;
                    drColumn["F_GroupFormat"] = Gi.DisplayFormat;
                }

                ds.Tables[0].Rows.Add(drColumn);
            }

            myHelper.ExecuteSQL("delete from t_ReportField where F_Class = '" + ReportTag + "' and F_Tag = '" + rgOption.SelectedIndex.ToString() + "'");
            myHelper.SaveData(ds, "select * from t_ReportField where F_Class = '" + ReportTag + "' and F_Tag = '" + rgOption.SelectedIndex.ToString() + "'");
        }



        /// <summary>
        /// 设置SQL语句
        /// </summary>
        private void SetSQL()
        {
            gvReport.Columns.Clear();
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_SQL where F_Class = '" + ReportTag + "' and F_Tag = '" + rgOption.SelectedIndex.ToString() + "'");
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

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 直接打印报表
        /// </summary>
        protected virtual void PrintReport()
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

            PreviewLocalizer plZer = new XtraChinese.DxperienceXtraPrintingLocalizationCHS();
            DataLib.sysClass myClass = new DataLib.sysClass();
            myClass.DoPrint(this.Text, plZer, this.printingSystem);
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintReport();
        }

        private void btnPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
            PreviewLocalizer plZer = new XtraChinese.DxperienceXtraPrintingLocalizationCHS();
            DataLib.sysClass myClass = new DataLib.sysClass();
            myClass.DoPreview(this.Text, plZer, this.printingSystem);
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            lbTitle.Text = this.Text;
        }

        protected virtual DataSet GetPrintDS()
        {
            DataTable dt1 = ((DataView)gcReport.DataSource).Table.Copy();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt1);
            return ds;
        }

        /// <summary>
        /// 设置表格格式
        /// </summary>
        protected virtual void SetGridFormat()
        {
            frmSetGrid myGrid = new frmSetGrid();
            myGrid.gvSource = gvReport;
            myGrid.ShowDialog();
            myGrid.Dispose();
        }

        private void frmReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.F8 && DataLib.SysVar.strUGroup == "超级用户")
            {
                PrintDesign();
            }

            if (e.KeyCode == Keys.F7 && DataLib.SysVar.strUGroup == "超级用户")
            {
                SetGridFormat();
            }

            if (e.KeyCode == Keys.F5 && DataLib.SysVar.strUGroup == "超级用户")
            {
                DataLib.sysClass.SaveGridToDB(gvReport, ReportTag, rgOption.SelectedIndex);
                //SaveFieldFormat();
            }

            if (e.Control == true && e.KeyCode == Keys.F9 && DataLib.SysVar.strUGroup == "超级用户")
            {
                frmSQL mySQL = new frmSQL();
                mySQL.MeSQL.Text = strQuerySQL;
                if (mySQL.ShowDialog() == DialogResult.OK)
                {
                    strQuerySQL = mySQL.MeSQL.Text;
                    if (BindData() == 0)
                    {
                        DataLib.DataHelper myHelper = new DataLib.DataHelper();
                        string strSQL = "select * from t_SQL where F_Class = '" + ReportTag + "' and F_Tag = '" + rgOption.SelectedIndex.ToString() + "'";
                        DataSet ds = myHelper.GetDs(strSQL);
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            DataRow drNew = ds.Tables[0].NewRow();
                            drNew["F_Class"] = ReportTag;
                            drNew["F_Tag"] = rgOption.SelectedIndex.ToString();
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

        private void frmReport_Shown(object sender, EventArgs e)
        {
            if (this.DesignMode == false)
               SetSQL();
        }

        private void ucDate_RefreshDateChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected virtual void SelectIndexChange()
        {
            if (rgOption.SelectedIndex == 0)
                btnGraphi.Enabled = true;
            else
                btnGraphi.Enabled = false;

            SetSQL();
        }

        private void rgOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectIndexChange();
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Export();
        }

        protected virtual void Export()
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
                gvReport.ExportToExcelOld(strFile);
        }

        private void gvReport_DoubleClick(object sender, EventArgs e)
        {
            if (rgOption.Visible == true)
            {
                if (gvReport.FocusedRowHandle < 0) return;
                if (rgOption.SelectedIndex == 0)
                    rgOption.SelectedIndex = 1;
            }

            OnViewDbClick(sender,e);
        }

        protected virtual void OnViewDbClick(object sender, EventArgs e)
        {
        }

        private void btnFilter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataFilter();
        }

        /// <summary>
        /// 数据过滤
        /// </summary>
        protected virtual void DataFilter()
        {
        }

        private void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataDel();
        }

        /// <summary>
        /// 数据删除
        /// </summary>
        protected virtual void DataDel()
        {
        }



        /// <summary>
        /// 图表数据处理
        /// </summary>
        protected virtual void Graphi()
        {
            
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

        protected virtual void PrintDesign()
        {
            DevExpress.XtraReports.UI.XtraReport r = new DevExpress.XtraReports.UI.XtraReport();
            r.DataSource = GetPrintDS();
            Stream s = LoadReport();
            if (s != null)
            {
                r.LoadLayout(s);
            }
            
            myControl.CustomDesignForm d = new myControl.CustomDesignForm();
            d.OpenReport(r);
            d.ShowDialog();
            SaveReport(r);
            d.Dispose();
            
        }

        private void gvReport_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            FocusedRowChanged(sender, e);
        }

        protected virtual void FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
        }

        private void btnGraphi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Graphi();
        }
    }
}

