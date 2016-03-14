namespace U8_Sale
{
    partial class frmSalePlanShop
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalePlanShop));
            this.luecShopCode = new DevExpress.XtraEditors.LookUpEdit();
            this.gciMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboiMonth = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gccSalePlanId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gccSalePlanSId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcnAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gccRef1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gccRef2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gccMemo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcList = new DevExpress.XtraGrid.GridControl();
            this.btndailyAdd = new DevExpress.XtraEditors.SimpleButton();
            this.luecCusCode = new DevExpress.XtraEditors.LookUpEdit();
            this.luecDepCode = new DevExpress.XtraEditors.LookUpEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbModify = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNewVoucher = new System.Windows.Forms.ToolStripButton();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDel = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtcMemo = new DevExpress.XtraEditors.TextEdit();
            this.tsbEmpty = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tspAllAdd = new System.Windows.Forms.ToolStripButton();
            this.btndailyModify = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.luecShopCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboiMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luecCusCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luecDepCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcMemo.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // luecShopCode
            // 
            this.luecShopCode.Location = new System.Drawing.Point(278, 9);
            this.luecShopCode.Name = "luecShopCode";
            this.luecShopCode.Properties.AutoSearchColumnIndex = 1;
            this.luecShopCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luecShopCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cShopCode", "编码", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", "名称", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.luecShopCode.Properties.DisplayMember = "cDepName";
            this.luecShopCode.Properties.ImmediatePopup = true;
            this.luecShopCode.Properties.ReadOnly = true;
            this.luecShopCode.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.luecShopCode.Properties.ValueMember = "cShopCode";
            this.luecShopCode.Size = new System.Drawing.Size(148, 21);
            this.luecShopCode.TabIndex = 134;
            // 
            // gciMonth
            // 
            this.gciMonth.Caption = "月份";
            this.gciMonth.ColumnEdit = this.cboiMonth;
            this.gciMonth.FieldName = "iMonth";
            this.gciMonth.Name = "gciMonth";
            this.gciMonth.Visible = true;
            this.gciMonth.VisibleIndex = 0;
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
            this.cboiMonth.EditValueChanged += new System.EventHandler(this.cboiMonth_EditValueChanged);
            // 
            // gccSalePlanId
            // 
            this.gccSalePlanId.Caption = "销售计划Id";
            this.gccSalePlanId.FieldName = "cSalePlanId";
            this.gccSalePlanId.Name = "gccSalePlanId";
            // 
            // gccSalePlanSId
            // 
            this.gccSalePlanSId.Caption = "门店月计划Id";
            this.gccSalePlanSId.FieldName = "cSalePlanSId";
            this.gccSalePlanSId.Name = "gccSalePlanSId";
            // 
            // gcView
            // 
            this.gcView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gccSalePlanSId,
            this.gccSalePlanId,
            this.gciMonth,
            this.gcnAmount,
            this.gccRef1,
            this.gccRef2,
            this.gccMemo});
            this.gcView.GridControl = this.gcList;
            this.gcView.IndicatorWidth = 30;
            this.gcView.Name = "gcView";
            this.gcView.OptionsNavigation.AutoFocusNewRow = true;
            this.gcView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gcView.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gcView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gcView_CustomDrawRowIndicator);
            // 
            // gcnAmount
            // 
            this.gcnAmount.Caption = "计划值";
            this.gcnAmount.FieldName = "nAmount";
            this.gcnAmount.Name = "gcnAmount";
            this.gcnAmount.Visible = true;
            this.gcnAmount.VisibleIndex = 1;
            // 
            // gccRef1
            // 
            this.gccRef1.Caption = "参考值1";
            this.gccRef1.FieldName = "cRefs1";
            this.gccRef1.Name = "gccRef1";
            this.gccRef1.Visible = true;
            this.gccRef1.VisibleIndex = 2;
            // 
            // gccRef2
            // 
            this.gccRef2.Caption = "参考值2";
            this.gccRef2.FieldName = "cRefs2";
            this.gccRef2.Name = "gccRef2";
            this.gccRef2.Visible = true;
            this.gccRef2.VisibleIndex = 3;
            // 
            // gccMemo
            // 
            this.gccMemo.Caption = "备注";
            this.gccMemo.FieldName = "cMemo";
            this.gccMemo.Name = "gccMemo";
            this.gccMemo.Visible = true;
            this.gccMemo.VisibleIndex = 4;
            // 
            // gcList
            // 
            this.gcList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcList.EmbeddedNavigator.Name = "";
            this.gcList.Location = new System.Drawing.Point(2, 2);
            this.gcList.MainView = this.gcView;
            this.gcList.Name = "gcList";
            this.gcList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cboiMonth});
            this.gcList.Size = new System.Drawing.Size(708, 444);
            this.gcList.TabIndex = 132;
            this.gcList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gcView});
            // 
            // btndailyAdd
            // 
            this.btndailyAdd.Enabled = false;
            this.btndailyAdd.Location = new System.Drawing.Point(444, 42);
            this.btndailyAdd.Name = "btndailyAdd";
            this.btndailyAdd.Size = new System.Drawing.Size(97, 23);
            this.btndailyAdd.TabIndex = 136;
            this.btndailyAdd.Text = "日计划增加";
            this.btndailyAdd.Click += new System.EventHandler(this.btndaily_Click);
            // 
            // luecCusCode
            // 
            this.luecCusCode.Location = new System.Drawing.Point(67, 9);
            this.luecCusCode.Name = "luecCusCode";
            this.luecCusCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luecCusCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusCode", "客户编码", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusName", "客户名称", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.luecCusCode.Properties.DisplayMember = "cCusName";
            this.luecCusCode.Properties.ValueMember = "cCusCode";
            this.luecCusCode.Size = new System.Drawing.Size(137, 21);
            this.luecCusCode.TabIndex = 133;
            this.luecCusCode.EditValueChanged += new System.EventHandler(this.luecCusCode_EditValueChanged);
            // 
            // luecDepCode
            // 
            this.luecDepCode.Location = new System.Drawing.Point(482, 9);
            this.luecDepCode.Name = "luecDepCode";
            this.luecDepCode.Properties.AutoSearchColumnIndex = 1;
            this.luecDepCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luecDepCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", "编码", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", "名称", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.luecDepCode.Properties.DisplayMember = "cDepName";
            this.luecDepCode.Properties.ImmediatePopup = true;
            this.luecDepCode.Properties.ReadOnly = true;
            this.luecDepCode.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.luecDepCode.Properties.ValueMember = "cDepCode";
            this.luecDepCode.Size = new System.Drawing.Size(151, 21);
            this.luecDepCode.TabIndex = 135;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(442, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 131;
            this.label4.Text = "办事处：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 130;
            this.label3.Text = "备注：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 129;
            this.label2.Text = "客户：";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbModify
            // 
            this.tsbModify.Image = ((System.Drawing.Image)(resources.GetObject("tsbModify.Image")));
            this.tsbModify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbModify.Name = "tsbModify";
            this.tsbModify.Size = new System.Drawing.Size(49, 22);
            this.tsbModify.Text = "修改";
            this.tsbModify.Click += new System.EventHandler(this.tsbModify_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(49, 22);
            this.tsbDelete.Text = "删除";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbNewVoucher
            // 
            this.tsbNewVoucher.Image = ((System.Drawing.Image)(resources.GetObject("tsbNewVoucher.Image")));
            this.tsbNewVoucher.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewVoucher.Name = "tsbNewVoucher";
            this.tsbNewVoucher.Size = new System.Drawing.Size(49, 22);
            this.tsbNewVoucher.Text = "新建";
            this.tsbNewVoucher.Click += new System.EventHandler(this.tsbNewVoucher_Click);
            // 
            // tsbNew
            // 
            this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(49, 22);
            this.tsbNew.Text = "增行";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbDel
            // 
            this.tsbDel.Image = ((System.Drawing.Image)(resources.GetObject("tsbDel.Image")));
            this.tsbDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDel.Name = "tsbDel";
            this.tsbDel.Size = new System.Drawing.Size(49, 22);
            this.tsbDel.Text = "删行";
            this.tsbDel.Click += new System.EventHandler(this.tsbDel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 128;
            this.label1.Text = "门店：";
            // 
            // txtcMemo
            // 
            this.txtcMemo.Location = new System.Drawing.Point(67, 44);
            this.txtcMemo.Name = "txtcMemo";
            this.txtcMemo.Size = new System.Drawing.Size(348, 21);
            this.txtcMemo.TabIndex = 127;
            // 
            // tsbEmpty
            // 
            this.tsbEmpty.Image = ((System.Drawing.Image)(resources.GetObject("tsbEmpty.Image")));
            this.tsbEmpty.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEmpty.Name = "tsbEmpty";
            this.tsbEmpty.Size = new System.Drawing.Size(49, 22);
            this.tsbEmpty.Text = "清空";
            this.tsbEmpty.Click += new System.EventHandler(this.tsbEmpty_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSave
            // 
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(49, 22);
            this.tsbSave.Text = "保存";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNewVoucher,
            this.toolStripSeparator1,
            this.tsbDelete,
            this.tsbModify,
            this.toolStripSeparator4,
            this.tsbNew,
            this.toolStripSeparator2,
            this.tsbDel,
            this.tsbSave,
            this.toolStripSeparator3,
            this.tsbEmpty,
            this.tspAllAdd});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(712, 25);
            this.toolStrip1.TabIndex = 126;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tspAllAdd
            // 
            this.tspAllAdd.Image = ((System.Drawing.Image)(resources.GetObject("tspAllAdd.Image")));
            this.tspAllAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspAllAdd.Name = "tspAllAdd";
            this.tspAllAdd.Size = new System.Drawing.Size(73, 22);
            this.tspAllAdd.Text = "批量增行";
            this.tspAllAdd.Click += new System.EventHandler(this.tspAllAdd_Click);
            // 
            // btndailyModify
            // 
            this.btndailyModify.Enabled = false;
            this.btndailyModify.Location = new System.Drawing.Point(547, 42);
            this.btndailyModify.Name = "btndailyModify";
            this.btndailyModify.Size = new System.Drawing.Size(97, 23);
            this.btndailyModify.TabIndex = 137;
            this.btndailyModify.Text = "日计划修改";
            this.btndailyModify.Click += new System.EventHandler(this.btndailyModify_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.btndailyModify);
            this.panelControl1.Controls.Add(this.luecCusCode);
            this.panelControl1.Controls.Add(this.luecShopCode);
            this.panelControl1.Controls.Add(this.btndailyAdd);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.luecDepCode);
            this.panelControl1.Controls.Add(this.txtcMemo);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 25);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(712, 100);
            this.panelControl1.TabIndex = 138;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gcList);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 125);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(712, 448);
            this.panelControl2.TabIndex = 139;
            // 
            // frmSalePlanShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 573);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmSalePlanShop";
            this.Text = "frmSalePlanShop";
            this.Load += new System.EventHandler(this.frmSalePlanShop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.luecShopCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboiMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luecCusCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luecDepCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcMemo.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit luecShopCode;
        private DevExpress.XtraGrid.Columns.GridColumn gciMonth;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboiMonth;
        private DevExpress.XtraGrid.Columns.GridColumn gccSalePlanId;
        private DevExpress.XtraGrid.Columns.GridColumn gccSalePlanSId;
        private DevExpress.XtraGrid.Views.Grid.GridView gcView;
        private DevExpress.XtraGrid.Columns.GridColumn gcnAmount;
        private DevExpress.XtraGrid.Columns.GridColumn gccRef1;
        private DevExpress.XtraGrid.Columns.GridColumn gccRef2;
        private DevExpress.XtraGrid.Columns.GridColumn gccMemo;
        private DevExpress.XtraGrid.GridControl gcList;
        private DevExpress.XtraEditors.SimpleButton btndailyAdd;
        private DevExpress.XtraEditors.LookUpEdit luecCusCode;
        private DevExpress.XtraEditors.LookUpEdit luecDepCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbModify;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbNewVoucher;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbDel;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtcMemo;
        private System.Windows.Forms.ToolStripButton tsbEmpty;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tspAllAdd;
        private DevExpress.XtraEditors.SimpleButton btndailyModify;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
    }
}