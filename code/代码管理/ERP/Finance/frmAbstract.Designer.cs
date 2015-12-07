namespace Finance
{
    partial class frmAbstract
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sbDelType = new DevExpress.XtraEditors.SimpleButton();
            this.sbModiType = new DevExpress.XtraEditors.SimpleButton();
            this.sbAddType = new DevExpress.XtraEditors.SimpleButton();
            this.gcType = new DevExpress.XtraGrid.GridControl();
            this.gvType = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.gcAbstract = new DevExpress.XtraGrid.GridControl();
            this.gvAbstract = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sbOK = new DevExpress.XtraEditors.SimpleButton();
            this.sbCancel = new DevExpress.XtraEditors.SimpleButton();
            this.sbAdd = new DevExpress.XtraEditors.SimpleButton();
            this.sbModi = new DevExpress.XtraEditors.SimpleButton();
            this.sbDel = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAbstract)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAbstract)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sbDelType);
            this.groupBox1.Controls.Add(this.sbModiType);
            this.groupBox1.Controls.Add(this.sbAddType);
            this.groupBox1.Controls.Add(this.gcType);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 365);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "摘要类别";
            // 
            // sbDelType
            // 
            this.sbDelType.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbDelType.Appearance.Options.UseFont = true;
            this.sbDelType.Location = new System.Drawing.Point(42, 327);
            this.sbDelType.Name = "sbDelType";
            this.sbDelType.Size = new System.Drawing.Size(75, 23);
            this.sbDelType.TabIndex = 3;
            this.sbDelType.Text = "删除";
            this.sbDelType.Click += new System.EventHandler(this.sbDelType_Click);
            // 
            // sbModiType
            // 
            this.sbModiType.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbModiType.Appearance.Options.UseFont = true;
            this.sbModiType.Location = new System.Drawing.Point(42, 298);
            this.sbModiType.Name = "sbModiType";
            this.sbModiType.Size = new System.Drawing.Size(75, 23);
            this.sbModiType.TabIndex = 2;
            this.sbModiType.Text = "修改";
            this.sbModiType.Click += new System.EventHandler(this.sbModiType_Click);
            // 
            // sbAddType
            // 
            this.sbAddType.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbAddType.Appearance.Options.UseFont = true;
            this.sbAddType.Location = new System.Drawing.Point(42, 269);
            this.sbAddType.Name = "sbAddType";
            this.sbAddType.Size = new System.Drawing.Size(75, 23);
            this.sbAddType.TabIndex = 1;
            this.sbAddType.Text = "增加";
            this.sbAddType.Click += new System.EventHandler(this.sbAddType_Click);
            // 
            // gcType
            // 
            this.gcType.EmbeddedNavigator.Name = "";
            this.gcType.Location = new System.Drawing.Point(7, 21);
            this.gcType.MainView = this.gvType;
            this.gcType.Name = "gcType";
            this.gcType.Size = new System.Drawing.Size(174, 229);
            this.gcType.TabIndex = 0;
            this.gcType.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvType});
            // 
            // gvType
            // 
            this.gvType.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvType.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvType.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gvType.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.gvType.GridControl = this.gcType;
            this.gvType.Name = "gvType";
            this.gvType.OptionsBehavior.Editable = false;
            this.gvType.OptionsCustomization.AllowFilter = false;
            this.gvType.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvType.OptionsView.ShowGroupPanel = false;
            this.gvType.OptionsView.ShowHorzLines = false;
            this.gvType.OptionsView.ShowIndicator = false;
            this.gvType.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvType_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "接要类别";
            this.gridColumn1.FieldName = "F_Name";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "凭证摘要:";
            // 
            // gcAbstract
            // 
            this.gcAbstract.EmbeddedNavigator.Name = "";
            this.gcAbstract.Location = new System.Drawing.Point(217, 34);
            this.gcAbstract.MainView = this.gvAbstract;
            this.gcAbstract.Name = "gcAbstract";
            this.gcAbstract.Size = new System.Drawing.Size(305, 344);
            this.gcAbstract.TabIndex = 2;
            this.gcAbstract.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAbstract});
            this.gcAbstract.DoubleClick += new System.EventHandler(this.gcAbstract_DoubleClick);
            // 
            // gvAbstract
            // 
            this.gvAbstract.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvAbstract.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvAbstract.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gvAbstract.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2});
            this.gvAbstract.GridControl = this.gcAbstract;
            this.gvAbstract.Name = "gvAbstract";
            this.gvAbstract.OptionsBehavior.Editable = false;
            this.gvAbstract.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvAbstract.OptionsView.ShowGroupPanel = false;
            this.gvAbstract.OptionsView.ShowIndicator = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "摘要";
            this.gridColumn2.FieldName = "F_Remark";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // sbOK
            // 
            this.sbOK.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbOK.Appearance.Options.UseFont = true;
            this.sbOK.Location = new System.Drawing.Point(540, 34);
            this.sbOK.Name = "sbOK";
            this.sbOK.Size = new System.Drawing.Size(75, 23);
            this.sbOK.TabIndex = 3;
            this.sbOK.Text = "确定";
            this.sbOK.Click += new System.EventHandler(this.sbOK_Click);
            // 
            // sbCancel
            // 
            this.sbCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbCancel.Appearance.Options.UseFont = true;
            this.sbCancel.Location = new System.Drawing.Point(540, 63);
            this.sbCancel.Name = "sbCancel";
            this.sbCancel.Size = new System.Drawing.Size(75, 23);
            this.sbCancel.TabIndex = 4;
            this.sbCancel.Text = "取消";
            this.sbCancel.Click += new System.EventHandler(this.sbCancel_Click);
            // 
            // sbAdd
            // 
            this.sbAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbAdd.Appearance.Options.UseFont = true;
            this.sbAdd.Location = new System.Drawing.Point(540, 297);
            this.sbAdd.Name = "sbAdd";
            this.sbAdd.Size = new System.Drawing.Size(75, 23);
            this.sbAdd.TabIndex = 5;
            this.sbAdd.Text = "增加";
            this.sbAdd.Click += new System.EventHandler(this.sbAdd_Click);
            // 
            // sbModi
            // 
            this.sbModi.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbModi.Appearance.Options.UseFont = true;
            this.sbModi.Location = new System.Drawing.Point(540, 326);
            this.sbModi.Name = "sbModi";
            this.sbModi.Size = new System.Drawing.Size(75, 23);
            this.sbModi.TabIndex = 6;
            this.sbModi.Text = "修改";
            this.sbModi.Click += new System.EventHandler(this.sbModi_Click);
            // 
            // sbDel
            // 
            this.sbDel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbDel.Appearance.Options.UseFont = true;
            this.sbDel.Location = new System.Drawing.Point(540, 355);
            this.sbDel.Name = "sbDel";
            this.sbDel.Size = new System.Drawing.Size(75, 23);
            this.sbDel.TabIndex = 7;
            this.sbDel.Text = "删除";
            this.sbDel.Click += new System.EventHandler(this.sbDel_Click);
            // 
            // frmAbstract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(627, 390);
            this.Controls.Add(this.sbDel);
            this.Controls.Add(this.sbModi);
            this.Controls.Add(this.sbAdd);
            this.Controls.Add(this.sbCancel);
            this.Controls.Add(this.sbOK);
            this.Controls.Add(this.gcAbstract);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbstract";
            this.Text = "凭证摘要";
            this.Load += new System.EventHandler(this.frmAbstract_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAbstract)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAbstract)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl gcType;
        private DevExpress.XtraGrid.Views.Grid.GridView gvType;
        private DevExpress.XtraEditors.SimpleButton sbDelType;
        private DevExpress.XtraEditors.SimpleButton sbModiType;
        private DevExpress.XtraEditors.SimpleButton sbAddType;
        private DevExpress.XtraEditors.SimpleButton sbOK;
        private DevExpress.XtraEditors.SimpleButton sbCancel;
        private DevExpress.XtraEditors.SimpleButton sbAdd;
        private DevExpress.XtraEditors.SimpleButton sbModi;
        private DevExpress.XtraEditors.SimpleButton sbDel;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        public DevExpress.XtraGrid.GridControl gcAbstract;
        public DevExpress.XtraGrid.Views.Grid.GridView gvAbstract;
    }
}
