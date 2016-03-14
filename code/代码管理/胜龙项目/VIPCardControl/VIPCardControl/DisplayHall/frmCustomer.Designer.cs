namespace UFIDA.Retail.VIPCardControl
{
    partial class frmCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomer));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbDel = new System.Windows.Forms.ToolStripButton();
            this.tsbModify = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.tsbExport = new System.Windows.Forms.ToolStripButton();
            this.dgv = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.tsbUploadToRM = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRefresh,
            this.tsbAdd,
            this.tsbDel,
            this.tsbModify,
            this.toolStripSeparator1,
            this.tsbSearch,
            this.toolStripSeparator2,
            this.tsbPrint,
            this.tsbExport,
            this.tsbUploadToRM});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1014, 25);
            this.toolStrip1.TabIndex = 111;
            this.toolStrip1.Text = "toolStrip1";
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
            // tsbAdd
            // 
            this.tsbAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbAdd.Image")));
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(49, 22);
            this.tsbAdd.Text = "添加";
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSearch
            // 
            this.tsbSearch.Image = ((System.Drawing.Image)(resources.GetObject("tsbSearch.Image")));
            this.tsbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSearch.Name = "tsbSearch";
            this.tsbSearch.Size = new System.Drawing.Size(49, 22);
            this.tsbSearch.Text = "查询";
            this.tsbSearch.Click += new System.EventHandler(this.tsbSearch_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbPrint
            // 
            this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(49, 22);
            this.tsbPrint.Text = "打印";
            this.tsbPrint.Click += new System.EventHandler(this.tsbPrint_Click);
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
            // dgv
            // 
            this.dgv.AllowEditing = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.BackColor = System.Drawing.SystemColors.Window;
            this.dgv.ColumnInfo = resources.GetString("dgv.ColumnInfo");
            this.dgv.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dgv.Location = new System.Drawing.Point(0, 28);
            this.dgv.Name = "dgv";
            this.dgv.Rows.Count = 1;
            this.dgv.Size = new System.Drawing.Size(1014, 448);
            this.dgv.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("dgv.Styles"));
            this.dgv.TabIndex = 112;
            this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
            // 
            // tsbUploadToRM
            // 
            this.tsbUploadToRM.Image = ((System.Drawing.Image)(resources.GetObject("tsbUploadToRM.Image")));
            this.tsbUploadToRM.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUploadToRM.Name = "tsbUploadToRM";
            this.tsbUploadToRM.Size = new System.Drawing.Size(73, 22);
            this.tsbUploadToRM.Text = "上传零售";
            this.tsbUploadToRM.Click += new System.EventHandler(this.tsbUploadToRM_Click);
            // 
            // frmCustomer
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
            this.Name = "frmCustomer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "总部展厅客户档案";
            this.Load += new System.EventHandler(this.frmCustomer_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbModify;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripButton tsbExport;
        private C1.Win.C1FlexGrid.C1FlexGrid dgv;
        private System.Windows.Forms.ToolStripButton tsbDel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripButton tsbUploadToRM;

    }
}