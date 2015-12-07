using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid;

namespace CommonData
{
    public partial class frmSetGrid : BaseClass.frmBase
    {
        public DevExpress.XtraGrid.Views.Grid.GridView gvSource;
        public int intFlag = 0;
        public frmSetGrid()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取表格列属性
        /// </summary>
        private void GetColumns()
        {
            cbFilter.Checked = gvSource.OptionsCustomization.AllowFilter;
            cbAuto.Checked = gvSource.OptionsView.ColumnAutoWidth;
            cbGroup.Checked = gvSource.OptionsView.ShowGroupPanel;
            cbSum.Checked = gvSource.OptionsView.ShowFooter;
            ckMerge.Checked = gvSource.OptionsView.AllowCellMerge;

            int intRow;
            foreach(DevExpress.XtraGrid.Columns.GridColumn gc in gvSource.Columns)
            {
                if (gc.Tag != null) continue;
                if (gc.Tag == "0") continue;
                intRow = Grid.Rows.Add();
                Grid.Rows[intRow].Cells["F_ColumnName"].Value = gc.FieldName;
                Grid.Rows[intRow].Cells["F_ColumnCaption"].Value = gc.Caption;
                Grid.Rows[intRow].Cells["F_Visible"].Value = gc.Visible;
                if (gc.OptionsColumn.AllowMerge == DevExpress.Utils.DefaultBoolean.True)
                    Grid.Rows[intRow].Cells["F_Merge"].Value = true;
                else
                    Grid.Rows[intRow].Cells["F_Merge"].Value = false;
                Grid.Rows[intRow].Cells["F_Format"].Value = gc.DisplayFormat.FormatString;
                switch (gc.SummaryItem.SummaryType)
                {
                    case DevExpress.Data.SummaryItemType.Sum:
                        Grid.Rows[intRow].Cells["F_SumType"].Value = "合计";
                        break;
                    case DevExpress.Data.SummaryItemType.Count:
                        Grid.Rows[intRow].Cells["F_SumType"].Value = "统计";
                        break;
                    case DevExpress.Data.SummaryItemType.Average:
                        Grid.Rows[intRow].Cells["F_SumType"].Value = "平均";
                        break;
                    case DevExpress.Data.SummaryItemType.Max:
                        Grid.Rows[intRow].Cells["F_SumType"].Value = "最大值";
                        break;
                    case DevExpress.Data.SummaryItemType.Min:
                        Grid.Rows[intRow].Cells["F_SumType"].Value = "最小值";
                        break;
                    case DevExpress.Data.SummaryItemType.Custom:
                        Grid.Rows[intRow].Cells["F_SumType"].Value = "自定义";
                        break;
                    case DevExpress.Data.SummaryItemType.None:
                        Grid.Rows[intRow].Cells["F_SumType"].Value = "(无)";
                        break;
                }
                Grid.Rows[intRow].Cells["F_FootFormat"].Value = gc.SummaryItem.DisplayFormat;

                Grid.Rows[intRow].Cells["F_GroupType"].Value = "(无)";
                Grid.Rows[intRow].Cells["F_GroupFormat"].Value = "";
                GridGroupSummaryItem Gi = GetGroupType(gc.FieldName);
                if (Gi != null)
                {
                    switch (Gi.SummaryType)
                    {
                        case DevExpress.Data.SummaryItemType.Sum:
                            Grid.Rows[intRow].Cells["F_GroupType"].Value = "合计";
                            break;
                        case DevExpress.Data.SummaryItemType.Count:
                            Grid.Rows[intRow].Cells["F_GroupType"].Value = "统计";
                            break;
                        case DevExpress.Data.SummaryItemType.Average:
                            Grid.Rows[intRow].Cells["F_GroupType"].Value = "平均";
                            break;
                        case DevExpress.Data.SummaryItemType.Max:
                            Grid.Rows[intRow].Cells["F_GroupType"].Value = "最大值";
                            break;
                        case DevExpress.Data.SummaryItemType.Min:
                            Grid.Rows[intRow].Cells["F_GroupType"].Value = "最小值";
                            break;
                        case DevExpress.Data.SummaryItemType.Custom:
                            Grid.Rows[intRow].Cells["F_GroupType"].Value = "自定义";
                            break;
                        case DevExpress.Data.SummaryItemType.None:
                            Grid.Rows[intRow].Cells["F_GroupType"].Value = "(无)";
                            break;
                    }
                    Grid.Rows[intRow].Cells["F_GroupFormat"].Value = Gi.DisplayFormat;
                }
            }
            
        }

        //获取分组类别
        private GridGroupSummaryItem GetGroupType(string strField)
        {
            GridGroupSummaryItem GiResult = null;
            foreach (GridGroupSummaryItem Gi in gvSource.GroupSummary)
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
        /// 设置表格列属性
        /// </summary>
        private void SetColumns()
        {
            Grid.EndEdit();
            gvSource.BeginUpdate();
            gvSource.OptionsView.ShowFooter = cbSum.Checked;
            gvSource.OptionsView.ShowGroupPanel = cbGroup.Checked;
            gvSource.OptionsView.ColumnAutoWidth = cbAuto.Checked;
            gvSource.OptionsCustomization.AllowFilter = cbFilter.Checked;
            gvSource.OptionsView.AllowCellMerge = ckMerge.Checked;

            gvSource.GroupSummary.Clear();

            foreach (DataGridViewRow dvRow in Grid.Rows)
            {
                DevExpress.XtraGrid.Columns.GridColumn gc = gvSource.Columns.ColumnByFieldName(dvRow.Cells["F_ColumnName"].Value.ToString());
                if (gc != null)
                {
                    gc.Visible = Convert.ToBoolean(dvRow.Cells["F_Visible"].Value);

                    if (Convert.ToBoolean(dvRow.Cells["F_Merge"].Value) == true)
                        gc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                    else
                        gc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;

                    gc.Caption = dvRow.Cells["F_ColumnCaption"].Value.ToString();

                    if (!dvRow.Cells["F_Format"].Value.Equals(DBNull.Value))
                    {
                        gc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                        gc.DisplayFormat.FormatString = dvRow.Cells["F_Format"].Value.ToString();
                    }
                  

                    switch (dvRow.Cells["F_SumType"].Value.ToString())
                    {
                        case "合计":
                            gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                            break;
                        case "统计":
                            gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                            break;
                        case "平均":
                            gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Average;
                            break;
                        case "最大值":
                            gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Max;
                            break;
                        case "最小值":
                            gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Min;
                            break;
                        case "自定义":
                            gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                            break;
                        case "(无)":
                            gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.None;
                            break;
                    }
                    if (dvRow.Cells["F_FootFormat"].Value != DBNull.Value)
                       gc.SummaryItem.DisplayFormat = dvRow.Cells["F_FootFormat"].Value.ToString();

                   if (dvRow.Cells["F_GroupType"].Value.ToString() != "(无)")
                   {
                       GridGroupSummaryItem Gi = new GridGroupSummaryItem();
                       switch (dvRow.Cells["F_GroupType"].Value.ToString())
                       {
                           case "合计":
                               Gi.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                               break;
                           case "统计":
                               Gi.SummaryType = DevExpress.Data.SummaryItemType.Count;
                               break;
                           case "平均":
                               Gi.SummaryType = DevExpress.Data.SummaryItemType.Average;
                               break;
                           case "最大值":
                               Gi.SummaryType = DevExpress.Data.SummaryItemType.Max;
                               break;
                           case "最小值":
                               Gi.SummaryType = DevExpress.Data.SummaryItemType.Min;
                               break;
                           case "自定义":
                               Gi.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                               break;
                           case "(无)":
                               Gi.SummaryType = DevExpress.Data.SummaryItemType.None;
                               break;
                       }
                       Gi.DisplayFormat = dvRow.Cells["F_GroupFormat"].Value.ToString();
                       Gi.ShowInGroupColumnFooterName = dvRow.Cells["F_ColumnName"].Value.ToString();
                       Gi.FieldName = dvRow.Cells["F_ColumnName"].Value.ToString();
                       gvSource.GroupSummary.Add(Gi);
                   }
                }
            }
            gvSource.EndUpdate();
        }

        private void frmSetGrid_Load(object sender, EventArgs e)
        {
            GetColumns();
            if (intFlag != 0)
            {
                ckMerge.Enabled = false;
                cbAuto.Enabled = false;
                cbFilter.Enabled = false;
                cbGroup.Enabled = false;
                cbSum.Enabled = false;
                Grid.Columns["F_GroupType"].Visible = false;
                Grid.Columns["F_GroupFormat"].Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetColumns();
            this.Close();
        }
    }
}

