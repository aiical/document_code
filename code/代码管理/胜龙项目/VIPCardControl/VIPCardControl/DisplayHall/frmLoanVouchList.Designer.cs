namespace UFIDA.Retail.VIPCardControl
{
    partial class frmLoanVouchList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoanVouchList));
            this.tsbQuery = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.dgv = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExport = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDel = new System.Windows.Forms.ToolStripButton();
            this.tsbModify = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbView = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbOK = new System.Windows.Forms.ToolStripButton();
            this.tsbUpload = new System.Windows.Forms.ToolStripButton();
            this.tsbUploadToU8 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsbQuery
            // 
            this.tsbQuery.Image = ((System.Drawing.Image)(resources.GetObject("tsbQuery.Image")));
            this.tsbQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQuery.Name = "tsbQuery";
            this.tsbQuery.Size = new System.Drawing.Size(49, 22);
            this.tsbQuery.Text = "查询";
            this.tsbQuery.Click += new System.EventHandler(this.tsbQuery_Click);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(49, 22);
            this.tsbRefresh.Text = "刷新";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // dgv
            // 
            this.dgv.AllowEditing = false;
            this.dgv.BackColor = System.Drawing.SystemColors.Window;
            this.dgv.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.dgv.ColumnInfo = resources.GetString("dgv.ColumnInfo");
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dgv.Location = new System.Drawing.Point(0, 25);
            this.dgv.Name = "dgv";
            this.dgv.Rows.Count = 1;
            this.dgv.ShowCursor = true;
            this.dgv.Size = new System.Drawing.Size(1014, 454);
            this.dgv.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("dgv.Styles"));
            this.dgv.TabIndex = 119;
            this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbExport
            // 
            this.tsbExport.Image = ((System.Drawing.Image)(resources.GetObject("tsbExport.Image")));
            this.tsbExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExport.Name = "tsbExport";
            this.tsbExport.Size = new System.Drawing.Size(49, 22);
            this.tsbExport.Text = "输出";
            this.tsbExport.Click += new System.EventHandler(this.tsbExport_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRefresh,
            this.toolStripSeparator2,
            this.tsbQuery,
            this.toolStripSeparator1,
            this.tsbDel,
            this.tsbModify,
            this.toolStripSeparator3,
            this.tsbView,
            this.tsbExport,
            this.toolStripSeparator4,
            this.tsbOK,
            this.tsbUpload,
            this.tsbUploadToU8});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1014, 25);
            this.toolStrip1.TabIndex = 118;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbDel
            // 
            this.tsbDel.Image = ((System.Drawing.Image)(resources.GetObject("tsbDel.Image")));
            this.tsbDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDel.Name = "tsbDel";
            this.tsbDel.Size = new System.Drawing.Size(49, 22);
            this.tsbDel.Text = "删除";
            this.tsbDel.Click += new System.EventHandler(this.tsbDel_Click);
            // 
            // tsbModify
            // 
            this.tsbModify.Image = ((System.Drawing.Image)(resources.GetObject("tsbModify.Image")));
            this.tsbModify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbModify.Name = "tsbModify";
            this.tsbModify.Size = new System.Drawing.Size(49, 22);
            this.tsbModify.Text = "修改";
            this.tsbModify.Click += new System.EventHandler(this.tsbModify_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbView
            // 
            this.tsbView.Image = ((System.Drawing.Image)(resources.GetObject("tsbView.Image")));
            this.tsbView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbView.Name = "tsbView";
            this.tsbView.Size = new System.Drawing.Size(49, 22);
            this.tsbView.Text = "查看";
            this.tsbView.Click += new System.EventHandler(this.tsbView_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbOK
            // 
            this.tsbOK.Image = ((System.Drawing.Image)(resources.GetObject("tsbOK.Image")));
            this.tsbOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOK.Name = "tsbOK";
            this.tsbOK.Size = new System.Drawing.Size(49, 22);
            this.tsbOK.Text = "确定";
            this.tsbOK.Visible = false;
            this.tsbOK.Click += new System.EventHandler(this.tsbOK_Click);
            // 
            // tsbUpload
            // 
            this.tsbUpload.Image = ((System.Drawing.Image)(resources.GetObject("tsbUpload.Image")));
            this.tsbUpload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpload.Name = "tsbUpload";
            this.tsbUpload.Size = new System.Drawing.Size(73, 22);
            this.tsbUpload.Text = "上传零售";
            this.tsbUpload.Click += new System.EventHandler(this.tsbUpload_Click);
            // 
            // tsbUploadToU8
            // 
            this.tsbUploadToU8.Image = ((System.Drawing.Image)(resources.GetObject("tsbUploadToU8.Image")));
            this.tsbUploadToU8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUploadToU8.Name = "tsbUploadToU8";
            this.tsbUploadToU8.Size = new System.Drawing.Size(61, 22);
            this.tsbUploadToU8.Text = "上传U8";
            this.tsbUploadToU8.Click += new System.EventHandler(this.tsbUploadToU8_Click);
            // 
            // frmLoanVouchList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1014, 479);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLoanVouchList";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "借出单单据列表";
            this.Load += new System.EventHandler(this.frmLoanVouchList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton tsbQuery;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private C1.Win.C1FlexGrid.C1FlexGrid dgv;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbExport;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbModify;
        private System.Windows.Forms.ToolStripButton tsbDel;
        private System.Windows.Forms.ToolStripButton tsbView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbOK;
        private System.Windows.Forms.ToolStripButton tsbUpload;
        private System.Windows.Forms.ToolStripButton tsbUploadToU8;
    }
}