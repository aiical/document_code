namespace UFIDA.Retail.VIPCardControl
{
    partial class frmScanBarCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScanBarCode));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.btnBarCodeFile = new System.Windows.Forms.Button();
            this.dgvErrorBarCode = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrorBarCode)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(-4, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(457, 2);
            this.label1.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "条码：";
            // 
            // txtBarCode
            // 
            this.txtBarCode.Location = new System.Drawing.Point(53, 19);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(359, 21);
            this.txtBarCode.TabIndex = 27;
            this.txtBarCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBarCode_KeyUp);
            // 
            // btnBarCodeFile
            // 
            this.btnBarCodeFile.Location = new System.Drawing.Point(418, 17);
            this.btnBarCodeFile.Name = "btnBarCodeFile";
            this.btnBarCodeFile.Size = new System.Drawing.Size(24, 23);
            this.btnBarCodeFile.TabIndex = 28;
            this.btnBarCodeFile.Text = "…";
            this.btnBarCodeFile.UseVisualStyleBackColor = true;
            this.btnBarCodeFile.Click += new System.EventHandler(this.btnBarCodeFile_Click);
            // 
            // dgvErrorBarCode
            // 
            this.dgvErrorBarCode.AllowUserToAddRows = false;
            this.dgvErrorBarCode.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvErrorBarCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvErrorBarCode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvErrorBarCode.Location = new System.Drawing.Point(0, 112);
            this.dgvErrorBarCode.Name = "dgvErrorBarCode";
            this.dgvErrorBarCode.RowTemplate.Height = 23;
            this.dgvErrorBarCode.Size = new System.Drawing.Size(453, 172);
            this.dgvErrorBarCode.TabIndex = 32;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "编号";
            this.Column1.Name = "Column1";
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "以下条码解析失败";
            this.Column2.Name = "Column2";
            this.Column2.Width = 160;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "失败原因";
            this.Column3.Name = "Column3";
            this.Column3.Width = 170;
            // 
            // btnImport
            // 
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
            this.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.Location = new System.Drawing.Point(166, 71);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(88, 24);
            this.btnImport.TabIndex = 35;
            this.btnImport.Text = "    导 入(&I)";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(260, 71);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(88, 24);
            this.btnExport.TabIndex = 36;
            this.btnExport.Text = "    导 出(&O)";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFinish.Image = ((System.Drawing.Image)(resources.GetObject("btnFinish.Image")));
            this.btnFinish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinish.Location = new System.Drawing.Point(17, 71);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(88, 24);
            this.btnFinish.TabIndex = 33;
            this.btnFinish.Text = "    完 成(&F)";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Visible = false;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(354, 71);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(88, 24);
            this.btnExit.TabIndex = 34;
            this.btnExit.Text = "    退 出(&Q)";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // frmScanBarCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(453, 284);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dgvErrorBarCode);
            this.Controls.Add(this.btnBarCodeFile);
            this.Controls.Add(this.txtBarCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmScanBarCode";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "条码扫描/导入";
            this.Load += new System.EventHandler(this.frmScanBarCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrorBarCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.Button btnBarCodeFile;
        private System.Windows.Forms.DataGridView dgvErrorBarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}