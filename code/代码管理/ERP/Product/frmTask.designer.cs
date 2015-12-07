namespace Product
{
    partial class frmTask
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.editControl5 = new myControl.EditControl();
            this.editDept = new myControl.EditControl();
            this.sbSelDept = new DevExpress.XtraEditors.SimpleButton();
            this.lbDept = new System.Windows.Forms.Label();
            this.TabControl = new DevExpress.XtraTab.XtraTabControl();
            this.TabProduct = new DevExpress.XtraTab.XtraTabPage();
            this.gcDept = new DevExpress.XtraGrid.GridControl();
            this.binDept = new System.Windows.Forms.BindingSource(this.components);
            this.gvDept = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lupDept = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TabHalf = new DevExpress.XtraTab.XtraTabPage();
            this.gcHalf = new DevExpress.XtraGrid.GridControl();
            this.binHalf = new System.Windows.Forms.BindingSource(this.components);
            this.gvHalf = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TabItem = new DevExpress.XtraTab.XtraTabPage();
            this.gcItem = new DevExpress.XtraGrid.GridControl();
            this.binItem = new System.Windows.Forms.BindingSource(this.components);
            this.gvItem = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.sbExpand = new DevExpress.XtraEditors.SimpleButton();
            this.sbLoadDept = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.binMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binSlaver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabControl)).BeginInit();
            this.TabControl.SuspendLayout();
            this.TabProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binDept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupDept)).BeginInit();
            this.TabHalf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcHalf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binHalf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHalf)).BeginInit();
            this.TabItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItem)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.Size = new System.Drawing.Size(94, 21);
            this.lbTitle.Text = "frmBase";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.OldLace;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.sbLoadDept);
            this.panelControl1.Controls.Add(this.sbExpand);
            this.panelControl1.Controls.Add(this.lbDept);
            this.panelControl1.Controls.Add(this.sbSelDept);
            this.panelControl1.Controls.Add(this.editDept);
            this.panelControl1.Controls.Add(this.editControl5);
            this.panelControl1.Location = new System.Drawing.Point(0, 26);
            this.panelControl1.Size = new System.Drawing.Size(798, 126);
            this.panelControl1.Controls.SetChildIndex(this.lbTitle, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.dateControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl5, 0);
            this.panelControl1.Controls.SetChildIndex(this.editDept, 0);
            this.panelControl1.Controls.SetChildIndex(this.sbSelDept, 0);
            this.panelControl1.Controls.SetChildIndex(this.lbDept, 0);
            this.panelControl1.Controls.SetChildIndex(this.sbExpand, 0);
            this.panelControl1.Controls.SetChildIndex(this.sbLoadDept, 0);
            // 
            // editControl4
            // 
            this.editControl4.Location = new System.Drawing.Point(591, 6);
            // 
            // editControl3
            // 
            this.editControl3.Location = new System.Drawing.Point(268, 6);
            // 
            // dateControl1
            // 
            this.dateControl1.Location = new System.Drawing.Point(484, 35);
            // 
            // editControl1
            // 
            this.editControl1.Location = new System.Drawing.Point(484, 6);
            // 
            // editControl5
            // 
            this.editControl5.BackColor = System.Drawing.Color.Transparent;
            this.editControl5.DataField = "F_Remark";
            this.editControl5.DataSource = null;
            this.editControl5.EditLabel = "备注:";
            this.editControl5.Location = new System.Drawing.Point(37, 91);
            this.editControl5.Name = "editControl5";
            this.editControl5.Request = false;
            this.editControl5.Size = new System.Drawing.Size(476, 23);
            this.editControl5.TabIndex = 4;
            // 
            // editDept
            // 
            this.editDept.BackColor = System.Drawing.Color.Transparent;
            this.editDept.DataField = "F_DeptID";
            this.editDept.DataSource = null;
            this.editDept.EditLabel = "部门:";
            this.editDept.Location = new System.Drawing.Point(37, 64);
            this.editDept.Name = "editDept";
            this.editDept.Request = true;
            this.editDept.Size = new System.Drawing.Size(211, 21);
            this.editDept.TabIndex = 8;
            // 
            // sbSelDept
            // 
            this.sbSelDept.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbSelDept.Appearance.Options.UseFont = true;
            this.sbSelDept.Location = new System.Drawing.Point(248, 64);
            this.sbSelDept.Name = "sbSelDept";
            this.sbSelDept.Size = new System.Drawing.Size(20, 23);
            this.sbSelDept.TabIndex = 9;
            this.sbSelDept.Text = "...";
            this.sbSelDept.Click += new System.EventHandler(this.sbSelDept_Click);
            // 
            // lbDept
            // 
            this.lbDept.AutoSize = true;
            this.lbDept.Location = new System.Drawing.Point(274, 73);
            this.lbDept.Name = "lbDept";
            this.lbDept.Size = new System.Drawing.Size(0, 12);
            this.lbDept.TabIndex = 10;
            // 
            // TabControl
            // 
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.TabControl.Location = new System.Drawing.Point(0, 152);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedTabPage = this.TabProduct;
            this.TabControl.Size = new System.Drawing.Size(798, 311);
            this.TabControl.TabIndex = 11;
            this.TabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.TabProduct,
            this.TabHalf,
            this.TabItem});
            this.TabControl.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.TabControl_SelectedPageChanged);
            // 
            // TabProduct
            // 
            this.TabProduct.Controls.Add(this.gcDept);
            this.TabProduct.Name = "TabProduct";
            this.TabProduct.Size = new System.Drawing.Size(789, 279);
            this.TabProduct.Text = "产品";
            // 
            // gcDept
            // 
            this.gcDept.DataSource = this.binDept;
            this.gcDept.Dock = System.Windows.Forms.DockStyle.Right;
            this.gcDept.EmbeddedNavigator.Name = "";
            this.gcDept.Location = new System.Drawing.Point(528, 0);
            this.gcDept.MainView = this.gvDept;
            this.gcDept.Name = "gcDept";
            this.gcDept.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lupDept});
            this.gcDept.Size = new System.Drawing.Size(261, 279);
            this.gcDept.TabIndex = 0;
            this.gcDept.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDept});
            // 
            // gvDept
            // 
            this.gvDept.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gvDept.GridControl = this.gcDept;
            this.gvDept.Name = "gvDept";
            this.gvDept.OptionsCustomization.AllowFilter = false;
            this.gvDept.OptionsView.ColumnAutoWidth = false;
            this.gvDept.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn1.Caption = "部门";
            this.gridColumn1.ColumnEdit = this.lupDept;
            this.gridColumn1.FieldName = "F_DeptID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // lupDept
            // 
            this.lupDept.AutoHeight = false;
            this.lupDept.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupDept.Name = "lupDept";
            this.lupDept.NullText = "";
            this.lupDept.ShowFooter = false;
            this.lupDept.ShowHeader = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn2.Caption = "开始日期";
            this.gridColumn2.FieldName = "F_Begindate";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn3.Caption = "结束日期";
            this.gridColumn3.FieldName = "F_Enddate";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // TabHalf
            // 
            this.TabHalf.Controls.Add(this.gcHalf);
            this.TabHalf.Name = "TabHalf";
            this.TabHalf.Size = new System.Drawing.Size(789, 279);
            this.TabHalf.Text = "半成品";
            // 
            // gcHalf
            // 
            this.gcHalf.DataSource = this.binHalf;
            this.gcHalf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcHalf.EmbeddedNavigator.Name = "";
            this.gcHalf.Location = new System.Drawing.Point(0, 0);
            this.gcHalf.MainView = this.gvHalf;
            this.gcHalf.Name = "gcHalf";
            this.gcHalf.Size = new System.Drawing.Size(789, 279);
            this.gcHalf.TabIndex = 0;
            this.gcHalf.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvHalf});
            // 
            // gvHalf
            // 
            this.gvHalf.GridControl = this.gcHalf;
            this.gvHalf.Name = "gvHalf";
            this.gvHalf.OptionsCustomization.AllowFilter = false;
            this.gvHalf.OptionsLayout.Columns.StoreAllOptions = true;
            this.gvHalf.OptionsLayout.Columns.StoreAppearance = true;
            this.gvHalf.OptionsLayout.StoreDataSettings = false;
            this.gvHalf.OptionsLayout.StoreVisualOptions = false;
            this.gvHalf.OptionsView.ColumnAutoWidth = false;
            this.gvHalf.OptionsView.ShowFooter = true;
            this.gvHalf.OptionsView.ShowGroupPanel = false;
            // 
            // TabItem
            // 
            this.TabItem.Controls.Add(this.gcItem);
            this.TabItem.Name = "TabItem";
            this.TabItem.Size = new System.Drawing.Size(789, 279);
            this.TabItem.Text = "原材料";
            // 
            // gcItem
            // 
            this.gcItem.DataSource = this.binItem;
            this.gcItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcItem.EmbeddedNavigator.Name = "";
            this.gcItem.Location = new System.Drawing.Point(0, 0);
            this.gcItem.MainView = this.gvItem;
            this.gcItem.Name = "gcItem";
            this.gcItem.Size = new System.Drawing.Size(789, 279);
            this.gcItem.TabIndex = 1;
            this.gcItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvItem});
            // 
            // gvItem
            // 
            this.gvItem.GridControl = this.gcItem;
            this.gvItem.Name = "gvItem";
            this.gvItem.OptionsCustomization.AllowFilter = false;
            this.gvItem.OptionsLayout.Columns.StoreAllOptions = true;
            this.gvItem.OptionsLayout.Columns.StoreAppearance = true;
            this.gvItem.OptionsLayout.StoreDataSettings = false;
            this.gvItem.OptionsLayout.StoreVisualOptions = false;
            this.gvItem.OptionsView.ColumnAutoWidth = false;
            this.gvItem.OptionsView.ShowFooter = true;
            this.gvItem.OptionsView.ShowGroupPanel = false;
            // 
            // sbExpand
            // 
            this.sbExpand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbExpand.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbExpand.Appearance.Options.UseFont = true;
            this.sbExpand.Location = new System.Drawing.Point(633, 91);
            this.sbExpand.Name = "sbExpand";
            this.sbExpand.Size = new System.Drawing.Size(63, 23);
            this.sbExpand.TabIndex = 11;
            this.sbExpand.Text = "展开";
            this.sbExpand.Click += new System.EventHandler(this.sbExpand_Click);
            // 
            // sbLoadDept
            // 
            this.sbLoadDept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbLoadDept.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbLoadDept.Appearance.Options.UseFont = true;
            this.sbLoadDept.Location = new System.Drawing.Point(716, 91);
            this.sbLoadDept.Name = "sbLoadDept";
            this.sbLoadDept.Size = new System.Drawing.Size(75, 23);
            this.sbLoadDept.TabIndex = 12;
            this.sbLoadDept.Text = "调入部门";
            this.sbLoadDept.Click += new System.EventHandler(this.sbLoadDept_Click);
            // 
            // frmTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(798, 519);
            this.Controls.Add(this.TabControl);
            this.Name = "frmTask";
            this.Text = "生产任务单";
            this.Load += new System.EventHandler(this.frmStockOrder_Load);
            this.Shown += new System.EventHandler(this.frmTask_Shown);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.TabControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.binMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binSlaver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabControl)).EndInit();
            this.TabControl.ResumeLayout(false);
            this.TabProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binDept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupDept)).EndInit();
            this.TabHalf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcHalf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binHalf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHalf)).EndInit();
            this.TabItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton sbSelDept;
        private System.Windows.Forms.Label lbDept;
        private DevExpress.XtraTab.XtraTabPage TabProduct;
        private DevExpress.XtraTab.XtraTabPage TabHalf;
        private DevExpress.XtraTab.XtraTabPage TabItem;
        private DevExpress.XtraGrid.GridControl gcHalf;
        private DevExpress.XtraGrid.Views.Grid.GridView gvHalf;
        private DevExpress.XtraGrid.GridControl gcItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItem;
        private System.Windows.Forms.BindingSource binHalf;
        private System.Windows.Forms.BindingSource binItem;
        private DevExpress.XtraGrid.GridControl gcDept;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDept;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.SimpleButton sbLoadDept;
        private System.Windows.Forms.BindingSource binDept;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lupDept;
        public myControl.EditControl editControl5;
        public myControl.EditControl editDept;
        public DevExpress.XtraEditors.SimpleButton sbExpand;
        public DevExpress.XtraTab.XtraTabControl TabControl;
    }
}
