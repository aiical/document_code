namespace CommonData
{
    partial class frmBillImport
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
            this.ucDate = new myControl.ucDate();
            this.gcMaster = new DevExpress.XtraGrid.GridControl();
            this.gvMaster = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcSlaver = new DevExpress.XtraGrid.GridControl();
            this.gvSlaver = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.sbOK = new DevExpress.XtraEditors.SimpleButton();
            this.spClose = new DevExpress.XtraEditors.SimpleButton();
            this.ckAll = new DevExpress.XtraEditors.CheckEdit();
            this.cbBill = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSlaver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSlaver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBill.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ucDate
            // 
            this.ucDate.DateTag = myControl.DateFlag.当天;
            this.ucDate.Location = new System.Drawing.Point(1, 3);
            this.ucDate.Name = "ucDate";
            this.ucDate.Size = new System.Drawing.Size(397, 28);
            this.ucDate.TabIndex = 0;
            this.ucDate.RefreshDateChanged += new myControl.RefreshDateEventHandler(this.ucDate_RefreshDateChanged);
            // 
            // gcMaster
            // 
            this.gcMaster.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.gcMaster.EmbeddedNavigator.Name = "";
            this.gcMaster.Location = new System.Drawing.Point(13, 38);
            this.gcMaster.MainView = this.gvMaster;
            this.gcMaster.Name = "gcMaster";
            this.gcMaster.Size = new System.Drawing.Size(632, 156);
            this.gcMaster.TabIndex = 1;
            this.gcMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMaster,
            this.gridView2});
            // 
            // gvMaster
            // 
            this.gvMaster.GridControl = this.gcMaster;
            this.gvMaster.Name = "gvMaster";
            this.gvMaster.OptionsBehavior.Editable = false;
            this.gvMaster.OptionsView.ColumnAutoWidth = false;
            this.gvMaster.OptionsView.ShowGroupPanel = false;
            this.gvMaster.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvMaster_FocusedRowChanged);
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gcMaster;
            this.gridView2.Name = "gridView2";
            // 
            // gcSlaver
            // 
            this.gcSlaver.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.gcSlaver.EmbeddedNavigator.Name = "";
            this.gcSlaver.Location = new System.Drawing.Point(12, 200);
            this.gcSlaver.MainView = this.gvSlaver;
            this.gcSlaver.Name = "gcSlaver";
            this.gcSlaver.Size = new System.Drawing.Size(632, 188);
            this.gcSlaver.TabIndex = 2;
            this.gcSlaver.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSlaver,
            this.gridView4});
            // 
            // gvSlaver
            // 
            this.gvSlaver.GridControl = this.gcSlaver;
            this.gvSlaver.Name = "gvSlaver";
            this.gvSlaver.OptionsBehavior.Editable = false;
            this.gvSlaver.OptionsView.ColumnAutoWidth = false;
            this.gvSlaver.OptionsView.ShowGroupPanel = false;
            // 
            // gridView4
            // 
            this.gridView4.GridControl = this.gcSlaver;
            this.gridView4.Name = "gridView4";
            // 
            // sbOK
            // 
            this.sbOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sbOK.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbOK.Appearance.Options.UseFont = true;
            this.sbOK.Location = new System.Drawing.Point(488, 395);
            this.sbOK.Name = "sbOK";
            this.sbOK.Size = new System.Drawing.Size(75, 23);
            this.sbOK.TabIndex = 3;
            this.sbOK.Text = "导入到单据";
            this.sbOK.Click += new System.EventHandler(this.sbOK_Click);
            // 
            // spClose
            // 
            this.spClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.spClose.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spClose.Appearance.Options.UseFont = true;
            this.spClose.Location = new System.Drawing.Point(569, 395);
            this.spClose.Name = "spClose";
            this.spClose.Size = new System.Drawing.Size(75, 23);
            this.spClose.TabIndex = 4;
            this.spClose.Text = "关闭(&C)";
            this.spClose.Click += new System.EventHandler(this.spClose_Click);
            // 
            // ckAll
            // 
            this.ckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ckAll.Location = new System.Drawing.Point(12, 394);
            this.ckAll.Name = "ckAll";
            this.ckAll.Properties.Caption = "全选";
            this.ckAll.Size = new System.Drawing.Size(75, 19);
            this.ckAll.TabIndex = 5;
            // 
            // cbBill
            // 
            this.cbBill.Location = new System.Drawing.Point(496, 8);
            this.cbBill.Name = "cbBill";
            this.cbBill.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbBill.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbBill.Size = new System.Drawing.Size(148, 21);
            this.cbBill.TabIndex = 6;
            this.cbBill.SelectedIndexChanged += new System.EventHandler(this.cbBill_SelectedIndexChanged);
            // 
            // frmBillImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(657, 426);
            this.Controls.Add(this.cbBill);
            this.Controls.Add(this.ckAll);
            this.Controls.Add(this.spClose);
            this.Controls.Add(this.sbOK);
            this.Controls.Add(this.gcSlaver);
            this.Controls.Add(this.gcMaster);
            this.Controls.Add(this.ucDate);
            this.KeyPreview = true;
            this.Name = "frmBillImport";
            this.Text = "单据导入";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBillImport_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gcMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSlaver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSlaver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBill.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private myControl.ucDate ucDate;
        private DevExpress.XtraGrid.GridControl gcMaster;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMaster;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.GridControl gcSlaver;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSlaver;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraEditors.SimpleButton sbOK;
        private DevExpress.XtraEditors.SimpleButton spClose;
        private DevExpress.XtraEditors.CheckEdit ckAll;
        private DevExpress.XtraEditors.ComboBoxEdit cbBill;
    }
}
