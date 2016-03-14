namespace U8_Sale
{
    partial class frmSalePlan_Shop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalePlan_Shop));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNewVoucher = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbModify = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDel = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEmpty = new System.Windows.Forms.ToolStripButton();
            this.txtcMemo = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gcList = new DevExpress.XtraGrid.GridControl();
            this.gcView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gccSalePlanSId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gccSalePlanId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gciMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboiMonth = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gcnAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gccRef1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gccRef2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gccMemo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luecCusCode = new DevExpress.XtraEditors.LookUpEdit();
            this.luecDepCode = new DevExpress.XtraEditors.LookUpEdit();
            this.btndailyAdd = new DevExpress.XtraEditors.SimpleButton();
            this.luecShopCode = new DevExpress.XtraEditors.LookUpEdit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtcMemo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboiMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luecCusCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luecDepCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luecShopCode.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.tsbEmpty});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(720, 25);
            this.toolStrip1.TabIndex = 112;
            this.toolStrip1.Text = "toolStrip1";
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            // tsbModify
            // 
            this.tsbModify.Image = ((System.Drawing.Image)(resources.GetObject("tsbModify.Image")));
            this.tsbModify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbModify.Name = "tsbModify";
            this.tsbModify.Size = new System.Drawing.Size(49, 22);
            this.tsbModify.Text = "修改";
            this.tsbModify.Click += new System.EventHandler(this.tsbModify_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
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
            // tsbSave
            // 
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(49, 22);
            this.tsbSave.Text = "保存";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
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
            // txtcMemo
            // 
            this.txtcMemo.Location = new System.Drawing.Point(67, 79);
            this.txtcMemo.Name = "txtcMemo";
            this.txtcMemo.Size = new System.Drawing.Size(348, 21);
            this.txtcMemo.TabIndex = 114;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(229, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 117;
            this.label1.Text = "门店：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 118;
            this.label2.Text = "客户：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 119;
            this.label3.Text = "备注：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(432, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 120;
            this.label4.Text = "办事处：";
            // 
            // gcList
            // 
            this.gcList.EmbeddedNavigator.Name = "";
            this.gcList.Location = new System.Drawing.Point(22, 136);
            this.gcList.MainView = this.gcView;
            this.gcList.Name = "gcList";
            this.gcList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cboiMonth});
            this.gcList.Size = new System.Drawing.Size(662, 284);
            this.gcList.TabIndex = 121;
            this.gcList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gcView});
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
            this.gcView.Name = "gcView";
            this.gcView.OptionsNavigation.AutoFocusNewRow = true;
            this.gcView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            // 
            // gccSalePlanSId
            // 
            this.gccSalePlanSId.Caption = "门店月计划Id";
            this.gccSalePlanSId.FieldName = "cSalePlanSId";
            this.gccSalePlanSId.Name = "gccSalePlanSId";
            // 
            // gccSalePlanId
            // 
            this.gccSalePlanId.Caption = "销售计划Id";
            this.gccSalePlanId.FieldName = "cSalePlanId";
            this.gccSalePlanId.Name = "gccSalePlanId";
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
            // luecCusCode
            // 
            this.luecCusCode.Location = new System.Drawing.Point(67, 45);
            this.luecCusCode.Name = "luecCusCode";
            this.luecCusCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luecCusCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusCode", "客户编码", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusName", "客户名称", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.luecCusCode.Properties.DisplayMember = "cCusName";
            this.luecCusCode.Properties.ValueMember = "cCusCode";
            this.luecCusCode.Size = new System.Drawing.Size(137, 21);
            this.luecCusCode.TabIndex = 122;
            // 
            // luecDepCode
            // 
            this.luecDepCode.Location = new System.Drawing.Point(491, 45);
            this.luecDepCode.Name = "luecDepCode";
            this.luecDepCode.Properties.AutoSearchColumnIndex = 1;
            this.luecDepCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luecDepCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", "编码", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", "名称", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.luecDepCode.Properties.DisplayMember = "cDepName";
            this.luecDepCode.Properties.ImmediatePopup = true;
            this.luecDepCode.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.luecDepCode.Properties.ValueMember = "cDepCode";
            this.luecDepCode.Size = new System.Drawing.Size(151, 21);
            this.luecDepCode.TabIndex = 124;
            // 
            // btndailyAdd
            // 
            this.btndailyAdd.Enabled = false;
            this.btndailyAdd.Location = new System.Drawing.Point(491, 77);
            this.btndailyAdd.Name = "btndailyAdd";
            this.btndailyAdd.Size = new System.Drawing.Size(97, 23);
            this.btndailyAdd.TabIndex = 125;
            this.btndailyAdd.Text = "日计划";
            this.btndailyAdd.Click += new System.EventHandler(this.btndaily_Click);
            // 
            // luecShopCode
            // 
            this.luecShopCode.Location = new System.Drawing.Point(267, 45);
            this.luecShopCode.Name = "luecShopCode";
            this.luecShopCode.Properties.AutoSearchColumnIndex = 1;
            this.luecShopCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luecShopCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cShopCode", "编码", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", "名称", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.luecShopCode.Properties.DisplayMember = "cDepName";
            this.luecShopCode.Properties.ImmediatePopup = true;
            this.luecShopCode.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.luecShopCode.Properties.ValueMember = "cShopCode";
            this.luecShopCode.Size = new System.Drawing.Size(148, 21);
            this.luecShopCode.TabIndex = 123;
            // 
            // frmSalePlan_Shop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btndailyAdd);
            this.Controls.Add(this.luecDepCode);
            this.Controls.Add(this.luecShopCode);
            this.Controls.Add(this.luecCusCode);
            this.Controls.Add(this.gcList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtcMemo);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmSalePlan_Shop";
            this.Size = new System.Drawing.Size(720, 600);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtcMemo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboiMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luecCusCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luecDepCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luecShopCode.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbNewVoucher;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbModify;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbDel;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbEmpty;
        private DevExpress.XtraEditors.TextEdit txtcMemo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraGrid.GridControl gcList;
        private DevExpress.XtraGrid.Views.Grid.GridView gcView;
        private DevExpress.XtraGrid.Columns.GridColumn gccSalePlanSId;
        private DevExpress.XtraGrid.Columns.GridColumn gccSalePlanId;
        private DevExpress.XtraGrid.Columns.GridColumn gciMonth;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboiMonth;
        private DevExpress.XtraGrid.Columns.GridColumn gcnAmount;
        private DevExpress.XtraGrid.Columns.GridColumn gccRef1;
        private DevExpress.XtraGrid.Columns.GridColumn gccRef2;
        private DevExpress.XtraGrid.Columns.GridColumn gccMemo;
        private DevExpress.XtraEditors.LookUpEdit luecCusCode;
        private DevExpress.XtraEditors.LookUpEdit luecDepCode;
        private DevExpress.XtraEditors.SimpleButton btndailyAdd;
        private DevExpress.XtraEditors.LookUpEdit luecShopCode;
    }
}
