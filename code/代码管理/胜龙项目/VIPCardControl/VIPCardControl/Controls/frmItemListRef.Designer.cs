namespace UFIDA.Retail.VIPCardControl
{
    partial class frmItemListRef
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmItemListRef));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtItemInfo = new System.Windows.Forms.RichTextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.dgv = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.ptbFirstPage = new System.Windows.Forms.PictureBox();
            this.ptbLastPage = new System.Windows.Forms.PictureBox();
            this.ptbNextPage = new System.Windows.Forms.PictureBox();
            this.ptbPreviewPage = new System.Windows.Forms.PictureBox();
            this.lblCurPages = new System.Windows.Forms.Label();
            this.lblTotalPages = new System.Windows.Forms.Label();
            this.lblTotalRows = new System.Windows.Forms.Label();
            this.chkSelAll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbFirstPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLastPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbNextPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPreviewPage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(1, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(715, 2);
            this.label1.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 25;
            this.label2.Text = "关键字";
            // 
            // txtItemInfo
            // 
            this.txtItemInfo.Location = new System.Drawing.Point(59, 16);
            this.txtItemInfo.Multiline = false;
            this.txtItemInfo.Name = "txtItemInfo";
            this.txtItemInfo.Size = new System.Drawing.Size(399, 22);
            this.txtItemInfo.TabIndex = 26;
            this.txtItemInfo.Text = "";
            this.txtItemInfo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemInfo_KeyPress);
            // 
            // btnClear
            // 
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(472, 16);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 27;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnFilter.Image")));
            this.btnFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFilter.Location = new System.Drawing.Point(553, 16);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 28;
            this.btnFilter.Text = "过滤";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // dgv
            // 
            this.dgv.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.dgv.AllowEditing = false;
            this.dgv.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
            this.dgv.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.dgv.BackColor = System.Drawing.SystemColors.Window;
            this.dgv.ColumnInfo = "10,1,0,0,0,75,Columns:0{Width:15;}\t1{DataType:System.Boolean;ImageAlign:CenterCen" +
                "ter;}\t";
            this.dgv.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dgv.Location = new System.Drawing.Point(12, 84);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(691, 292);
            this.dgv.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("dgv.Styles"));
            this.dgv.TabIndex = 29;
            this.dgv.Click += new System.EventHandler(this.dgv_Click);
            this.dgv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgv_KeyPress);
            this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(628, 385);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 31;
            this.btnClose.Text = "退出";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Image = ((System.Drawing.Image)(resources.GetObject("btnFinish.Image")));
            this.btnFinish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinish.Location = new System.Drawing.Point(533, 385);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(75, 23);
            this.btnFinish.TabIndex = 30;
            this.btnFinish.Text = "完成";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // ptbFirstPage
            // 
            this.ptbFirstPage.Image = ((System.Drawing.Image)(resources.GetObject("ptbFirstPage.Image")));
            this.ptbFirstPage.Location = new System.Drawing.Point(22, 62);
            this.ptbFirstPage.Name = "ptbFirstPage";
            this.ptbFirstPage.Size = new System.Drawing.Size(20, 16);
            this.ptbFirstPage.TabIndex = 32;
            this.ptbFirstPage.TabStop = false;
            this.ptbFirstPage.Click += new System.EventHandler(this.ptbFirstPage_Click);
            // 
            // ptbLastPage
            // 
            this.ptbLastPage.Image = ((System.Drawing.Image)(resources.GetObject("ptbLastPage.Image")));
            this.ptbLastPage.Location = new System.Drawing.Point(146, 62);
            this.ptbLastPage.Name = "ptbLastPage";
            this.ptbLastPage.Size = new System.Drawing.Size(20, 16);
            this.ptbLastPage.TabIndex = 33;
            this.ptbLastPage.TabStop = false;
            this.ptbLastPage.Click += new System.EventHandler(this.ptbLastPage_Click);
            // 
            // ptbNextPage
            // 
            this.ptbNextPage.Image = ((System.Drawing.Image)(resources.GetObject("ptbNextPage.Image")));
            this.ptbNextPage.Location = new System.Drawing.Point(103, 62);
            this.ptbNextPage.Name = "ptbNextPage";
            this.ptbNextPage.Size = new System.Drawing.Size(20, 16);
            this.ptbNextPage.TabIndex = 34;
            this.ptbNextPage.TabStop = false;
            this.ptbNextPage.Click += new System.EventHandler(this.ptbNextPage_Click);
            // 
            // ptbPreviewPage
            // 
            this.ptbPreviewPage.Image = ((System.Drawing.Image)(resources.GetObject("ptbPreviewPage.Image")));
            this.ptbPreviewPage.Location = new System.Drawing.Point(59, 62);
            this.ptbPreviewPage.Name = "ptbPreviewPage";
            this.ptbPreviewPage.Size = new System.Drawing.Size(20, 16);
            this.ptbPreviewPage.TabIndex = 35;
            this.ptbPreviewPage.TabStop = false;
            this.ptbPreviewPage.Click += new System.EventHandler(this.ptbPreviewPage_Click);
            // 
            // lblCurPages
            // 
            this.lblCurPages.AutoSize = true;
            this.lblCurPages.Location = new System.Drawing.Point(213, 62);
            this.lblCurPages.Name = "lblCurPages";
            this.lblCurPages.Size = new System.Drawing.Size(41, 12);
            this.lblCurPages.TabIndex = 36;
            this.lblCurPages.Text = "label3";
            // 
            // lblTotalPages
            // 
            this.lblTotalPages.AutoSize = true;
            this.lblTotalPages.Location = new System.Drawing.Point(362, 62);
            this.lblTotalPages.Name = "lblTotalPages";
            this.lblTotalPages.Size = new System.Drawing.Size(41, 12);
            this.lblTotalPages.TabIndex = 37;
            this.lblTotalPages.Text = "label4";
            // 
            // lblTotalRows
            // 
            this.lblTotalRows.AutoSize = true;
            this.lblTotalRows.Location = new System.Drawing.Point(512, 62);
            this.lblTotalRows.Name = "lblTotalRows";
            this.lblTotalRows.Size = new System.Drawing.Size(41, 12);
            this.lblTotalRows.TabIndex = 38;
            this.lblTotalRows.Text = "label5";
            // 
            // chkSelAll
            // 
            this.chkSelAll.AutoSize = true;
            this.chkSelAll.Location = new System.Drawing.Point(629, 60);
            this.chkSelAll.Name = "chkSelAll";
            this.chkSelAll.Size = new System.Drawing.Size(48, 16);
            this.chkSelAll.TabIndex = 39;
            this.chkSelAll.Text = "全选";
            this.chkSelAll.UseVisualStyleBackColor = true;
            this.chkSelAll.CheckedChanged += new System.EventHandler(this.chkSelAll_CheckedChanged);
            // 
            // frmItemListRef
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 420);
            this.Controls.Add(this.chkSelAll);
            this.Controls.Add(this.lblTotalRows);
            this.Controls.Add(this.lblTotalPages);
            this.Controls.Add(this.lblCurPages);
            this.Controls.Add(this.ptbPreviewPage);
            this.Controls.Add(this.ptbNextPage);
            this.Controls.Add(this.ptbLastPage);
            this.Controls.Add(this.ptbFirstPage);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtItemInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmItemListRef";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "商品查询";
            this.Load += new System.EventHandler(this.frmItemListRef_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbFirstPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLastPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbNextPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPreviewPage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtItemInfo;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnFilter;
        private C1.Win.C1FlexGrid.C1FlexGrid dgv;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.PictureBox ptbFirstPage;
        private System.Windows.Forms.PictureBox ptbLastPage;
        private System.Windows.Forms.PictureBox ptbNextPage;
        private System.Windows.Forms.PictureBox ptbPreviewPage;
        private System.Windows.Forms.Label lblCurPages;
        private System.Windows.Forms.Label lblTotalPages;
        private System.Windows.Forms.Label lblTotalRows;
        private System.Windows.Forms.CheckBox chkSelAll;
    }
}