namespace Common
{
    partial class frmGetStockPrice
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
            this.gcPrice = new DevExpress.XtraGrid.GridControl();
            this.gvPrice = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sbOK = new DevExpress.XtraEditors.SimpleButton();
            this.sbCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // gcPrice
            // 
            // 
            // 
            // 
            this.gcPrice.EmbeddedNavigator.Name = "";
            this.gcPrice.Location = new System.Drawing.Point(12, 13);
            this.gcPrice.MainView = this.gvPrice;
            this.gcPrice.Name = "gcPrice";
            this.gcPrice.Size = new System.Drawing.Size(253, 168);
            this.gcPrice.TabIndex = 0;
            this.gcPrice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPrice});
            this.gcPrice.DoubleClick += new System.EventHandler(this.gcPrice_DoubleClick);
            // 
            // gvPrice
            // 
            this.gvPrice.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gvPrice.GridControl = this.gcPrice;
            this.gvPrice.Name = "gvPrice";
            this.gvPrice.OptionsBehavior.Editable = false;
            this.gvPrice.OptionsCustomization.AllowFilter = false;
            this.gvPrice.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvPrice.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gvPrice.OptionsView.ColumnAutoWidth = false;
            this.gvPrice.OptionsView.ShowGroupPanel = false;
            this.gvPrice.OptionsView.ShowIndicator = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn1.Caption = "价格名称";
            this.gridColumn1.FieldName = "F_Name";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 138;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn2.Caption = "价格";
            this.gridColumn2.FieldName = "F_Price";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 87;
            // 
            // sbOK
            // 
            this.sbOK.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbOK.Appearance.Options.UseFont = true;
            this.sbOK.Location = new System.Drawing.Point(133, 188);
            this.sbOK.Name = "sbOK";
            this.sbOK.Size = new System.Drawing.Size(63, 23);
            this.sbOK.TabIndex = 1;
            this.sbOK.Text = "确定(&O)";
            this.sbOK.Click += new System.EventHandler(this.sbOK_Click);
            // 
            // sbCancel
            // 
            this.sbCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbCancel.Appearance.Options.UseFont = true;
            this.sbCancel.Location = new System.Drawing.Point(202, 188);
            this.sbCancel.Name = "sbCancel";
            this.sbCancel.Size = new System.Drawing.Size(63, 23);
            this.sbCancel.TabIndex = 2;
            this.sbCancel.Text = "取消(&C)";
            this.sbCancel.Click += new System.EventHandler(this.sbCancel_Click);
            // 
            // frmGetStockPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(279, 221);
            this.Controls.Add(this.sbCancel);
            this.Controls.Add(this.sbOK);
            this.Controls.Add(this.gcPrice);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGetStockPrice";
            this.Text = "物料采购价格";
            ((System.ComponentModel.ISupportInitialize)(this.gcPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPrice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.SimpleButton sbOK;
        private DevExpress.XtraEditors.SimpleButton sbCancel;
        public DevExpress.XtraGrid.GridControl gcPrice;
        public DevExpress.XtraGrid.Views.Grid.GridView gvPrice;
    }
}
