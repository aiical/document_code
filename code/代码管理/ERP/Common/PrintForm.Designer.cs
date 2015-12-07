namespace Common
{
    partial class PrintForm
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
            this.gridReport = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnDesign = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnSQL = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridReport
            // 
            this.gridReport.EmbeddedNavigator.Name = "";
            this.gridReport.Location = new System.Drawing.Point(12, 12);
            this.gridReport.MainView = this.gridView1;
            this.gridReport.Name = "gridReport";
            this.gridReport.Size = new System.Drawing.Size(257, 292);
            this.gridReport.TabIndex = 0;
            this.gridReport.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.gridView1.GridControl = this.gridReport;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowHorzLines = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.OptionsView.ShowVertLines = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "报表名称";
            this.gridColumn1.FieldName = "F_ReportName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(290, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(88, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "增加(&A)";
            this.btnAdd.Click += new System.EventHandler(this.AddReport);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(290, 69);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(88, 23);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "编辑(&E)";
            this.btnEdit.Click += new System.EventHandler(this.EditReport);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(290, 98);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(88, 23);
            this.btnDel.TabIndex = 4;
            this.btnDel.Text = "删除(&D)";
            this.btnDel.Click += new System.EventHandler(this.DelReport);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(290, 183);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(88, 23);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.Click += new System.EventHandler(this.PrintReport);
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(290, 212);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(88, 23);
            this.btnPreview.TabIndex = 6;
            this.btnPreview.Text = "预览(&V)";
            this.btnPreview.Click += new System.EventHandler(this.PreviewReport);
            // 
            // btnDesign
            // 
            this.btnDesign.Location = new System.Drawing.Point(290, 241);
            this.btnDesign.Name = "btnDesign";
            this.btnDesign.Size = new System.Drawing.Size(88, 23);
            this.btnDesign.TabIndex = 7;
            this.btnDesign.Text = "设计(&D)";
            this.btnDesign.Click += new System.EventHandler(this.DesignReport);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(290, 281);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(290, 41);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(88, 23);
            this.btnCopy.TabIndex = 9;
            this.btnCopy.Text = "复制/增加(&C)";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnSQL
            // 
            this.btnSQL.Location = new System.Drawing.Point(290, 142);
            this.btnSQL.Name = "btnSQL";
            this.btnSQL.Size = new System.Drawing.Size(88, 23);
            this.btnSQL.TabIndex = 10;
            this.btnSQL.Text = "SQL语句";
            this.btnSQL.Click += new System.EventHandler(this.btnSQL_Click);
            // 
            // PrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(402, 320);
            this.Controls.Add(this.btnSQL);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDesign);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gridReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrintForm";
            this.Text = "打印管理";
            this.Shown += new System.EventHandler(this.PrintForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gridReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridReport;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnDesign;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCopy;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.Button btnSQL;
    }
}
