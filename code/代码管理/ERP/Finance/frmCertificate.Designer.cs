namespace Finance
{
    partial class frmCertificate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCertificate));
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem11 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem12 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem13 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem14 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem15 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btNew = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsCheck = new System.Windows.Forms.ToolStripButton();
            this.tsUnCheck = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsInsert = new System.Windows.Forms.ToolStripButton();
            this.tsDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsCal = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsClose = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gcMain = new DevExpress.XtraGrid.GridControl();
            this.binSlaver = new System.Windows.Forms.BindingSource(this.components);
            this.gvMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spinControl1 = new myControl.SpinControl();
            this.binMaster = new System.Windows.Forms.BindingSource(this.components);
            this.dateControl1 = new myControl.DateControl();
            this.cbControl1 = new myControl.cbControl();
            this.spinControl2 = new myControl.SpinControl();
            this.spinControl3 = new myControl.SpinControl();
            this.label2 = new System.Windows.Forms.Label();
            this.editControl1 = new myControl.EditControl();
            this.editControl2 = new myControl.EditControl();
            this.editControl3 = new myControl.EditControl();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binSlaver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btNew,
            this.tsSave,
            this.toolStripSeparator2,
            this.tsPrint,
            this.toolStripSeparator1,
            this.tsCheck,
            this.tsUnCheck,
            this.toolStripSeparator3,
            this.tsInsert,
            this.tsDel,
            this.toolStripSeparator4,
            this.tsCal,
            this.toolStripSeparator5,
            this.tsClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(691, 35);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btNew
            // 
            this.btNew.Image = global::Finance.Properties.Resources.btnNew_Glyph;
            this.btNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(33, 32);
            this.btNew.Text = "新增";
            this.btNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btNew.Click += new System.EventHandler(this.btNew_Click);
            // 
            // tsSave
            // 
            this.tsSave.Image = global::Finance.Properties.Resources.btnSave_Glyph;
            this.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSave.Name = "tsSave";
            this.tsSave.Size = new System.Drawing.Size(33, 32);
            this.tsSave.Text = "保存";
            this.tsSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsSave.Click += new System.EventHandler(this.tsSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
            // 
            // tsPrint
            // 
            this.tsPrint.Image = global::Finance.Properties.Resources.btnPrint_Glyph;
            this.tsPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPrint.Name = "tsPrint";
            this.tsPrint.Size = new System.Drawing.Size(33, 32);
            this.tsPrint.Text = "打印";
            this.tsPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsPrint.Click += new System.EventHandler(this.tsPrint_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // tsCheck
            // 
            this.tsCheck.Image = global::Finance.Properties.Resources.btnCheck_Glyph;
            this.tsCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsCheck.Name = "tsCheck";
            this.tsCheck.Size = new System.Drawing.Size(33, 32);
            this.tsCheck.Text = "审核";
            this.tsCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsCheck.Click += new System.EventHandler(this.tsCheck_Click);
            // 
            // tsUnCheck
            // 
            this.tsUnCheck.Image = global::Finance.Properties.Resources.btnUnCheck_Glyph;
            this.tsUnCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsUnCheck.Name = "tsUnCheck";
            this.tsUnCheck.Size = new System.Drawing.Size(33, 32);
            this.tsUnCheck.Text = "反审";
            this.tsUnCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsUnCheck.Click += new System.EventHandler(this.tsUnCheck_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 35);
            // 
            // tsInsert
            // 
            this.tsInsert.Image = global::Finance.Properties.Resources.btnAddRow_Glyph;
            this.tsInsert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsInsert.Name = "tsInsert";
            this.tsInsert.Size = new System.Drawing.Size(33, 32);
            this.tsInsert.Text = "插入";
            this.tsInsert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsInsert.Click += new System.EventHandler(this.tsInsert_Click);
            // 
            // tsDel
            // 
            this.tsDel.Image = ((System.Drawing.Image)(resources.GetObject("tsDel.Image")));
            this.tsDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDel.Name = "tsDel";
            this.tsDel.Size = new System.Drawing.Size(33, 32);
            this.tsDel.Text = "删除";
            this.tsDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsDel.Click += new System.EventHandler(this.tsDel_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 35);
            // 
            // tsCal
            // 
            this.tsCal.Image = global::Finance.Properties.Resources.btnExport_Glyph;
            this.tsCal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsCal.Name = "tsCal";
            this.tsCal.Size = new System.Drawing.Size(45, 32);
            this.tsCal.Text = "计算器";
            this.tsCal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsCal.Click += new System.EventHandler(this.tsCal_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 35);
            // 
            // tsClose
            // 
            this.tsClose.Image = global::Finance.Properties.Resources.btnClose_Glyph;
            this.tsClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsClose.Name = "tsClose";
            this.tsClose.Size = new System.Drawing.Size(33, 32);
            this.tsClose.Text = "关闭";
            this.tsClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsClose.Click += new System.EventHandler(this.tsClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体_GB2312", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(239, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "记 帐 凭 证";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.gcMain);
            this.panel1.Location = new System.Drawing.Point(12, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(667, 303);
            this.panel1.TabIndex = 2;
            // 
            // gcMain
            // 
            this.gcMain.DataSource = this.binSlaver;
            this.gcMain.EmbeddedNavigator.Name = "";
            this.gcMain.Location = new System.Drawing.Point(3, 3);
            this.gcMain.MainView = this.gvMain;
            this.gcMain.Name = "gcMain";
            this.gcMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1,
            this.repositoryItemButtonEdit2});
            this.gcMain.Size = new System.Drawing.Size(659, 295);
            this.gcMain.TabIndex = 0;
            this.gcMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMain});
            // 
            // gvMain
            // 
            this.gvMain.Appearance.FooterPanel.BackColor = System.Drawing.Color.White;
            this.gvMain.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gvMain.Appearance.HeaderPanel.BackColor = System.Drawing.Color.White;
            this.gvMain.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvMain.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvMain.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvMain.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gvMain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gvMain.GridControl = this.gcMain;
            this.gvMain.Name = "gvMain";
            this.gvMain.OptionsCustomization.AllowFilter = false;
            this.gvMain.OptionsView.ColumnAutoWidth = false;
            this.gvMain.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvMain.OptionsView.ShowFooter = true;
            this.gvMain.OptionsView.ShowGroupPanel = false;
            this.gvMain.OptionsView.ShowIndicator = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "摘要";
            this.gridColumn1.ColumnEdit = this.repositoryItemButtonEdit2;
            this.gridColumn1.FieldName = "F_Memo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 172;
            // 
            // repositoryItemButtonEdit2
            // 
            this.repositoryItemButtonEdit2.AutoHeight = false;
            this.repositoryItemButtonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            this.repositoryItemButtonEdit2.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEdit2_ButtonClick);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "会计科目";
            this.gridColumn2.ColumnEdit = this.repositoryItemButtonEdit1;
            this.gridColumn2.FieldName = "F_SubjectName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 197;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEdit1_ButtonClick);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "借方金额";
            this.gridColumn3.FieldName = "F_Debit";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 129;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "贷方金额";
            this.gridColumn4.FieldName = "F_Credit";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 131;
            // 
            // spinControl1
            // 
            this.spinControl1.BackColor = System.Drawing.Color.Transparent;
            this.spinControl1.DataField = "F_Order";
            this.spinControl1.DataSource = null;
            this.spinControl1.EditLabel = "顺序号:";
            this.spinControl1.Location = new System.Drawing.Point(12, 93);
            this.spinControl1.Name = "spinControl1";
            this.spinControl1.Size = new System.Drawing.Size(155, 21);
            this.spinControl1.TabIndex = 4;
            // 
            // dateControl1
            // 
            this.dateControl1.BackColor = System.Drawing.Color.Transparent;
            this.dateControl1.DataField = "F_Date";
            this.dateControl1.DataSource = null;
            this.dateControl1.DisplayFormat = "d";
            this.dateControl1.EditLabel = "日期:";
            this.dateControl1.EditMask = "d";
            this.dateControl1.Location = new System.Drawing.Point(251, 93);
            this.dateControl1.Name = "dateControl1";
            this.dateControl1.Request = false;
            this.dateControl1.Size = new System.Drawing.Size(161, 21);
            this.dateControl1.TabIndex = 5;
            // 
            // cbControl1
            // 
            this.cbControl1.BackColor = System.Drawing.Color.Transparent;
            comboBoxItem11.Value = "转";
            comboBoxItem12.Value = "现收";
            comboBoxItem13.Value = "现付";
            comboBoxItem14.Value = "银收";
            comboBoxItem15.Value = "银付";
            this.cbControl1.cbItem = new DevExpress.XtraEditors.Controls.ComboBoxItem[] {
        comboBoxItem11,
        comboBoxItem12,
        comboBoxItem13,
        comboBoxItem14,
        comboBoxItem15};
            this.cbControl1.DataField = "F_Key";
            this.cbControl1.DataSource = null;
            this.cbControl1.EditLabel = "凭证字:";
            this.cbControl1.EditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbControl1.Location = new System.Drawing.Point(513, 39);
            this.cbControl1.Name = "cbControl1";
            this.cbControl1.Request = false;
            this.cbControl1.SelectedIndex = -1;
            this.cbControl1.Size = new System.Drawing.Size(150, 21);
            this.cbControl1.TabIndex = 6;
            // 
            // spinControl2
            // 
            this.spinControl2.BackColor = System.Drawing.Color.Transparent;
            this.spinControl2.DataField = "F_Annex";
            this.spinControl2.DataSource = null;
            this.spinControl2.EditLabel = "凭证号:";
            this.spinControl2.Location = new System.Drawing.Point(513, 66);
            this.spinControl2.Name = "spinControl2";
            this.spinControl2.Size = new System.Drawing.Size(150, 21);
            this.spinControl2.TabIndex = 7;
            // 
            // spinControl3
            // 
            this.spinControl3.BackColor = System.Drawing.Color.Transparent;
            this.spinControl3.DataField = null;
            this.spinControl3.DataSource = null;
            this.spinControl3.EditLabel = "附单据:";
            this.spinControl3.Location = new System.Drawing.Point(513, 93);
            this.spinControl3.Name = "spinControl3";
            this.spinControl3.Size = new System.Drawing.Size(126, 21);
            this.spinControl3.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(643, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "张";
            // 
            // editControl1
            // 
            this.editControl1.BackColor = System.Drawing.Color.Transparent;
            this.editControl1.DataField = "F_BillMan";
            this.editControl1.DataSource = null;
            this.editControl1.EditLabel = "制单:";
            this.editControl1.Enabled = false;
            this.editControl1.Location = new System.Drawing.Point(12, 433);
            this.editControl1.Name = "editControl1";
            this.editControl1.Request = false;
            this.editControl1.Size = new System.Drawing.Size(155, 21);
            this.editControl1.TabIndex = 10;
            // 
            // editControl2
            // 
            this.editControl2.BackColor = System.Drawing.Color.Transparent;
            this.editControl2.DataField = "F_Checker";
            this.editControl2.DataSource = null;
            this.editControl2.EditLabel = "审核:";
            this.editControl2.Enabled = false;
            this.editControl2.Location = new System.Drawing.Point(282, 433);
            this.editControl2.Name = "editControl2";
            this.editControl2.Request = false;
            this.editControl2.Size = new System.Drawing.Size(155, 21);
            this.editControl2.TabIndex = 11;
            // 
            // editControl3
            // 
            this.editControl3.BackColor = System.Drawing.Color.Transparent;
            this.editControl3.DataField = "F_ReChecker";
            this.editControl3.DataSource = null;
            this.editControl3.EditLabel = "登帐:";
            this.editControl3.Enabled = false;
            this.editControl3.Location = new System.Drawing.Point(524, 433);
            this.editControl3.Name = "editControl3";
            this.editControl3.Request = false;
            this.editControl3.Size = new System.Drawing.Size(155, 21);
            this.editControl3.TabIndex = 12;
            // 
            // frmCertificate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(691, 466);
            this.Controls.Add(this.editControl3);
            this.Controls.Add(this.editControl2);
            this.Controls.Add(this.editControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.spinControl3);
            this.Controls.Add(this.spinControl2);
            this.Controls.Add(this.cbControl1);
            this.Controls.Add(this.dateControl1);
            this.Controls.Add(this.spinControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCertificate";
            this.Text = "记帐凭证";
            this.Load += new System.EventHandler(this.frmCertificate_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binSlaver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binMaster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsSave;
        private System.Windows.Forms.ToolStripButton tsPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsCheck;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsInsert;
        private System.Windows.Forms.ToolStripButton tsDel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsCal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private myControl.SpinControl spinControl1;
        private myControl.DateControl dateControl1;
        private myControl.cbControl cbControl1;
        private myControl.SpinControl spinControl2;
        private myControl.SpinControl spinControl3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.GridControl gcMain;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMain;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private System.Windows.Forms.BindingSource binSlaver;
        private System.Windows.Forms.BindingSource binMaster;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit2;
        private myControl.EditControl editControl1;
        private myControl.EditControl editControl2;
        private myControl.EditControl editControl3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsUnCheck;
        private System.Windows.Forms.ToolStripButton btNew;
    }
}
