namespace Card
{
    partial class frmRegDevice
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("考勤机");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("考勤门禁机");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("门禁机");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("消费机");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("补贴机");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("发卡机");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("所有卡钟类型", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegDevice));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvType = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.gcBase = new DevExpress.XtraGrid.GridControl();
            this.gvBase = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.printingSystem = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            this.toolStrip.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripSeparator1,
            this.toolStripButton5,
            this.toolStripSeparator2,
            this.toolStripButton7,
            this.toolStripSeparator3,
            this.toolStripButton9});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(694, 35);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::Card.Properties.Resources.btnNew_Glyph;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(33, 32);
            this.toolStripButton1.Text = "增加";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::Card.Properties.Resources.btnEdit_Glyph;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(33, 32);
            this.toolStripButton2.Text = "修改";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::Card.Properties.Resources.btnDel_Glyph;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(33, 32);
            this.toolStripButton3.Text = "删除";
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
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
            this.splitContainer1.Location = new System.Drawing.Point(0, 35);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvType);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gcBase);
            this.splitContainer1.Size = new System.Drawing.Size(694, 431);
            this.splitContainer1.SplitterDistance = 230;
            this.splitContainer1.TabIndex = 1;
            // 
            // tvType
            // 
            this.tvType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvType.HideSelection = false;
            this.tvType.Location = new System.Drawing.Point(0, 21);
            this.tvType.Name = "tvType";
            treeNode1.Name = "节点1";
            treeNode1.Text = "考勤机";
            treeNode2.Name = "节点2";
            treeNode2.Text = "考勤门禁机";
            treeNode3.Name = "节点3";
            treeNode3.Text = "门禁机";
            treeNode4.Name = "节点4";
            treeNode4.Text = "消费机";
            treeNode5.Name = "节点5";
            treeNode5.Text = "补贴机";
            treeNode6.Name = "节点6";
            treeNode6.Text = "发卡机";
            treeNode7.Name = "节点0";
            treeNode7.Text = "所有卡钟类型";
            this.tvType.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7});
            this.tvType.Size = new System.Drawing.Size(230, 410);
            this.tvType.TabIndex = 1;
            this.tvType.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvType_AfterSelect);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 21);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "机器用途结构图";
            // 
            // gcBase
            // 
            this.gcBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcBase.EmbeddedNavigator.Name = "";
            this.gcBase.Location = new System.Drawing.Point(0, 0);
            this.gcBase.MainView = this.gvBase;
            this.gcBase.Name = "gcBase";
            this.gcBase.Size = new System.Drawing.Size(460, 431);
            this.gcBase.TabIndex = 0;
            this.gcBase.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBase});
            // 
            // gvBase
            // 
            this.gvBase.GridControl = this.gcBase;
            this.gvBase.Name = "gvBase";
            this.gvBase.OptionsBehavior.Editable = false;
            this.gvBase.OptionsLayout.Columns.StoreAllOptions = true;
            this.gvBase.OptionsLayout.Columns.StoreAppearance = true;
            this.gvBase.OptionsLayout.StoreDataSettings = false;
            this.gvBase.OptionsLayout.StoreVisualOptions = false;
            this.gvBase.OptionsView.ColumnAutoWidth = false;
            this.gvBase.OptionsView.ShowAutoFilterRow = true;
            this.gvBase.OptionsView.ShowGroupPanel = false;
            this.gvBase.DoubleClick += new System.EventHandler(this.gvBase_DoubleClick);
            // 
            // printingSystem
            // 
            this.printingSystem.ContinuousPageNumbering = true;
            this.printingSystem.Links.AddRange(new object[] {
            this.printableComponentLink1});
            // 
            // printableComponentLink1
            // 
            this.printableComponentLink1.Component = this.gcBase;
            this.printableComponentLink1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("printableComponentLink1.ImageStream")));
            this.printableComponentLink1.PrintingSystem = this.printingSystem;
            // 
            // frmRegDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 466);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip);
            this.Name = "frmRegDevice";
            this.Text = "设备登记";
            this.Shown += new System.EventHandler(this.frmRegDevice_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRegDevice_KeyDown);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView tvType;
        private DevExpress.XtraGrid.GridControl gcBase;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBase;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem;
        private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;
    }
}