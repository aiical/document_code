namespace U8_Sale
{
    partial class frmSaleCount
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tab = new System.Windows.Forms.TabControl();
            this.tpMonth = new System.Windows.Forms.TabPage();
            this.gcList = new DevExpress.XtraGrid.GridControl();
            this.gcView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gccDepCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luecDepCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gciMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboiMonth = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gcnAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gccRef1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gccRef2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcreal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gciYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcfRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpShop = new System.Windows.Forms.TabPage();
            this.gdList = new DevExpress.XtraGrid.GridControl();
            this.gdView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueDepName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboiMonths = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luecShopCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.tab.SuspendLayout();
            this.tpMonth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luecDepCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboiMonth)).BeginInit();
            this.tpShop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDepName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboiMonths)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luecShopCode)).BeginInit();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tpMonth);
            this.tab.Controls.Add(this.tpShop);
            this.tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab.Location = new System.Drawing.Point(0, 0);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(1218, 538);
            this.tab.TabIndex = 139;
            // 
            // tpMonth
            // 
            this.tpMonth.Controls.Add(this.gcList);
            this.tpMonth.Location = new System.Drawing.Point(4, 21);
            this.tpMonth.Name = "tpMonth";
            this.tpMonth.Padding = new System.Windows.Forms.Padding(3);
            this.tpMonth.Size = new System.Drawing.Size(1210, 513);
            this.tpMonth.TabIndex = 0;
            this.tpMonth.Text = "月计划统计分析";
            this.tpMonth.UseVisualStyleBackColor = true;
            // 
            // gcList
            // 
            this.gcList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcList.EmbeddedNavigator.Name = "";
            this.gcList.Location = new System.Drawing.Point(3, 3);
            this.gcList.MainView = this.gcView;
            this.gcList.Name = "gcList";
            this.gcList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cboiMonth,
            this.luecDepCode});
            this.gcList.Size = new System.Drawing.Size(1204, 507);
            this.gcList.TabIndex = 19;
            this.gcList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gcView});
            // 
            // gcView
            // 
            this.gcView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gccDepCode,
            this.gciMonth,
            this.gcnAmount,
            this.gccRef1,
            this.gccRef2,
            this.gcreal,
            this.gciYear,
            this.gcfRate});
            this.gcView.GridControl = this.gcList;
            this.gcView.IndicatorWidth = 30;
            this.gcView.Name = "gcView";
            this.gcView.OptionsNavigation.AutoFocusNewRow = true;
            this.gcView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            // 
            // gccDepCode
            // 
            this.gccDepCode.Caption = "部门";
            this.gccDepCode.ColumnEdit = this.luecDepCode;
            this.gccDepCode.FieldName = "cDepCode";
            this.gccDepCode.Name = "gccDepCode";
            this.gccDepCode.Visible = true;
            this.gccDepCode.VisibleIndex = 0;
            // 
            // luecDepCode
            // 
            this.luecDepCode.AutoHeight = false;
            this.luecDepCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luecDepCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", "编码", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", "名称", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.luecDepCode.DisplayMember = "cDepName";
            this.luecDepCode.Name = "luecDepCode";
            this.luecDepCode.ValueMember = "cDepCode";
            // 
            // gciMonth
            // 
            this.gciMonth.Caption = "月份";
            this.gciMonth.ColumnEdit = this.cboiMonth;
            this.gciMonth.FieldName = "iMonth";
            this.gciMonth.Name = "gciMonth";
            this.gciMonth.Visible = true;
            this.gciMonth.VisibleIndex = 2;
            this.gciMonth.Width = 100;
            // 
            // cboiMonth
            // 
            this.cboiMonth.AutoHeight = false;
            this.cboiMonth.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboiMonth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cboiMonth.Name = "cboiMonth";
            // 
            // gcnAmount
            // 
            this.gcnAmount.Caption = "计划值";
            this.gcnAmount.FieldName = "nAmount";
            this.gcnAmount.Name = "gcnAmount";
            this.gcnAmount.Visible = true;
            this.gcnAmount.VisibleIndex = 5;
            this.gcnAmount.Width = 173;
            // 
            // gccRef1
            // 
            this.gccRef1.Caption = "参考值1";
            this.gccRef1.FieldName = "cRefs1";
            this.gccRef1.Name = "gccRef1";
            this.gccRef1.Visible = true;
            this.gccRef1.VisibleIndex = 3;
            this.gccRef1.Width = 173;
            // 
            // gccRef2
            // 
            this.gccRef2.Caption = "参考值2";
            this.gccRef2.FieldName = "cRefs2";
            this.gccRef2.Name = "gccRef2";
            this.gccRef2.Visible = true;
            this.gccRef2.VisibleIndex = 4;
            this.gccRef2.Width = 173;
            // 
            // gcreal
            // 
            this.gcreal.Caption = "实际金额";
            this.gcreal.FieldName = "isum";
            this.gcreal.Name = "gcreal";
            this.gcreal.Visible = true;
            this.gcreal.VisibleIndex = 6;
            this.gcreal.Width = 176;
            // 
            // gciYear
            // 
            this.gciYear.Caption = "年份";
            this.gciYear.FieldName = "iYear";
            this.gciYear.Name = "gciYear";
            this.gciYear.Visible = true;
            this.gciYear.VisibleIndex = 1;
            // 
            // gcfRate
            // 
            this.gcfRate.Caption = "完成额";
            this.gcfRate.FieldName = "fRate";
            this.gcfRate.Name = "gcfRate";
            this.gcfRate.Visible = true;
            this.gcfRate.VisibleIndex = 7;
            // 
            // tpShop
            // 
            this.tpShop.Controls.Add(this.gdList);
            this.tpShop.Location = new System.Drawing.Point(4, 21);
            this.tpShop.Name = "tpShop";
            this.tpShop.Padding = new System.Windows.Forms.Padding(3);
            this.tpShop.Size = new System.Drawing.Size(1210, 513);
            this.tpShop.TabIndex = 1;
            this.tpShop.Text = "门店月计划统计";
            this.tpShop.UseVisualStyleBackColor = true;
            // 
            // gdList
            // 
            this.gdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdList.EmbeddedNavigator.Name = "";
            this.gdList.Location = new System.Drawing.Point(3, 3);
            this.gdList.MainView = this.gdView;
            this.gdList.Name = "gdList";
            this.gdList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cboiMonths,
            this.lueDepName,
            this.luecShopCode});
            this.gdList.Size = new System.Drawing.Size(1204, 507);
            this.gdList.TabIndex = 20;
            this.gdList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdView});
            // 
            // gdView
            // 
            this.gdView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9});
            this.gdView.GridControl = this.gdList;
            this.gdView.IndicatorWidth = 30;
            this.gdView.Name = "gdView";
            this.gdView.OptionsNavigation.AutoFocusNewRow = true;
            this.gdView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "部门";
            this.gridColumn1.ColumnEdit = this.lueDepName;
            this.gridColumn1.FieldName = "cDepCode";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // lueDepName
            // 
            this.lueDepName.AutoHeight = false;
            this.lueDepName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDepName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", "编码", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", "名称", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.lueDepName.DisplayMember = "cDepName";
            this.lueDepName.Name = "lueDepName";
            this.lueDepName.ValueMember = "cDepCode";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "月份";
            this.gridColumn2.ColumnEdit = this.cboiMonths;
            this.gridColumn2.FieldName = "iMonth";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 100;
            // 
            // cboiMonths
            // 
            this.cboiMonths.AutoHeight = false;
            this.cboiMonths.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboiMonths.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cboiMonths.Name = "cboiMonths";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "计划值";
            this.gridColumn3.FieldName = "nAmount";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 6;
            this.gridColumn3.Width = 173;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "参考值1";
            this.gridColumn4.FieldName = "cRefs1";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 173;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "参考值2";
            this.gridColumn5.FieldName = "cRefs2";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 173;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "实际金额";
            this.gridColumn6.FieldName = "isum";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 7;
            this.gridColumn6.Width = 176;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "年份";
            this.gridColumn7.FieldName = "iYear";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "完成额";
            this.gridColumn8.FieldName = "fRate";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 8;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "客户/门店";
            this.gridColumn9.ColumnEdit = this.luecShopCode;
            this.gridColumn9.FieldName = "cShopCode";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            // 
            // luecShopCode
            // 
            this.luecShopCode.AutoHeight = false;
            this.luecShopCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luecShopCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cShopCode", "编码", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", "名称", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.luecShopCode.DisplayMember = "cDepName";
            this.luecShopCode.Name = "luecShopCode";
            this.luecShopCode.ValueMember = "cShopCode";
            // 
            // frmSaleCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tab);
            this.Name = "frmSaleCount";
            this.Size = new System.Drawing.Size(1218, 538);
            this.tab.ResumeLayout(false);
            this.tpMonth.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luecDepCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboiMonth)).EndInit();
            this.tpShop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDepName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboiMonths)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luecShopCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tpMonth;
        private DevExpress.XtraGrid.GridControl gcList;
        private DevExpress.XtraGrid.Views.Grid.GridView gcView;
        private DevExpress.XtraGrid.Columns.GridColumn gccDepCode;
        private DevExpress.XtraGrid.Columns.GridColumn gciMonth;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboiMonth;
        private DevExpress.XtraGrid.Columns.GridColumn gcnAmount;
        private DevExpress.XtraGrid.Columns.GridColumn gccRef1;
        private DevExpress.XtraGrid.Columns.GridColumn gccRef2;
        private DevExpress.XtraGrid.Columns.GridColumn gcreal;
        private System.Windows.Forms.TabPage tpShop;
        private DevExpress.XtraGrid.Columns.GridColumn gciYear;
        private DevExpress.XtraGrid.Columns.GridColumn gcfRate;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luecDepCode;
        private DevExpress.XtraGrid.GridControl gdList;
        private DevExpress.XtraGrid.Views.Grid.GridView gdView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueDepName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboiMonths;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luecShopCode;
    }
}
