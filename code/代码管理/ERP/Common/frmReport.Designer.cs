namespace Common
{
    partial class frmReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReport));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnPreview = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnExport = new DevExpress.XtraBars.BarButtonItem();
            this.btnFilter = new DevExpress.XtraBars.BarButtonItem();
            this.btnDel = new DevExpress.XtraBars.BarButtonItem();
            this.btnGraphi = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.ucDate = new myControl.ucDate();
            this.gcReport = new DevExpress.XtraGrid.GridControl();
            this.gvReport = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.printingSystem = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            this.lbTitle = new System.Windows.Forms.Label();
            this.rgOption = new DevExpress.XtraEditors.RadioGroup();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgOption.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnPreview,
            this.btnPrint,
            this.btnExport,
            this.btnClose,
            this.btnFilter,
            this.btnDel,
            this.barStaticItem1,
            this.barStaticItem2,
            this.btnGraphi});
            this.barManager.MaxItemId = 9;
            this.barManager.StatusBar = this.bar2;
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 1";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPreview),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExport),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFilter, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDel),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGraphi, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClose, true)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Custom 1";
            // 
            // btnPreview
            // 
            this.btnPreview.Caption = "预览";
            this.btnPreview.Glyph = ((System.Drawing.Image)(resources.GetObject("btnPreview.Glyph")));
            this.btnPreview.Id = 0;
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnPreview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPreview_ItemClick);
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "打印";
            this.btnPrint.Glyph = ((System.Drawing.Image)(resources.GetObject("btnPrint.Glyph")));
            this.btnPrint.Id = 1;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrint_ItemClick);
            // 
            // btnExport
            // 
            this.btnExport.Caption = "引出";
            this.btnExport.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExport.Glyph")));
            this.btnExport.Id = 2;
            this.btnExport.Name = "btnExport";
            this.btnExport.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExport_ItemClick);
            // 
            // btnFilter
            // 
            this.btnFilter.Caption = "过滤";
            this.btnFilter.Glyph = ((System.Drawing.Image)(resources.GetObject("btnFilter.Glyph")));
            this.btnFilter.Id = 4;
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnFilter.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnFilter.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFilter_ItemClick);
            // 
            // btnDel
            // 
            this.btnDel.Caption = "删除";
            this.btnDel.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDel.Glyph")));
            this.btnDel.Id = 5;
            this.btnDel.Name = "btnDel";
            this.btnDel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnDel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDel_ItemClick);
            // 
            // btnGraphi
            // 
            this.btnGraphi.Caption = "图表";
            this.btnGraphi.Glyph = global::Common.Properties.Resources.btnUnCutOff_Glyph;
            this.btnGraphi.Id = 8;
            this.btnGraphi.Name = "btnGraphi";
            this.btnGraphi.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnGraphi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnGraphi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGraphi_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "关闭";
            this.btnClose.Glyph = ((System.Drawing.Image)(resources.GetObject("btnClose.Glyph")));
            this.btnClose.Id = 3;
            this.btnClose.Name = "btnClose";
            this.btnClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // bar2
            // 
            this.bar2.BarName = "Custom 2";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem2)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Custom 2";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "就绪！";
            this.barStaticItem1.Id = 6;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.Caption = "F7:格式设置；F5:保存格式";
            this.barStaticItem2.Id = 7;
            this.barStaticItem2.Name = "barStaticItem2";
            this.barStaticItem2.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // ucDate
            // 
            this.ucDate.BackColor = System.Drawing.Color.Transparent;
            this.ucDate.DateTag = myControl.DateFlag.当天;
            this.ucDate.Location = new System.Drawing.Point(222, 10);
            this.ucDate.Name = "ucDate";
            this.ucDate.Size = new System.Drawing.Size(397, 28);
            this.ucDate.TabIndex = 9;
            this.ucDate.RefreshDateChanged += new myControl.RefreshDateEventHandler(this.ucDate_RefreshDateChanged);
            // 
            // gcReport
            // 
            this.gcReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcReport.EmbeddedNavigator.Name = "";
            this.gcReport.Location = new System.Drawing.Point(0, 71);
            this.gcReport.MainView = this.gvReport;
            this.gcReport.Name = "gcReport";
            this.gcReport.Size = new System.Drawing.Size(748, 408);
            this.gcReport.TabIndex = 10;
            this.gcReport.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvReport});
            // 
            // gvReport
            // 
            this.gvReport.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvReport.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvReport.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gvReport.GridControl = this.gcReport;
            this.gvReport.Name = "gvReport";
            this.gvReport.OptionsBehavior.Editable = false;
            this.gvReport.OptionsLayout.Columns.StoreAllOptions = true;
            this.gvReport.OptionsLayout.Columns.StoreAppearance = true;
            this.gvReport.OptionsLayout.StoreDataSettings = false;
            this.gvReport.OptionsLayout.StoreVisualOptions = false;
            this.gvReport.OptionsPrint.AutoWidth = false;
            this.gvReport.OptionsView.ColumnAutoWidth = false;
            this.gvReport.OptionsView.ShowAutoFilterRow = true;
            this.gvReport.OptionsView.ShowFooter = true;
            this.gvReport.OptionsView.ShowIndicator = false;
            this.gvReport.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvReport_FocusedRowChanged);
            this.gvReport.DoubleClick += new System.EventHandler(this.gvReport_DoubleClick);
            // 
            // printingSystem
            // 
            this.printingSystem.ContinuousPageNumbering = true;
            this.printingSystem.Links.AddRange(new object[] {
            this.printableComponentLink1});
            // 
            // printableComponentLink1
            // 
            this.printableComponentLink1.Component = this.gcReport;
            this.printableComponentLink1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("printableComponentLink1.ImageStream")));
            this.printableComponentLink1.PageHeaderFooter = new DevExpress.XtraPrinting.PageHeaderFooter(new DevExpress.XtraPrinting.PageHeaderArea(new string[0], new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134))), DevExpress.XtraPrinting.BrickAlignment.Near), null);
            this.printableComponentLink1.PrintingSystem = this.printingSystem;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.Location = new System.Drawing.Point(12, 10);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(88, 24);
            this.lbTitle.TabIndex = 11;
            this.lbTitle.Text = "label1";
            // 
            // rgOption
            // 
            this.rgOption.EditValue = true;
            this.rgOption.Location = new System.Drawing.Point(625, 10);
            this.rgOption.Name = "rgOption";
            this.rgOption.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgOption.Properties.Appearance.Options.UseBackColor = true;
            this.rgOption.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgOption.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "汇总"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "明细")});
            this.rgOption.Size = new System.Drawing.Size(111, 29);
            this.rgOption.TabIndex = 12;
            this.rgOption.SelectedIndexChanged += new System.EventHandler(this.rgOption_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Common.Properties.Resources.pcTitle_Image;
            this.panel1.Controls.Add(this.ucDate);
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Controls.Add(this.rgOption);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 45);
            this.panel1.TabIndex = 13;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(748, 501);
            this.Controls.Add(this.gcReport);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmReport";
            this.Load += new System.EventHandler(this.frmReport_Load);
            this.Shown += new System.EventHandler(this.frmReport_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReport_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgOption.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnPreview;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
        private DevExpress.XtraBars.BarButtonItem btnExport;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;
        protected internal DevExpress.XtraEditors.RadioGroup rgOption;
        protected internal System.Windows.Forms.Label lbTitle;
        protected internal DevExpress.XtraGrid.GridControl gcReport;
        protected internal DevExpress.XtraGrid.Views.Grid.GridView gvReport;
        protected DevExpress.XtraBars.BarButtonItem btnFilter;
        protected DevExpress.XtraBars.BarButtonItem btnDel;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        protected myControl.ucDate ucDate;
        protected DevExpress.XtraBars.BarButtonItem btnGraphi;
        public DevExpress.XtraPrinting.PrintingSystem printingSystem;
        public System.Windows.Forms.Panel panel1;
    }
}
