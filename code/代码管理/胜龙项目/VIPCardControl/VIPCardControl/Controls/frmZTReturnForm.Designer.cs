namespace UFIDA.Retail.VIPCardControl
{
    partial class frmZTReturnForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmZTReturnForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtItemInfo = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvMain = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDetail = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.chkSelAllMain = new System.Windows.Forms.CheckBox();
            this.chkSelAllDetail = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 39);
            this.panel1.TabIndex = 0;
            // 
            // btnQuery
            // 
            this.btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point(8, 7);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(88, 24);
            this.btnQuery.TabIndex = 38;
            this.btnQuery.Text = "    查 询(&Q)";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(102, 7);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 24);
            this.btnOK.TabIndex = 39;
            this.btnOK.Text = "    确 定(O&)";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(196, 7);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(88, 24);
            this.btnExit.TabIndex = 37;
            this.btnExit.Text = "    退 出(&Q)";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(1, 284);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1023, 2);
            this.label1.TabIndex = 40;
            // 
            // btnFilter
            // 
            this.btnFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnFilter.Image")));
            this.btnFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFilter.Location = new System.Drawing.Point(551, 45);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 45;
            this.btnFilter.Text = "过滤";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnClear
            // 
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(470, 45);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 44;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtItemInfo
            // 
            this.txtItemInfo.Location = new System.Drawing.Point(57, 45);
            this.txtItemInfo.Multiline = false;
            this.txtItemInfo.Name = "txtItemInfo";
            this.txtItemInfo.Size = new System.Drawing.Size(399, 22);
            this.txtItemInfo.TabIndex = 43;
            this.txtItemInfo.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(10, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 42;
            this.label2.Text = "关键字";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dgvMain);
            this.panel2.Location = new System.Drawing.Point(1, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1016, 208);
            this.panel2.TabIndex = 46;
            // 
            // dgvMain
            // 
            this.dgvMain.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.dgvMain.AllowEditing = false;
            this.dgvMain.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
            this.dgvMain.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.dgvMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMain.BackColor = System.Drawing.SystemColors.Window;
            this.dgvMain.ColumnInfo = "1,1,0,0,0,75,Columns:0{Width:9;}\t";
            this.dgvMain.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dgvMain.Location = new System.Drawing.Point(3, 3);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.Rows.Count = 1;
            this.dgvMain.Size = new System.Drawing.Size(1010, 200);
            this.dgvMain.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("dgvMain.Styles"));
            this.dgvMain.TabIndex = 42;
            this.dgvMain.Click += new System.EventHandler(this.dgvMain_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvDetail);
            this.groupBox1.Location = new System.Drawing.Point(1, 305);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1016, 173);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "单据明细";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.dgvDetail.AllowEditing = false;
            this.dgvDetail.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
            this.dgvDetail.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.dgvDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetail.BackColor = System.Drawing.SystemColors.Window;
            this.dgvDetail.ColumnInfo = resources.GetString("dgvDetail.ColumnInfo");
            this.dgvDetail.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dgvDetail.Location = new System.Drawing.Point(3, 18);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.Rows.Count = 1;
            this.dgvDetail.Size = new System.Drawing.Size(1010, 149);
            this.dgvDetail.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("dgvDetail.Styles"));
            this.dgvDetail.TabIndex = 43;
            this.dgvDetail.Click += new System.EventHandler(this.dgvDetail_Click);
            // 
            // chkSelAllMain
            // 
            this.chkSelAllMain.AutoSize = true;
            this.chkSelAllMain.Location = new System.Drawing.Point(727, 51);
            this.chkSelAllMain.Name = "chkSelAllMain";
            this.chkSelAllMain.Size = new System.Drawing.Size(48, 16);
            this.chkSelAllMain.TabIndex = 48;
            this.chkSelAllMain.Text = "全选";
            this.chkSelAllMain.UseVisualStyleBackColor = true;
            this.chkSelAllMain.CheckedChanged += new System.EventHandler(this.chkSelAllMain_CheckedChanged);
            // 
            // chkSelAllDetail
            // 
            this.chkSelAllDetail.AutoSize = true;
            this.chkSelAllDetail.Location = new System.Drawing.Point(727, 291);
            this.chkSelAllDetail.Name = "chkSelAllDetail";
            this.chkSelAllDetail.Size = new System.Drawing.Size(48, 16);
            this.chkSelAllDetail.TabIndex = 49;
            this.chkSelAllDetail.Text = "全选";
            this.chkSelAllDetail.UseVisualStyleBackColor = true;
            this.chkSelAllDetail.CheckedChanged += new System.EventHandler(this.chkSelAllDetail_CheckedChanged);
            // 
            // frmZTReturnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 479);
            this.ControlBox = false;
            this.Controls.Add(this.chkSelAllDetail);
            this.Controls.Add(this.chkSelAllMain);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtItemInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "frmZTReturnForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "展厅冲单";
            this.Load += new System.EventHandler(this.frmZTReturnForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RichTextBox txtItemInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private C1.Win.C1FlexGrid.C1FlexGrid dgvMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private C1.Win.C1FlexGrid.C1FlexGrid dgvDetail;
        private System.Windows.Forms.CheckBox chkSelAllMain;
        private System.Windows.Forms.CheckBox chkSelAllDetail;
    }
}