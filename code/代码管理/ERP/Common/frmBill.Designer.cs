namespace Common
{
    partial class frmBill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBill));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.picInvalid = new System.Windows.Forms.PictureBox();
            this.picFinish = new System.Windows.Forms.PictureBox();
            this.picCutOff = new System.Windows.Forms.PictureBox();
            this.picCheck = new System.Windows.Forms.PictureBox();
            this.dateControl1 = new myControl.DateControl();
            this.editControl1 = new myControl.EditControl();
            this.lbTitle = new System.Windows.Forms.Label();
            this.binMaster = new System.Windows.Forms.BindingSource(this.components);
            this.gcBill = new DevExpress.XtraGrid.GridControl();
            this.binSlaver = new System.Windows.Forms.BindingSource(this.components);
            this.gvList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnCopy = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddRow = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelRow = new DevExpress.XtraBars.BarButtonItem();
            this.btnCheck = new DevExpress.XtraBars.BarButtonItem();
            this.btnUnCheck = new DevExpress.XtraBars.BarButtonItem();
            this.btnCutOff = new DevExpress.XtraBars.BarButtonItem();
            this.btnUnCutOff = new DevExpress.XtraBars.BarButtonItem();
            this.btnOther = new DevExpress.XtraBars.BarSubItem();
            this.barInvalid = new DevExpress.XtraBars.BarButtonItem();
            this.barUnValid = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarSubItem();
            this.biPreview = new DevExpress.XtraBars.BarButtonItem();
            this.biPrint = new DevExpress.XtraBars.BarButtonItem();
            this.biDesign = new DevExpress.XtraBars.BarButtonItem();
            this.btnLoadBill = new DevExpress.XtraBars.BarButtonItem();
            this.btnBalance = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barStatus = new DevExpress.XtraBars.BarStaticItem();
            this.barMemo = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.editControl4 = new myControl.EditControl();
            this.editControl3 = new myControl.EditControl();
            this.editControl2 = new myControl.EditControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInvalid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFinish)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCutOff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binSlaver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.OldLace;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.picInvalid);
            this.panelControl1.Controls.Add(this.picFinish);
            this.panelControl1.Controls.Add(this.picCutOff);
            this.panelControl1.Controls.Add(this.picCheck);
            this.panelControl1.Controls.Add(this.dateControl1);
            this.panelControl1.Controls.Add(this.editControl1);
            this.panelControl1.Controls.Add(this.lbTitle);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 26);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(823, 111);
            this.panelControl1.TabIndex = 0;
            // 
            // picInvalid
            // 
            this.picInvalid.Image = ((System.Drawing.Image)(resources.GetObject("picInvalid.Image")));
            this.picInvalid.Location = new System.Drawing.Point(366, 8);
            this.picInvalid.Name = "picInvalid";
            this.picInvalid.Size = new System.Drawing.Size(71, 28);
            this.picInvalid.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picInvalid.TabIndex = 6;
            this.picInvalid.TabStop = false;
            this.picInvalid.Visible = false;
            // 
            // picFinish
            // 
            this.picFinish.Image = ((System.Drawing.Image)(resources.GetObject("picFinish.Image")));
            this.picFinish.Location = new System.Drawing.Point(289, 8);
            this.picFinish.Name = "picFinish";
            this.picFinish.Size = new System.Drawing.Size(71, 28);
            this.picFinish.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picFinish.TabIndex = 5;
            this.picFinish.TabStop = false;
            this.picFinish.Visible = false;
            // 
            // picCutOff
            // 
            this.picCutOff.Image = ((System.Drawing.Image)(resources.GetObject("picCutOff.Image")));
            this.picCutOff.Location = new System.Drawing.Point(204, 8);
            this.picCutOff.Name = "picCutOff";
            this.picCutOff.Size = new System.Drawing.Size(71, 28);
            this.picCutOff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picCutOff.TabIndex = 4;
            this.picCutOff.TabStop = false;
            this.picCutOff.Visible = false;
            // 
            // picCheck
            // 
            this.picCheck.Image = ((System.Drawing.Image)(resources.GetObject("picCheck.Image")));
            this.picCheck.Location = new System.Drawing.Point(120, 8);
            this.picCheck.Name = "picCheck";
            this.picCheck.Size = new System.Drawing.Size(71, 28);
            this.picCheck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picCheck.TabIndex = 3;
            this.picCheck.TabStop = false;
            this.picCheck.Visible = false;
            // 
            // dateControl1
            // 
            this.dateControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateControl1.BackColor = System.Drawing.Color.Transparent;
            this.dateControl1.DataField = "F_Date";
            this.dateControl1.DataSource = null;
            this.dateControl1.DisplayFormat = "d";
            this.dateControl1.EditLabel = "日期:";
            this.dateControl1.EditMask = "d";
            this.dateControl1.Location = new System.Drawing.Point(639, 35);
            this.dateControl1.Name = "dateControl1";
            this.dateControl1.Request = true;
            this.dateControl1.Size = new System.Drawing.Size(177, 21);
            this.dateControl1.TabIndex = 2;
            // 
            // editControl1
            // 
            this.editControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editControl1.BackColor = System.Drawing.Color.Transparent;
            this.editControl1.DataField = "F_BillID";
            this.editControl1.DataSource = null;
            this.editControl1.EditLabel = "单号:";
            this.editControl1.Location = new System.Drawing.Point(641, 6);
            this.editControl1.Name = "editControl1";
            this.editControl1.Request = true;
            this.editControl1.Size = new System.Drawing.Size(175, 23);
            this.editControl1.TabIndex = 1;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.Location = new System.Drawing.Point(7, 8);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(82, 21);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "label1";
            // 
            // binMaster
            // 
            this.binMaster.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.binMaster_AddingNew);
            this.binMaster.PositionChanged += new System.EventHandler(this.binMaster_PositionChanged);
            // 
            // gcBill
            // 
            this.gcBill.DataSource = this.binSlaver;
            this.gcBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcBill.EmbeddedNavigator.Name = "";
            this.gcBill.Location = new System.Drawing.Point(0, 137);
            this.gcBill.MainView = this.gvList;
            this.gcBill.Name = "gcBill";
            this.gcBill.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.gcBill.Size = new System.Drawing.Size(823, 350);
            this.gcBill.TabIndex = 1;
            this.gcBill.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvList});
            this.gcBill.DoubleClick += new System.EventHandler(this.gcBill_DoubleClick);
            // 
            // gvList
            // 
            this.gvList.GridControl = this.gcBill;
            this.gvList.Name = "gvList";
            this.gvList.OptionsCustomization.AllowFilter = false;
            this.gvList.OptionsLayout.Columns.StoreAllOptions = true;
            this.gvList.OptionsLayout.Columns.StoreAppearance = true;
            this.gvList.OptionsLayout.StoreDataSettings = false;
            this.gvList.OptionsLayout.StoreVisualOptions = false;
            this.gvList.OptionsNavigation.AutoFocusNewRow = true;
            this.gvList.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvList.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gvList.OptionsView.ColumnAutoWidth = false;
            this.gvList.OptionsView.ShowAutoFilterRow = true;
            this.gvList.OptionsView.ShowFooter = true;
            this.gvList.OptionsView.ShowGroupPanel = false;
            this.gvList.OptionsView.ShowIndicator = false;
            this.gvList.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvList_FocusedRowChanged);
            this.gvList.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvList_CellValueChanged);
            this.gvList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvList_KeyDown);
            this.gvList.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvList_CellValueChanging);
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // barManager
            // 
            this.barManager.AllowCustomization = false;
            this.barManager.AllowQuickCustomization = false;
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnNew,
            this.btnSave,
            this.btnCopy,
            this.btnAddRow,
            this.btnDelRow,
            this.btnCheck,
            this.btnClose,
            this.btnCutOff,
            this.btnPrint,
            this.biPreview,
            this.biPrint,
            this.biDesign,
            this.btnUnCheck,
            this.btnUnCutOff,
            this.btnLoadBill,
            this.barStatus,
            this.barMemo,
            this.btnBalance,
            this.btnOther,
            this.barInvalid,
            this.barUnValid});
            this.barManager.MaxItemId = 28;
            this.barManager.StatusBar = this.bar2;
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 1";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNew),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCopy),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAddRow, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelRow),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCheck, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnUnCheck),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCutOff, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnUnCutOff),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnOther),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPrint, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLoadBill, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnBalance, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClose, true)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DisableClose = true;
            this.bar1.OptionsBar.DisableCustomization = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "工具栏";
            // 
            // btnNew
            // 
            this.btnNew.Caption = "新增";
            this.btnNew.Glyph = ((System.Drawing.Image)(resources.GetObject("btnNew.Glyph")));
            this.btnNew.Id = 0;
            this.btnNew.Name = "btnNew";
            this.btnNew.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "保存";
            this.btnSave.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSave.Glyph")));
            this.btnSave.Id = 1;
            this.btnSave.Name = "btnSave";
            this.btnSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnCopy
            // 
            this.btnCopy.Caption = "复制";
            this.btnCopy.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCopy.Glyph")));
            this.btnCopy.Id = 2;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnCopy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCopy_ItemClick);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Caption = "增行";
            this.btnAddRow.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAddRow.Glyph")));
            this.btnAddRow.Id = 3;
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnAddRow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddRow_ItemClick);
            // 
            // btnDelRow
            // 
            this.btnDelRow.Caption = "删行";
            this.btnDelRow.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDelRow.Glyph")));
            this.btnDelRow.Id = 4;
            this.btnDelRow.Name = "btnDelRow";
            this.btnDelRow.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnDelRow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelRow_ItemClick);
            // 
            // btnCheck
            // 
            this.btnCheck.Caption = "审核";
            this.btnCheck.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCheck.Glyph")));
            this.btnCheck.Id = 5;
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnCheck.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCheck_ItemClick);
            // 
            // btnUnCheck
            // 
            this.btnUnCheck.Caption = "反审";
            this.btnUnCheck.Glyph = ((System.Drawing.Image)(resources.GetObject("btnUnCheck.Glyph")));
            this.btnUnCheck.Id = 13;
            this.btnUnCheck.Name = "btnUnCheck";
            this.btnUnCheck.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnUnCheck.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUnCheck_ItemClick);
            // 
            // btnCutOff
            // 
            this.btnCutOff.Caption = "中止";
            this.btnCutOff.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCutOff.Glyph")));
            this.btnCutOff.Id = 8;
            this.btnCutOff.Name = "btnCutOff";
            this.btnCutOff.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnCutOff.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnCutOff.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCutOff_ItemClick);
            // 
            // btnUnCutOff
            // 
            this.btnUnCutOff.Caption = "反中止";
            this.btnUnCutOff.Glyph = ((System.Drawing.Image)(resources.GetObject("btnUnCutOff.Glyph")));
            this.btnUnCutOff.Id = 14;
            this.btnUnCutOff.Name = "btnUnCutOff";
            this.btnUnCutOff.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnUnCutOff.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnUnCutOff.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUnCutOff_ItemClick);
            // 
            // btnOther
            // 
            this.btnOther.Caption = "其它";
            this.btnOther.Glyph = global::Common.Properties.Resources.btnUnCutOff_Glyph;
            this.btnOther.Id = 23;
            this.btnOther.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barInvalid, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barUnValid)});
            this.btnOther.Name = "btnOther";
            this.btnOther.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barInvalid
            // 
            this.barInvalid.Caption = "作废";
            this.barInvalid.Id = 26;
            this.barInvalid.Name = "barInvalid";
            this.barInvalid.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barInvalid_ItemClick);
            // 
            // barUnValid
            // 
            this.barUnValid.Caption = "反作废";
            this.barUnValid.Id = 27;
            this.barUnValid.Name = "barUnValid";
            this.barUnValid.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barUnValid_ItemClick);
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "打印";
            this.btnPrint.Glyph = ((System.Drawing.Image)(resources.GetObject("btnPrint.Glyph")));
            this.btnPrint.Id = 9;
            this.btnPrint.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biPreview),
            new DevExpress.XtraBars.LinkPersistInfo(this.biPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.biDesign)});
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // biPreview
            // 
            this.biPreview.Caption = "打印预览";
            this.biPreview.Id = 10;
            this.biPreview.Name = "biPreview";
            this.biPreview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biPreview_ItemClick);
            // 
            // biPrint
            // 
            this.biPrint.Caption = "直接打印";
            this.biPrint.Id = 11;
            this.biPrint.Name = "biPrint";
            this.biPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biPrint_ItemClick);
            // 
            // biDesign
            // 
            this.biDesign.Caption = "打印设计";
            this.biDesign.Id = 12;
            this.biDesign.Name = "biDesign";
            this.biDesign.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biDesign_ItemClick);
            // 
            // btnLoadBill
            // 
            this.btnLoadBill.Caption = "调单";
            this.btnLoadBill.Glyph = ((System.Drawing.Image)(resources.GetObject("btnLoadBill.Glyph")));
            this.btnLoadBill.Id = 18;
            this.btnLoadBill.Name = "btnLoadBill";
            this.btnLoadBill.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnLoadBill.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnLoadBill.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLoadBill_ItemClick);
            // 
            // btnBalance
            // 
            this.btnBalance.Caption = "凭证";
            this.btnBalance.Glyph = ((System.Drawing.Image)(resources.GetObject("btnBalance.Glyph")));
            this.btnBalance.Id = 21;
            this.btnBalance.Name = "btnBalance";
            this.btnBalance.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnBalance.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnBalance.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBalance_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "关闭";
            this.btnClose.Glyph = ((System.Drawing.Image)(resources.GetObject("btnClose.Glyph")));
            this.btnClose.Id = 7;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.barStatus),
            new DevExpress.XtraBars.LinkPersistInfo(this.barMemo)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "状态栏";
            // 
            // barStatus
            // 
            this.barStatus.AutoSize = DevExpress.XtraBars.BarStaticItemSize.None;
            this.barStatus.Caption = "就绪！";
            this.barStatus.Id = 19;
            this.barStatus.Name = "barStatus";
            this.barStatus.TextAlignment = System.Drawing.StringAlignment.Near;
            this.barStatus.Width = 200;
            // 
            // barMemo
            // 
            this.barMemo.Caption = "Ctrl+B:条码录入";
            this.barMemo.Id = 20;
            this.barMemo.Name = "barMemo";
            this.barMemo.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.editControl4);
            this.panelControl2.Controls.Add(this.editControl3);
            this.panelControl2.Controls.Add(this.editControl2);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 487);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(823, 34);
            this.panelControl2.TabIndex = 6;
            // 
            // editControl4
            // 
            this.editControl4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.editControl4.BackColor = System.Drawing.Color.Transparent;
            this.editControl4.DataField = "F_CheckDate";
            this.editControl4.DataSource = null;
            this.editControl4.EditLabel = "审核日期:";
            this.editControl4.Enabled = false;
            this.editControl4.Location = new System.Drawing.Point(641, 6);
            this.editControl4.Name = "editControl4";
            this.editControl4.Request = false;
            this.editControl4.Size = new System.Drawing.Size(175, 21);
            this.editControl4.TabIndex = 2;
            // 
            // editControl3
            // 
            this.editControl3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.editControl3.BackColor = System.Drawing.Color.Transparent;
            this.editControl3.DataField = "F_CheckMan";
            this.editControl3.DataSource = null;
            this.editControl3.EditLabel = "审核人:";
            this.editControl3.Enabled = false;
            this.editControl3.Location = new System.Drawing.Point(292, 6);
            this.editControl3.Name = "editControl3";
            this.editControl3.Request = false;
            this.editControl3.Size = new System.Drawing.Size(175, 21);
            this.editControl3.TabIndex = 1;
            // 
            // editControl2
            // 
            this.editControl2.BackColor = System.Drawing.Color.Transparent;
            this.editControl2.DataField = "F_BillMan";
            this.editControl2.DataSource = null;
            this.editControl2.EditLabel = "开单人:";
            this.editControl2.Enabled = false;
            this.editControl2.Location = new System.Drawing.Point(0, 6);
            this.editControl2.Name = "editControl2";
            this.editControl2.Request = false;
            this.editControl2.Size = new System.Drawing.Size(175, 21);
            this.editControl2.TabIndex = 0;
            // 
            // frmBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(823, 543);
            this.Controls.Add(this.gcBill);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmBill";
            this.Load += new System.EventHandler(this.frmBill_Load);
            this.Shown += new System.EventHandler(this.frmBill_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBill_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBill_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInvalid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFinish)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCutOff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binSlaver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraBars.BarButtonItem btnCheck;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.BarSubItem btnPrint;
        private DevExpress.XtraBars.BarButtonItem biPreview;
        private DevExpress.XtraBars.BarButtonItem biPrint;
        private DevExpress.XtraBars.BarButtonItem biDesign;
        protected internal DevExpress.XtraBars.Bar bar1;
        protected internal System.Windows.Forms.BindingSource binMaster;
        protected internal System.Windows.Forms.BindingSource binSlaver;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private System.Windows.Forms.PictureBox picCheck;
        private System.Windows.Forms.PictureBox picCutOff;
        private System.Windows.Forms.PictureBox picFinish;
        private DevExpress.XtraBars.BarButtonItem btnUnCheck;
        protected internal DevExpress.XtraBars.BarButtonItem btnLoadBill;
        protected internal DevExpress.XtraBars.BarButtonItem btnAddRow;
        protected internal DevExpress.XtraBars.BarButtonItem btnDelRow;
        protected internal DevExpress.XtraBars.BarButtonItem btnCutOff;
        protected internal DevExpress.XtraBars.BarButtonItem btnUnCutOff;
        protected internal DevExpress.XtraBars.BarButtonItem btnNew;
        protected internal DevExpress.XtraBars.BarButtonItem btnSave;
        protected internal DevExpress.XtraBars.BarButtonItem btnCopy;
        private DevExpress.XtraBars.BarStaticItem barStatus;
        protected DevExpress.XtraBars.BarStaticItem barMemo;
        protected System.Windows.Forms.Label lbTitle;
        protected internal DevExpress.XtraBars.BarButtonItem btnBalance;
        private DevExpress.XtraBars.BarButtonItem barInvalid;
        private DevExpress.XtraBars.BarButtonItem barUnValid;
        protected internal DevExpress.XtraBars.BarSubItem btnOther;
        public DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.PictureBox picInvalid;
        public myControl.EditControl editControl4;
        public myControl.EditControl editControl3;
        public myControl.EditControl editControl2;
        public DevExpress.XtraGrid.GridControl gcBill;
        public DevExpress.XtraGrid.Views.Grid.GridView gvList;
        public myControl.DateControl dateControl1;
        public myControl.EditControl editControl1;
    }
}
