using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPrinting.Localization; 

namespace Common
{
    public partial class frmBillList : BaseClass.frmBase
    {
        private string _BillTag = "";
        protected string strQuerySQL = "";
        public frmBillList()
        {
            InitializeComponent();          
        }

        /// <summary>
        /// 测试权限
        /// </summary>
        /// <returns></returns>
        protected bool TestRight(string strName,string sTag)
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


        /// <summary>
        /// 取得分组数
        /// </summary>
        /// <param name="strField"></param>
        /// <returns></returns>
        private GridGroupSummaryItem GetGroupType(string strField)
        {
            GridGroupSummaryItem GiResult = null;

            foreach (GridGroupSummaryItem Gi in gvList.GroupSummary)
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
        private void AssignField()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_ReportField where F_Class = '" + BillTag + "' and F_Tag = '" + cbType.SelectedIndex.ToString() + "' order by F_Order");
            if (ds.Tables[0].Rows.Count == 0) return;   
            gvList.GroupSummary.Clear();
            gvList.Columns.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                GridColumn gc = gvList.Columns.AddField(dr["F_Field"].ToString());
                gc.Caption = dr["F_Caption"].ToString();
                gc.Width = Convert.ToInt32(dr["F_Width"]);
                gc.Visible = Convert.ToBoolean(dr["F_Visible"]);

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

                    gvList.GroupSummary.Add(Gi);
                }
            }
        }

        /// <summary>
        /// 保存字段格式
        /// </summary>
        private void SaveFieldFormat()
        {
            string strSumType = "";
            DataRow drColumn;
            bool blnFlag = false,blnTag = false;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_ReportField where F_Class = '" + BillTag + "' and F_Tag = '" + cbType.SelectedIndex.ToString() + "' order by F_Order");

            if (ds.Tables[0].Rows.Count == 0)
                blnTag = false;
            else
                blnTag = true;

            foreach (GridColumn gc in gvList.Columns)
            {
                string strField = gc.FieldName;
                string strCapiton = gc.Caption;
                int intWith = gc.Width;
                bool blnVisible = gc.Visible;
                if (blnTag == false)
                {
                    drColumn = ds.Tables[0].NewRow();
                    blnFlag = true;
                }
                else
                {
                    DataRow[] dr = ds.Tables[0].Select("F_Field = '" + strField + "'");
                    drColumn = dr[0];
                }
                drColumn["F_Class"] = BillTag;
                drColumn["F_Tag"] = cbType.SelectedIndex;
                drColumn["F_Field"] = gc.FieldName;
                drColumn["F_Caption"] = strCapiton;
                drColumn["F_Width"] = intWith;
                drColumn["F_Visible"] = blnVisible;
                drColumn["F_Edit"] = 0;
                drColumn["F_Format"] = gc.DisplayFormat.FormatString;
                drColumn["F_FootFormat"] = gc.SummaryItem.DisplayFormat;
                drColumn["F_FieldType"] = gc.ColumnType.ToString();
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

                if (blnFlag == false)
                    drColumn.EndEdit();
                else
                    ds.Tables[0].Rows.Add(drColumn);
            }

            myHelper.SaveData(ds, "select * from t_ReportField where F_Class = '" + BillTag + "' and F_Tag = '" + cbType.SelectedIndex.ToString() + "'");
        }


        /// <summary>
        /// 单据标志
        /// </summary>
        protected string BillTag
        {
            get
            {
                if (_BillTag == "")
                    _BillTag = this.Name;
                return _BillTag;
            }
            set
            {
                _BillTag = value;
            }
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmBillList_Shown(object sender, EventArgs e)
        {
            if (this.DesignMode == false)
               SetSQL();
        }

        protected virtual Hashtable GetParm3()
        {
            Hashtable parm = new Hashtable();
            parm.Add("@Start", ucDate.dtStart);
            parm.Add("@End", ucDate.dtEnd);
            parm.Add("@Check", cbCheck.SelectedIndex);
            /*
            DataLib.JxcService.SqlParameter[] parm =
                    {     
                       new   DataLib.JxcService.SqlParameter(),   
                       new   DataLib.JxcService.SqlParameter(),   
                       new   DataLib.JxcService.SqlParameter()
                    };

            parm[0].ParameterName = "@Start";
            parm[0].SqlDbType = DataLib.JxcService.SqlDbType.DateTime;
            parm[0].Value = ucDate.dtStart;

            parm[1].ParameterName = "@End";
            parm[1].SqlDbType = DataLib.JxcService.SqlDbType.DateTime;
            parm[1].Value = ucDate.dtEnd;

            parm[2].ParameterName = "@Check";
            parm[2].SqlDbType = DataLib.JxcService.SqlDbType.Int;
            parm[2].Size = 30;
            parm[2].Value = cbCheck.SelectedIndex;
             */ 
            return parm;
        }

        protected virtual Hashtable GetParm5()
        {
            Hashtable parm = new Hashtable();
            parm.Add("@Start", ucDate.dtStart);
            parm.Add("@End", ucDate.dtEnd);
            parm.Add("@Check", cbCheck.SelectedIndex);
            parm.Add("@CutOff", cbCutOff.SelectedIndex);
            parm.Add("@Finish", cbFinish.SelectedIndex);

            /*
            DataLib.JxcService.SqlParameter[] parm =
                    {     
                       new   DataLib.JxcService.SqlParameter(),   
                       new   DataLib.JxcService.SqlParameter(),   
                       new   DataLib.JxcService.SqlParameter(),
                       new   DataLib.JxcService.SqlParameter(),
                       new   DataLib.JxcService.SqlParameter()
                    };

            parm[0].ParameterName = "@Start";
            parm[0].SqlDbType = DataLib.JxcService.SqlDbType.DateTime;
            parm[0].Value = ucDate.dtStart;

            parm[1].ParameterName = "@End";
            parm[1].SqlDbType = DataLib.JxcService.SqlDbType.DateTime;
            parm[1].Value = ucDate.dtEnd;

            parm[2].ParameterName = "@Check";
            parm[2].SqlDbType = DataLib.JxcService.SqlDbType.Int;
            parm[2].Size = 30;
            parm[2].Value = cbCheck.SelectedIndex;

            parm[3].ParameterName = "@CutOff";
            parm[3].SqlDbType = DataLib.JxcService.SqlDbType.Int;
            parm[3].Size = 30;
            parm[3].Value = cbCutOff.SelectedIndex;

            parm[4].ParameterName = "@Finish";
            parm[4].SqlDbType = DataLib.JxcService.SqlDbType.Int;
            parm[4].Size = 30;
            parm[4].Value = cbFinish.SelectedIndex;
            */
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
                    if (cbCutOff.Visible == false)
                        ds = myHelper.GetOtherDs(strQuerySQL, GetParm3());
                    else
                        ds = myHelper.GetOtherDs(strQuerySQL, GetParm5());

                    if (ds == null) return -1;

                    int intRow = gvList.FocusedRowHandle;
                    gcList.DataSource = ds.Tables[0].DefaultView;
                    if (intRow <= gvList.RowCount)
                       gvList.FocusedRowHandle = intRow;
                    //AssignField();
                    DataLib.sysClass.LoadFormatFromDB(gvList, BillTag, cbType.SelectedIndex);

                    DataLib.SysVar.TestColumnRight(gvList,this.Name);
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

        private void frmBillList_Load(object sender, EventArgs e)
        {
           // SetSQL();
        }

        protected virtual bool TestNew()
        {
            if (TestRight("新增", this.Name) == false) return false;
            return true;
        }

        protected virtual bool TestEdit()
        {
            if (TestRight("编辑", this.Name) == false) return false;
            return true;
        }

        protected virtual bool TestDel()
        {
            if (TestRight("删除", this.Name) == false) return false;
            return true;
        }

        /// <summary>
        /// 新增
        /// </summary>
        protected virtual void New()
        {
            BindData();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        protected virtual void Edit()
        {
            BindData();
        }

        /// <summary>
        /// 删除
        /// </summary>
        protected virtual void Del()
        {

            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);
            DataTable dt = dr.Table;
            if (dr.Table.Columns.Contains("F_BillID") == true)
                DataLib.SysVar.SetLog(this.Text, "删除", "单号为" + dr["F_BillID"].ToString());
        }

        /// <summary>
        /// 审核
        /// </summary>
        protected virtual void CheckBill()
        {
        }

        /// <summary>
        /// 反审核
        /// </summary>
        protected virtual void UnCheckBill()
        {
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TestNew() == false) return;
            New();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TestEdit() == false) return;
            Edit();
        }

        private void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TestDel() == false) return;
            Del();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PreviewLocalizer plZer = new XtraChinese.DxperienceXtraPrintingLocalizationCHS();
            DataLib.sysClass myClass = new DataLib.sysClass();
            myClass.DoPrint(this.Text, plZer, this.printingSystem);
        }

        private void btnPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PreviewLocalizer plZer = new XtraChinese.DxperienceXtraPrintingLocalizationCHS();
            DataLib.sysClass myClass = new DataLib.sysClass();
            myClass.DoPreview(this.Text, plZer, this.printingSystem);
        }

        private void gvList_DoubleClick(object sender, EventArgs e)
        {
            Edit();
        }

        /// <summary>
        /// 设置SQL语句
        /// </summary>
        private void SetSQL()
        {
            gvList.Columns.Clear();
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_SQL where F_Class = '" + BillTag + "' and F_Tag = '" + cbType.SelectedIndex.ToString() + "'");
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
        /// 设置表格格式
        /// </summary>
        private void SetFormat()
        {/*
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_SQL where F_Class = '" + this.Name + "' and F_Tag = '" + cbType.SelectedIndex.ToString() + "'");

            if (ds.Tables[0].Rows[0]["F_Grid"] != Convert.DBNull)
            {
                MemoryStream stream = new MemoryStream((byte[])ds.Tables[0].Rows[0]["F_Grid"]);
                grdView.RestoreLayoutFromStream(stream, DevExpress.Utils.OptionsLayoutBase.FullLayout);
                stream.Dispose();
            }
            */
        }

        /// <summary>
        /// 保存表格格式
        /// </summary>
        private void SaveFormat()
        {
        }

        private void frmBillList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7 && DataLib.SysVar.strUGroup == "超级用户")
            {
                frmSetGrid myGrid = new frmSetGrid();
                myGrid.gvSource = gvList;
                myGrid.ShowDialog();
                myGrid.Dispose();
            }

            if (e.KeyCode == Keys.F5 && DataLib.SysVar.strUGroup == "超级用户")
            {
                DataLib.sysClass.SaveGridToDB(gvList, BillTag, cbType.SelectedIndex);
                //SaveFieldFormat();
            }

            if (e.Control == true && e.KeyCode == Keys.F9)
            {
                frmSQL mySQL = new frmSQL();
                mySQL.MeSQL.Text = strQuerySQL;
                if (mySQL.ShowDialog() == DialogResult.OK)
                {
                    strQuerySQL = mySQL.MeSQL.Text;
                    if (BindData() == 0)
                    {
                        DataLib.DataHelper myHelper = new DataLib.DataHelper();
                        string strSQL = "select * from t_SQL where F_Class = '" + BillTag + "' and F_Tag = '" + cbType.SelectedIndex.ToString() + "'";
                        DataSet ds = myHelper.GetDs(strSQL);
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            DataRow drNew = ds.Tables[0].NewRow();
                            drNew["F_Class"] = BillTag;
                            drNew["F_Tag"] = cbType.SelectedIndex.ToString();
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

        private void ucDate_RefreshDateChanged(object sender, EventArgs e)
        {
            SetSQL();
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSQL();
        }

        private void cbFinish_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void cbCutOff_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void cbCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Export();
        }

        private void Export()
        {
            if (TestRight("引出", this.Name) == false) return;
            string strFile = DataLib.sysClass.ShowSaveFileDialog("Excel 文件", "Excel 文件|*.Xls");
            if (strFile != "")
                gvList.ExportToExcelOld(strFile);
        }
    }
}

