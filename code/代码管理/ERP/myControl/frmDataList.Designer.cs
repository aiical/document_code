namespace myControl
{
    partial class frmDataList
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
            this.gcQuery = new DevExpress.XtraGrid.GridControl();
            this.gvQuery = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuery = new DevExpress.XtraEditors.TextEdit();
            this.sbOK = new DevExpress.XtraEditors.SimpleButton();
            this.sbCancel = new DevExpress.XtraEditors.SimpleButton();
            this.sbNew = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuery.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcQuery
            // 
            this.gcQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gcQuery.EmbeddedNavigator.Name = "";
            this.gcQuery.Location = new System.Drawing.Point(15, 35);
            this.gcQuery.MainView = this.gvQuery;
            this.gcQuery.Name = "gcQuery";
            this.gcQuery.Size = new System.Drawing.Size(506, 302);
            this.gcQuery.TabIndex = 0;
            this.gcQuery.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvQuery});
            // 
            // gvQuery
            // 
            this.gvQuery.GridControl = this.gcQuery;
            this.gvQuery.Name = "gvQuery";
            this.gvQuery.OptionsBehavior.Editable = false;
            this.gvQuery.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvQuery.OptionsView.ColumnAutoWidth = false;
            this.gvQuery.OptionsView.ShowGroupPanel = false;
            this.gvQuery.DoubleClick += new System.EventHandler(this.gvQuery_DoubleClick);
            this.gvQuery.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvQuery_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "查找字键字:";
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(90, 8);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(290, 21);
            this.txtQuery.TabIndex = 2;
            this.txtQuery.EditValueChanged += new System.EventHandler(this.txtQuery_EditValueChanged);
            this.txtQuery.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuery_KeyDown);
            // 
            // sbOK
            // 
            this.sbOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sbOK.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbOK.Appearance.Options.UseFont = true;
            this.sbOK.Location = new System.Drawing.Point(379, 348);
            this.sbOK.Name = "sbOK";
            this.sbOK.Size = new System.Drawing.Size(67, 23);
            this.sbOK.TabIndex = 3;
            this.sbOK.Text = "确定(&O)";
            this.sbOK.Click += new System.EventHandler(this.sbOK_Click);
            // 
            // sbCancel
            // 
            this.sbCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sbCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbCancel.Appearance.Options.UseFont = true;
            this.sbCancel.Location = new System.Drawing.Point(452, 348);
            this.sbCancel.Name = "sbCancel";
            this.sbCancel.Size = new System.Drawing.Size(67, 23);
            this.sbCancel.TabIndex = 4;
            this.sbCancel.Text = "取消(&C)";
            this.sbCancel.Click += new System.EventHandler(this.sbCancel_Click);
            // 
            // sbNew
            // 
            this.sbNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sbNew.Location = new System.Drawing.Point(15, 348);
            this.sbNew.Name = "sbNew";
            this.sbNew.Size = new System.Drawing.Size(69, 23);
            this.sbNew.TabIndex = 5;
            this.sbNew.Text = "新增(&A)";
            this.sbNew.Click += new System.EventHandler(this.sbNew_Click);
            // 
            // frmDataList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 383);
            this.Controls.Add(this.sbNew);
            this.Controls.Add(this.sbCancel);
            this.Controls.Add(this.sbOK);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gcQuery);
            this.KeyPreview = true;
            this.Name = "frmDataList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据列表";
            this.Load += new System.EventHandler(this.frmDataList_Load);
            this.Shown += new System.EventHandler(this.frmDataList_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDataList_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gcQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuery.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtQuery;
        private DevExpress.XtraEditors.SimpleButton sbOK;
        private DevExpress.XtraEditors.SimpleButton sbCancel;
        public DevExpress.XtraGrid.GridControl gcQuery;
        public DevExpress.XtraGrid.Views.Grid.GridView gvQuery;
        public DevExpress.XtraEditors.SimpleButton sbNew;
    }
}