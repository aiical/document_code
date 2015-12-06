namespace U8_Sale
{
    partial class frmSalePlanSdaily
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalePlanSdaily));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
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
            this.luecShopCode = new DevExpress.XtraEditors.LookUpEdit();
            this.gcList = new DevExpress.XtraGrid.GridControl();
            this.gdView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gccDailyId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcdDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dtdDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gcnAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gccRef1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gccRef2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcholiday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gccSalePlanSId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gccMemo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtnAmount = new DevExpress.XtraEditors.TextEdit();
            this.txtcMemo = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboiMonth = new DevExpress.XtraEditors.ComboBoxEdit();
            this.luecDepCode = new DevExpress.XtraEditors.LookUpEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnAllAdd = new DevExpress.XtraEditors.SimpleButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luecShopCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtdDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtdDate.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcMemo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboiMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luecDepCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.toolStrip1.Size = new System.Drawing.Size(933, 25);
            this.toolStrip1.TabIndex = 147;
            this.toolStrip1.Text = "toolStrip1";
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
            // luecShopCode
            // 
            this.luecShopCode.Location = new System.Drawing.Point(75, 14);
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
            this.luecShopCode.TabIndex = 136;
            // 
            // gcList
            // 
            this.gcList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcList.EmbeddedNavigator.Name = "";
            this.gcList.Location = new System.Drawing.Point(2, 2);
            this.gcList.MainView = this.gdView;
            this.gcList.Name = "gcList";
            this.gcList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.dtdDate});
            this.gcList.Size = new System.Drawing.Size(929, 407);
            this.gcList.TabIndex = 146;
            this.gcList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdView});
            // 
            // gdView
            // 
            this.gdView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gccDailyId,
            this.gcdDate,
            this.gcnAmount,
            this.gccRef1,
            this.gccRef2,
            this.gcholiday,
            this.gccSalePlanSId,
            this.gccMemo});
            this.gdView.GridControl = this.gcList;
            this.gdView.IndicatorWidth = 30;
            this.gdView.Name = "gdView";
            this.gdView.OptionsNavigation.AutoFocusNewRow = true;
            this.gdView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gdView.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gdView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gdView_CustomDrawRowIndicator);
            // 
            // gccDailyId
            // 
            this.gccDailyId.Caption = "门店日计划ID";
            this.gccDailyId.FieldName = "cDailyId";
            this.gccDailyId.Name = "gccDailyId";
            // 
            // gcdDate
            // 
            this.gcdDate.Caption = "日期";
            this.gcdDate.ColumnEdit = this.dtdDate;
            this.gcdDate.FieldName = "dDate";
            this.gcdDate.Name = "gcdDate";
            this.gcdDate.Visible = true;
            this.gcdDate.VisibleIndex = 0;
            // 
            // dtdDate
            // 
            this.dtdDate.AutoHeight = false;
            this.dtdDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtdDate.DisplayFormat.FormatString = "dd";
            this.dtdDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtdDate.EditFormat.FormatString = "yyyy-mm-dd";
            this.dtdDate.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtdDate.Mask.EditMask = "yyyy-MM-dd";
            this.dtdDate.Name = "dtdDate";
            this.dtdDate.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
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
            // gcholiday
            // 
            this.gcholiday.Caption = "节假日";
            this.gcholiday.FieldName = "holiday";
            this.gcholiday.Name = "gcholiday";
            this.gcholiday.Visible = true;
            this.gcholiday.VisibleIndex = 5;
            // 
            // gccSalePlanSId
            // 
            this.gccSalePlanSId.Caption = "门店月计划ID";
            this.gccSalePlanSId.FieldName = "cSalePlanSId";
            this.gccSalePlanSId.Name = "gccSalePlanSId";
            // 
            // gccMemo
            // 
            this.gccMemo.Caption = "备注";
            this.gccMemo.FieldName = "cMemo";
            this.gccMemo.Name = "gccMemo";
            this.gccMemo.Visible = true;
            this.gccMemo.VisibleIndex = 4;
            // 
            // txtnAmount
            // 
            this.txtnAmount.Location = new System.Drawing.Point(75, 47);
            this.txtnAmount.Name = "txtnAmount";
            this.txtnAmount.Size = new System.Drawing.Size(130, 21);
            this.txtnAmount.TabIndex = 145;
            // 
            // txtcMemo
            // 
            this.txtcMemo.Location = new System.Drawing.Point(314, 47);
            this.txtcMemo.Name = "txtcMemo";
            this.txtcMemo.Size = new System.Drawing.Size(349, 21);
            this.txtcMemo.TabIndex = 144;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 143;
            this.label5.Text = "月计划值：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(270, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 142;
            this.label3.Text = "备注：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(490, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 141;
            this.label2.Text = "月份：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(258, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 140;
            this.label4.Text = "办事处：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 139;
            this.label1.Text = "门店：";
            // 
            // cboiMonth
            // 
            this.cboiMonth.Location = new System.Drawing.Point(537, 12);
            this.cboiMonth.Name = "cboiMonth";
            this.cboiMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboiMonth.Properties.Items.AddRange(new object[] {
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
            this.cboiMonth.Size = new System.Drawing.Size(123, 21);
            this.cboiMonth.TabIndex = 138;
            // 
            // luecDepCode
            // 
            this.luecDepCode.Location = new System.Drawing.Point(314, 12);
            this.luecDepCode.Name = "luecDepCode";
            this.luecDepCode.Properties.AutoSearchColumnIndex = 1;
            this.luecDepCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luecDepCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", "编码", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", "名称", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.luecDepCode.Properties.DisplayMember = "cDepName";
            this.luecDepCode.Properties.ImmediatePopup = true;
            this.luecDepCode.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.luecDepCode.Properties.ValueMember = "cDepCode";
            this.luecDepCode.Size = new System.Drawing.Size(151, 21);
            this.luecDepCode.TabIndex = 148;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.luecDepCode);
            this.panelControl1.Controls.Add(this.luecShopCode);
            this.panelControl1.Controls.Add(this.cboiMonth);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.txtcMemo);
            this.panelControl1.Controls.Add(this.label5);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.txtnAmount);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 25);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(933, 144);
            this.panelControl1.TabIndex = 149;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnAllAdd);
            this.panelControl2.Controls.Add(this.gcList);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 169);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(933, 411);
            this.panelControl2.TabIndex = 150;
            // 
            // btnAllAdd
            // 
            this.btnAllAdd.Location = new System.Drawing.Point(12, 6);
            this.btnAllAdd.Name = "btnAllAdd";
            this.btnAllAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAllAdd.TabIndex = 147;
            this.btnAllAdd.Text = "批量增行";
            this.btnAllAdd.Click += new System.EventHandler(this.btnAllAdd_Click);
            // 
            // frmSalePlanSdaily
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 580);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmSalePlanSdaily";
            this.Text = "门店日计划";
            this.Load += new System.EventHandler(this.frmSalePlanSdaily_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luecShopCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtdDate.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtdDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcMemo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboiMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luecDepCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
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
        private DevExpress.XtraEditors.LookUpEdit luecShopCode;
        private DevExpress.XtraGrid.GridControl gcList;
        private DevExpress.XtraEditors.TextEdit txtnAmount;
        private DevExpress.XtraEditors.TextEdit txtcMemo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.ComboBoxEdit cboiMonth;
        private DevExpress.XtraEditors.LookUpEdit luecDepCode;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gdView;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn gccDailyId;
        private DevExpress.XtraGrid.Columns.GridColumn gcdDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcnAmount;
        private DevExpress.XtraGrid.Columns.GridColumn gccRef1;
        private DevExpress.XtraGrid.Columns.GridColumn gccRef2;
        private DevExpress.XtraGrid.Columns.GridColumn gcholiday;
        private DevExpress.XtraGrid.Columns.GridColumn gccSalePlanSId;
        private DevExpress.XtraGrid.Columns.GridColumn gccMemo;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit dtdDate;
        private DevExpress.XtraEditors.SimpleButton btnAllAdd;

    }
}