namespace Card
{
    partial class frmDinnerReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDinnerReport));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tvDept = new System.Windows.Forms.TreeView();
            this.gridQuery = new DevExpress.XtraGrid.GridControl();
            this.viewQuery = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucDate1 = new myControl.ucDate();
            this.printingSystem = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.printableComponentLink2 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            this.toolStrip.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewQuery)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton5,
            this.toolStripSeparator2,
            this.toolStripButton7,
            this.toolStripSeparator3,
            this.toolStripButton9});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(686, 35);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Image = global::Card.Properties.Resources.btnPrint_Glyph;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(33, 32);
            this.toolStripButton5.Text = "打印";
            this.toolStripButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.Image = global::Card.Properties.Resources.btnExport_Glyph;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(33, 32);
            this.toolStripButton7.Text = "导出";
            this.toolStripButton7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 35);
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.Image = global::Card.Properties.Resources.btnClose_Glyph;
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(33, 32);
            this.toolStripButton9.Text = "关闭";
            this.toolStripButton9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 35);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridQuery);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(686, 458);
            this.splitContainer1.SplitterDistance = 191;
            this.splitContainer1.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(191, 458);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tvDept);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(183, 433);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "部门";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tvDept
            // 
            this.tvDept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDept.HideSelection = false;
            this.tvDept.Location = new System.Drawing.Point(3, 3);
            this.tvDept.Name = "tvDept";
            this.tvDept.Size = new System.Drawing.Size(177, 427);
            this.tvDept.TabIndex = 0;
            this.tvDept.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDept_AfterSelect);
            // 
            // gridQuery
            // 
            this.gridQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridQuery.EmbeddedNavigator.Name = "";
            this.gridQuery.Location = new System.Drawing.Point(0, 69);
            this.gridQuery.MainView = this.viewQuery;
            this.gridQuery.Name = "gridQuery";
            this.gridQuery.Size = new System.Drawing.Size(491, 389);
            this.gridQuery.TabIndex = 1;
            this.gridQuery.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewQuery});
            // 
            // viewQuery
            // 
            this.viewQuery.GridControl = this.gridQuery;
            this.viewQuery.Name = "viewQuery";
            this.viewQuery.OptionsBehavior.Editable = false;
            this.viewQuery.OptionsLayout.Columns.StoreAllOptions = true;
            this.viewQuery.OptionsLayout.Columns.StoreAppearance = true;
            this.viewQuery.OptionsLayout.StoreDataSettings = false;
            this.viewQuery.OptionsLayout.StoreVisualOptions = false;
            this.viewQuery.OptionsPrint.AutoWidth = false;
            this.viewQuery.OptionsView.ColumnAutoWidth = false;
            this.viewQuery.OptionsView.ShowAutoFilterRow = true;
            this.viewQuery.OptionsView.ShowFooter = true;
            this.viewQuery.OptionsView.ShowGroupPanel = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ucDate1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 69);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // ucDate1
            // 
            this.ucDate1.DateTag = myControl.DateFlag.当天;
            this.ucDate1.Location = new System.Drawing.Point(7, 24);
            this.ucDate1.Name = "ucDate1";
            this.ucDate1.Size = new System.Drawing.Size(397, 26);
            this.ucDate1.TabIndex = 0;
            this.ucDate1.RefreshDateChanged += new myControl.RefreshDateEventHandler(this.ucDate1_RefreshDateChanged);
            // 
            // printingSystem
            // 
            this.printingSystem.ContinuousPageNumbering = true;
            this.printingSystem.Links.AddRange(new object[] {
            this.printableComponentLink2});
            // 
            // printableComponentLink2
            // 
            this.printableComponentLink2.Component = this.gridQuery;
            this.printableComponentLink2.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("printableComponentLink2.ImageStream")));
            this.printableComponentLink2.PrintingSystem = this.printingSystem;
            // 
            // printableComponentLink1
            // 
            this.printableComponentLink1.Component = this.gridQuery;
            this.printableComponentLink1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("printableComponentLink1.ImageStream")));
            this.printableComponentLink1.PrintingSystem = this.printingSystem;
            // 
            // frmDinnerReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(686, 493);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip);
            this.Name = "frmDinnerReport";
            this.Text = "员工售饭报表";
            this.Shown += new System.EventHandler(this.frmKQReport_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmKQReport_KeyDown);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewQuery)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.GroupBox groupBox1;
        public myControl.ucDate ucDate1;
        public System.Windows.Forms.TreeView tvDept;
        public DevExpress.XtraGrid.GridControl gridQuery;
        public DevExpress.XtraGrid.Views.Grid.GridView viewQuery;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem;
        private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;
        private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink2;
    }
}
