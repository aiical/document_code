namespace OutProduct
{
    partial class frmOutBill
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
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem1 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem2 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            this.editControl5 = new myControl.EditControl();
            this.lupControl2 = new myControl.lupControl();
            this.cbControl1 = new myControl.cbControl();
            this.TabControl = new DevExpress.XtraTab.XtraTabControl();
            this.PageGoods = new DevExpress.XtraTab.XtraTabPage();
            this.PageItem = new DevExpress.XtraTab.XtraTabPage();
            this.gcItem = new DevExpress.XtraGrid.GridControl();
            this.binItem = new System.Windows.Forms.BindingSource(this.components);
            this.gvItem = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.sbExpand = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.binMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binSlaver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabControl)).BeginInit();
            this.TabControl.SuspendLayout();
            this.PageItem.SuspendLayout();
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
            // dateControl1
            // 
            this.dateControl1.Location = new System.Drawing.Point(501, 35);
            // 
            // editControl1
            // 
            this.editControl1.Location = new System.Drawing.Point(501, 7);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.OldLace;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.sbExpand);
            this.panelControl1.Controls.Add(this.cbControl1);
            this.panelControl1.Controls.Add(this.lupControl2);
            this.panelControl1.Controls.Add(this.editControl5);
            this.panelControl1.Location = new System.Drawing.Point(0, 26);
            this.panelControl1.Size = new System.Drawing.Size(804, 126);
            this.panelControl1.Controls.SetChildIndex(this.lbTitle, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.dateControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl5, 0);
            this.panelControl1.Controls.SetChildIndex(this.lupControl2, 0);
            this.panelControl1.Controls.SetChildIndex(this.cbControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.sbExpand, 0);
            // 
            // editControl5
            // 
            this.editControl5.BackColor = System.Drawing.Color.Transparent;
            this.editControl5.DataField = "F_Remark";
            this.editControl5.EditLabel = "备注:";
            this.editControl5.Location = new System.Drawing.Point(37, 91);
            this.editControl5.Name = "editControl5";
            this.editControl5.Request = false;
            this.editControl5.Size = new System.Drawing.Size(560, 27);
            this.editControl5.TabIndex = 4;
            // 
            // lupControl2
            // 
            this.lupControl2.BackColor = System.Drawing.Color.Transparent;
            this.lupControl2.DataField = "F_OutSupplierID";
            this.lupControl2.DisplayCaption = "";
            this.lupControl2.EditLabel = "加工厂商:";
            this.lupControl2.Location = new System.Drawing.Point(12, 63);
            this.lupControl2.LookUpDataSource = null;
            this.lupControl2.LookUpDisplayField = null;
            this.lupControl2.LookUpKeyField = null;
            this.lupControl2.Name = "lupControl2";
            this.lupControl2.PopWidth = 150;
            this.lupControl2.Request = true;
            this.lupControl2.Size = new System.Drawing.Size(292, 22);
            this.lupControl2.TabIndex = 7;
            // 
            // cbControl1
            // 
            this.cbControl1.BackColor = System.Drawing.Color.Transparent;
            comboBoxItem1.Value = "包工包料";
            comboBoxItem2.Value = "包工不包料";
            this.cbControl1.cbItem = new DevExpress.XtraEditors.Controls.ComboBoxItem[] {
        comboBoxItem1,
        comboBoxItem2};
            this.cbControl1.DataField = "F_Type";
            this.cbControl1.EditLabel = "加工类别:";
            this.cbControl1.EditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbControl1.Location = new System.Drawing.Point(427, 63);
            this.cbControl1.Name = "cbControl1";
            this.cbControl1.Request = true;
            this.cbControl1.Size = new System.Drawing.Size(170, 21);
            this.cbControl1.TabIndex = 8;
            // 
            // TabControl
            // 
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.TabControl.Location = new System.Drawing.Point(0, 152);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedTabPage = this.PageGoods;
            this.TabControl.Size = new System.Drawing.Size(804, 349);
            this.TabControl.TabIndex = 11;
            this.TabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.PageGoods,
            this.PageItem});
            this.TabControl.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.TabControl_SelectedPageChanged);
            // 
            // PageGoods
            // 
            this.PageGoods.Name = "PageGoods";
            this.PageGoods.Size = new System.Drawing.Size(795, 318);
            this.PageGoods.Text = "加工产品";
            // 
            // PageItem
            // 
            this.PageItem.Controls.Add(this.gcItem);
            this.PageItem.Name = "PageItem";
            this.PageItem.Size = new System.Drawing.Size(795, 318);
            this.PageItem.Text = "原材料";
            // 
            // gcItem
            // 
            this.gcItem.DataSource = this.binItem;
            this.gcItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcItem.EmbeddedNavigator.Name = "";
            this.gcItem.Location = new System.Drawing.Point(0, 0);
            this.gcItem.MainView = this.gvItem;
            this.gcItem.Name = "gcItem";
            this.gcItem.Size = new System.Drawing.Size(795, 318);
            this.gcItem.TabIndex = 0;
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
            this.sbExpand.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbExpand.Appearance.Options.UseFont = true;
            this.sbExpand.Location = new System.Drawing.Point(642, 91);
            this.sbExpand.Name = "sbExpand";
            this.sbExpand.Size = new System.Drawing.Size(60, 23);
            this.sbExpand.TabIndex = 9;
            this.sbExpand.Text = "展开";
            this.sbExpand.Click += new System.EventHandler(this.sbExpand_Click);
            // 
            // frmOutBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(804, 557);
            this.Controls.Add(this.TabControl);
            this.Name = "frmOutBill";
            this.Text = "委外加工单";
            this.Load += new System.EventHandler(this.frmStockOrder_Load);
            this.Shown += new System.EventHandler(this.frmOutBill_Shown);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.TabControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.binMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binSlaver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabControl)).EndInit();
            this.TabControl.ResumeLayout(false);
            this.PageItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl TabControl;
        private DevExpress.XtraTab.XtraTabPage PageGoods;
        private DevExpress.XtraTab.XtraTabPage PageItem;
        private DevExpress.XtraGrid.GridControl gcItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItem;
        private System.Windows.Forms.BindingSource binItem;
        public myControl.EditControl editControl5;
        public myControl.lupControl lupControl2;
        public myControl.cbControl cbControl1;
        public DevExpress.XtraEditors.SimpleButton sbExpand;
    }
}
