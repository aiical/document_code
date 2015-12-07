namespace Common
{
    partial class frmBomStoreQty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBomStoreQty));
            this.gridStore = new DevExpress.XtraGrid.GridControl();
            this.viewStore = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.edtItemID = new myControl.EditControl();
            this.edtItemName = new myControl.EditControl();
            this.edtSpec = new myControl.EditControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.btnPreview = new System.Windows.Forms.ToolStripButton();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.printingSystem = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).BeginInit();
            this.SuspendLayout();
            // 
            // gridStore
            // 
            this.gridStore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridStore.EmbeddedNavigator.Name = "";
            this.gridStore.Location = new System.Drawing.Point(12, 75);
            this.gridStore.MainView = this.viewStore;
            this.gridStore.Name = "gridStore";
            this.gridStore.Size = new System.Drawing.Size(737, 425);
            this.gridStore.TabIndex = 0;
            this.gridStore.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewStore,
            this.gridView2});
            // 
            // viewStore
            // 
            this.viewStore.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.viewStore.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.viewStore.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.viewStore.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8});
            this.viewStore.GridControl = this.gridStore;
            this.viewStore.Name = "viewStore";
            this.viewStore.OptionsBehavior.Editable = false;
            this.viewStore.OptionsView.ColumnAutoWidth = false;
            this.viewStore.OptionsView.ShowFooter = true;
            this.viewStore.OptionsView.ShowGroupPanel = false;
            this.viewStore.OptionsView.ShowIndicator = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "仓库";
            this.gridColumn1.FieldName = "F_StorageName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "批号";
            this.gridColumn2.FieldName = "F_BatchNo";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "物料编码";
            this.gridColumn3.FieldName = "F_ItemID";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "物料名称";
            this.gridColumn4.FieldName = "F_ItemName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 166;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "单位";
            this.gridColumn5.FieldName = "F_Unit";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 52;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "库存";
            this.gridColumn6.FieldName = "F_Qty";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 61;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "规格";
            this.gridColumn7.FieldName = "F_Spec";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            this.gridColumn7.Width = 127;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridStore;
            this.gridView2.Name = "gridView2";
            // 
            // edtItemID
            // 
            this.edtItemID.BackColor = System.Drawing.Color.Transparent;
            this.edtItemID.DataField = null;
            this.edtItemID.DataSource = null;
            this.edtItemID.EditLabel = "产品编码:";
            this.edtItemID.Enabled = false;
            this.edtItemID.Location = new System.Drawing.Point(12, 48);
            this.edtItemID.Name = "edtItemID";
            this.edtItemID.Request = false;
            this.edtItemID.Size = new System.Drawing.Size(174, 21);
            this.edtItemID.TabIndex = 1;
            // 
            // edtItemName
            // 
            this.edtItemName.BackColor = System.Drawing.Color.Transparent;
            this.edtItemName.DataField = null;
            this.edtItemName.DataSource = null;
            this.edtItemName.EditLabel = "产品名称:";
            this.edtItemName.Enabled = false;
            this.edtItemName.Location = new System.Drawing.Point(214, 48);
            this.edtItemName.Name = "edtItemName";
            this.edtItemName.Request = false;
            this.edtItemName.Size = new System.Drawing.Size(237, 21);
            this.edtItemName.TabIndex = 2;
            // 
            // edtSpec
            // 
            this.edtSpec.BackColor = System.Drawing.Color.Transparent;
            this.edtSpec.DataField = null;
            this.edtSpec.DataSource = null;
            this.edtSpec.EditLabel = "规格:";
            this.edtSpec.Enabled = false;
            this.edtSpec.Location = new System.Drawing.Point(469, 48);
            this.edtSpec.Name = "edtSpec";
            this.edtSpec.Request = false;
            this.edtSpec.Size = new System.Drawing.Size(217, 21);
            this.edtSpec.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrint,
            this.btnPreview,
            this.btnExport,
            this.toolStripSeparator1,
            this.btnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(757, 35);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::Common.Properties.Resources.btnPrint_Glyph;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(33, 32);
            this.btnPrint.Text = "打印";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Image = global::Common.Properties.Resources.btnPreview_Glyph;
            this.btnPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(33, 32);
            this.btnPreview.Text = "预览";
            this.btnPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnExport
            // 
            this.btnExport.Image = global::Common.Properties.Resources.btnExport_Glyph;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(33, 32);
            this.btnExport.Text = "引出";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::Common.Properties.Resources.btnClose_Glyph;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(33, 32);
            this.btnClose.Text = "关闭";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // printingSystem
            // 
            this.printingSystem.Links.AddRange(new object[] {
            this.printableComponentLink1});
            // 
            // printableComponentLink1
            // 
            this.printableComponentLink1.Component = this.gridStore;
            //this.printableComponentLink1.CustomPaperSize = new System.Drawing.Size(0, 0);
            this.printableComponentLink1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("printableComponentLink1.ImageStream")));
            this.printableComponentLink1.PageHeaderFooter = new DevExpress.XtraPrinting.PageHeaderFooter(new DevExpress.XtraPrinting.PageHeaderArea(new string[0], new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134))), DevExpress.XtraPrinting.BrickAlignment.Near), null);
            this.printableComponentLink1.PrintingSystem = this.printingSystem;
            //this.printableComponentLink1.VerticalContentSplitting = DevExpress.XtraPrinting.VerticalContentSplitting.Smart;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "成本价";
            this.gridColumn8.FieldName = "F_Price";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            // 
            // frmBomStoreQty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(757, 512);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.edtSpec);
            this.Controls.Add(this.edtItemName);
            this.Controls.Add(this.edtItemID);
            this.Controls.Add(this.gridStore);
            this.Name = "frmBomStoreQty";
            this.Text = "产品Bom单库存情况";
            ((System.ComponentModel.ISupportInitialize)(this.gridStore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewStore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridStore;
        private DevExpress.XtraGrid.Views.Grid.GridView viewStore;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private myControl.EditControl edtItemID;
        private myControl.EditControl edtItemName;
        private myControl.EditControl edtSpec;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripButton btnPreview;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem;
        private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
    }
}
